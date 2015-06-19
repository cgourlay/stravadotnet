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








///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(() =>
{
    Information("Building version {0} of Strava.NET", assemblyVersion);
});


// =====
// TASKS
// =====

Task("Clean").Does(() => {
							CleanDirectories(new DirectoryPath[] { objDirectory, binDirectory });
						 });









Task("Build")
    .Does(() =>
{
    MSBuild("./com.strava.api.sln", settings =>
        settings.SetConfiguration(configuration)
            .WithProperty("TreatWarningsAsErrors", "false")
            .UseToolVersion(MSBuildToolVersion.NET45)
            .SetNodeReuse(false));
});


//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
	.IsDependentOn("Clean")
    .IsDependentOn("Build");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);