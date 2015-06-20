// =========
// ARGUMENTS
// =========

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Debug");


// ===========
// PREPARATION
// ===========

// Get working directories.
var objDirectory = Directory(string.Format(@"./com.strava.api/obj/{0}", configuration));
var binDirectory = Directory(string.Format(@"./com.strava.api/bin/{0}", configuration));

// Get assembly version.
var releaseNotesVersion = ParseReleaseNotes("./ReleaseNotes.md").Version.ToString();
var assemblyVersion = BuildSystem.IsLocalBuild ? releaseNotesVersion : string.Format("{0}.{1}.{2}", releaseNotesVersion, AppVeyor.Environment.Build.Number, DateTime.ParseExact(AppVeyor.Environment.Repository.Commit.Timestamp, "M/d/yyyy h:mm:ss tt", new System.Globalization.CultureInfo("en-US")).Ticks.ToString());

// Get tools used.
var nunitConsole = "./packages/NUnit.Runners.2.6.4/tools/nunit-console.exe";

// Miscellaneous
var productName = "Strava.NET";
var contributers = new string[] { "Colin Gourlay" };


// ==============
// SETUP/TEARDOWN
// ==============

Setup(() => {
				Information("Building {0}... Version {1} ({2})", productName, assemblyVersion, configuration);
			});


// =====
// TASKS
// =====

Task("Clean").Does(() => {
							CleanDirectories(new DirectoryPath[] { objDirectory, binDirectory });
						 });

Task("PatchAssemblyInfo").Does(() => {
										CreateAssemblyInfo("./com.strava.api/Properties/AssemblyInfo.cs", new AssemblyInfoSettings  {
																																		Product = productName,
																																		Version = releaseNotesVersion,
																																		FileVersion = releaseNotesVersion,
																																		InformationalVersion = assemblyVersion,
																																		Copyright = string.Format("Copyright (c) 2015 {0}", string.Join(" ", contributers))
																																	});
									 });

Task("Build").IsDependentOn("PatchAssemblyInfo")
			 .Does(() => {
							MSBuild("./com.strava.api.sln", settings => settings.SetConfiguration(configuration)
																				.WithProperty("TreatWarningsAsErrors", "false")
																				.UseToolVersion(MSBuildToolVersion.NET45)
																				.SetNodeReuse(false));			
						 });

Task("RunTests").Does(() =>	{
								NUnit("./com.strava.api/**/bin/" + configuration + "/*.Tests.dll", new NUnitSettings { ToolPath = nunitConsole });
							});


// ============
// TASK TARGETS
// ============

Task("Default")
	.IsDependentOn("Clean")
    .IsDependentOn("Build")
	.IsDependentOn("RunTests");


// =========
// EXECUTION
// =========

RunTarget(target);