








//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");







// ===========
// PREPARATION
// ===========

// Get working directories.
var objDirectory = Directory(string.Format(@"./com.strava.api/obj/{0}", configuration));
var binDirectory = Directory(string.Format(@"./com.strava.api/bin/{0}", configuration));

// Get assembly version.
var version = ParseReleaseNotes("./ReleaseNotes.md").Version.ToString();
var assemblyVersion = BuildSystem.IsLocalBuild ? version : string.Format("{0}.{1}.{2}", version, AppVeyor.Environment.Build.Number, "0");



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