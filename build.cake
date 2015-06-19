








//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Get whether or not this is a local build.
var local = BuildSystem.IsLocalBuild;
var isRunningOnAppVeyor = AppVeyor.IsRunningOnAppVeyor;
var isPullRequest = AppVeyor.Environment.PullRequest.IsPullRequest;

// Parse release notes.
var releaseNotes = ParseReleaseNotes("./ReleaseNotes.md");

// Get version.
var buildNumber = AppVeyor.Environment.Build.Number;
var version = releaseNotes.Version.ToString();
var semVersion = local ? version : (version + string.Concat("-build-", buildNumber));



var objDirectory = Directory("./com.strava.api/obj/" + configuration);
var binDirectory = Directory("./com.strava.api/bin/" + configuration);

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(() =>
{
    Information("Building version {0} of Strava.NET", semVersion);
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