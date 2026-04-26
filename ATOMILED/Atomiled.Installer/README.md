### TL;DR

Atomiled.Installer - ATOMILED online installer. Downloads the latest release from the GitHub repository and installs it.

#### Usage

```
Usage:
  Atomiled.Installer [options] [[--] <additional arguments>...]]

Options:
  -p, --path <path> (REQUIRED)         Path to the folder with the SL server [default: YourWorkingFolder]
  --appdata <appdata> (REQUIRED)       Forces the folder to be the AppData folder (useful for containers when pterodactyl runs as root) [default: YourAppDataPath]
  --Atomiled <Atomiled> (REQUIRED)         Indicates the Atomiled root folder [default: YourAppDataPath]
  --pre-releases                       Includes pre-releases [default: False]
  --target-version <target-version>    Target version for installation
  --github--token <github--token>      Uses a token for auth in case the rate limit is exceeded (no permissions required)
  --exit                               Automatically exits the application anyway
  --get-versions                       Gets all possible versions for installation
  --version                            Show version information
  -?, -h, --help                       Show help and usage information

Additional Arguments:
  Arguments passed to the application that is being run.
```

-----

#### Examples

- ##### Basic installation in the folder you are in

```
user@user:~/SCP# ./Atomiled.Installer-Linux --pre-releases
Atomiled.Installer-Linux-3.2.3.0
AppData folder: YourAppDataPath
Atomiled folder: YourAppDataPath
Receiving releases...
Prereleases included - True
Target release version - (null)
Searching for the latest release that matches the parameters...
Trying to find release..
Release found!
PRE: True | ID: 87710626 | TAG: 6.0.0-beta.18
Asset found!
ID: 90263995 | NAME: Atomiled.tar.gz | SIZE: 1027928 | URL: https://api.github.com/repos/Exmod-Team/Atomiled-EA/releases/assets/90263995 | DownloadURL: https://github.com/Exmod-Team/Atomiled-EA/releases/download/6.0.0-beta.18/Atomiled.tar.gz
Processing 'ATOMILED/Plugins/dependencies/0Harmony.dll'
Extracting '0Harmony.dll' into 'YourAppDataPath/ATOMILED/Plugins/dependencies/0Harmony.dll'...
Processing 'ATOMILED/Plugins/dependencies/Atomiled.API.dll'
Extracting 'Atomiled.API.dll' into 'YourAppDataPath/ATOMILED/Plugins/dependencies/Atomiled.API.dll'...
Processing 'ATOMILED/Plugins/dependencies/SemanticVersioning.dll'
Extracting 'SemanticVersioning.dll' into 'YourAppDataPath/ATOMILED/Plugins/dependencies/SemanticVersioning.dll'...
Processing 'ATOMILED/Plugins/dependencies/YamlDotNet.dll'
Extracting 'YamlDotNet.dll' into 'YourAppDataPath/ATOMILED/Plugins/dependencies/YamlDotNet.dll'...
Processing 'ATOMILED/Plugins/Atomiled.CreditTags.dll'
Extracting 'Atomiled.CreditTags.dll' into 'YourAppDataPath/ATOMILED/Plugins/Atomiled.CreditTags.dll'...
Processing 'ATOMILED/Plugins/Atomiled.CustomItems.dll'
Extracting 'Atomiled.CustomItems.dll' into 'YourAppDataPath/ATOMILED/Plugins/Atomiled.CustomItems.dll'...
Processing 'ATOMILED/Plugins/Atomiled.CustomRoles.dll'
Extracting 'Atomiled.CustomRoles.dll' into 'YourAppDataPath/ATOMILED/Plugins/Atomiled.CustomRoles.dll'...
Processing 'ATOMILED/Plugins/Atomiled.Events.dll'
Extracting 'Atomiled.Events.dll' into 'YourAppDataPath/ATOMILED/Plugins/Atomiled.Events.dll'...
Processing 'ATOMILED/Plugins/Atomiled.Permissions.dll'
Extracting 'Atomiled.Permissions.dll' into 'YourAppDataPath/ATOMILED/Plugins/Atomiled.Permissions.dll'...
Processing 'ATOMILED/Plugins/Atomiled.Updater.dll'
Extracting 'Atomiled.Updater.dll' into 'YourAppDataPath/ATOMILED/Plugins/Atomiled.Updater.dll'...
Processing 'SCP Secret Laboratory/PluginAPI/plugins/7777/dependencies/Atomiled.API.dll'
Extracting 'Atomiled.API.dll' into 'YourAppDataPath/SCP Secret Laboratory/PluginAPI/plugins/7777/dependencies/Atomiled.API.dll'...
Processing 'SCP Secret Laboratory/PluginAPI/plugins/7777/dependencies/YamlDotNet.dll'
Extracting 'YamlDotNet.dll' into 'YourAppDataPath/SCP Secret Laboratory/PluginAPI/plugins/7777/dependencies/YamlDotNet.dll'...
Processing 'SCP Secret Laboratory/PluginAPI/plugins/7777/Atomiled.Loader.dll'
Extracting 'Atomiled.Loader.dll' into 'YourAppDataPath/SCP Secret Laboratory/PluginAPI/plugins/7777/Atomiled.Loader.dll'...
Installation complete
```

- ##### Installation in a specific folder, specific version and specific appdata folder

```
user@user:~/SCP# ./Atomiled.Installer-Linux --appdata /user/SCP --Atomiled /user/SCP
Atomiled.Installer-Linux-3.2.3.0
AppData folder: /user/SCP
Atomiled folder: /user/SCP
Receiving releases...
Prereleases included - False
Target release version - (null)
Searching for the latest release that matches the parameters...
Trying to find release..
Release found!
PRE: False | ID: 87710626 | TAG: 6.0.0-beta.18
Asset found!
ID: 90263995 | NAME: Atomiled.tar.gz | SIZE: 1027928 | URL: https://api.github.com/repos/Exmod-Team/Atomiled-EA/releases/assets/90263995 | DownloadURL: https://github.com/Exmod-Team/Atomiled-EA/releases/download/6.0.0-beta.18/Atomiled.tar.gz
Processing 'ATOMILED/Plugins/dependencies/0Harmony.dll'
Extracting '0Harmony.dll' into '/user/SCP/ATOMILED/Plugins/dependencies/0Harmony.dll'...
Processing 'ATOMILED/Plugins/dependencies/Atomiled.API.dll'
Extracting 'Atomiled.API.dll' into '/user/SCP/ATOMILED/Plugins/dependencies/Atomiled.API.dll'...
Processing 'ATOMILED/Plugins/dependencies/SemanticVersioning.dll'
Extracting 'SemanticVersioning.dll' into '/user/SCP/ATOMILED/Plugins/dependencies/SemanticVersioning.dll'...
Processing 'ATOMILED/Plugins/dependencies/YamlDotNet.dll'
Extracting 'YamlDotNet.dll' into '/user/SCP/ATOMILED/Plugins/dependencies/YamlDotNet.dll'...
Processing 'ATOMILED/Plugins/Atomiled.CreditTags.dll'
Extracting 'Atomiled.CreditTags.dll' into '/user/SCP/ATOMILED/Plugins/Atomiled.CreditTags.dll'...
Processing 'ATOMILED/Plugins/Atomiled.CustomItems.dll'
Extracting 'Atomiled.CustomItems.dll' into '/user/SCP/ATOMILED/Plugins/Atomiled.CustomItems.dll'...
Processing 'ATOMILED/Plugins/Atomiled.CustomRoles.dll'
Extracting 'Atomiled.CustomRoles.dll' into '/user/SCP/ATOMILED/Plugins/Atomiled.CustomRoles.dll'...
Processing 'ATOMILED/Plugins/Atomiled.Events.dll'
Extracting 'Atomiled.Events.dll' into '/user/SCP/ATOMILED/Plugins/Atomiled.Events.dll'...
Processing 'ATOMILED/Plugins/Atomiled.Permissions.dll'
Extracting 'Atomiled.Permissions.dll' into '/user/SCP/ATOMILED/Plugins/Atomiled.Permissions.dll'...
Processing 'ATOMILED/Plugins/Atomiled.Updater.dll'
Extracting 'Atomiled.Updater.dll' into '/user/SCP/ATOMILED/Plugins/Atomiled.Updater.dll'...
Processing 'SCP Secret Laboratory/PluginAPI/plugins/7777/dependencies/Atomiled.API.dll'
Extracting 'Atomiled.API.dll' into '/user/SCP/SCP Secret Laboratory/PluginAPI/plugins/7777/dependencies/Atomiled.API.dll'...
Processing 'SCP Secret Laboratory/PluginAPI/plugins/7777/dependencies/YamlDotNet.dll'
Extracting 'YamlDotNet.dll' into '/user/SCP/SCP Secret Laboratory/PluginAPI/plugins/7777/dependencies/YamlDotNet.dll'...
Processing 'SCP Secret Laboratory/PluginAPI/plugins/7777/Atomiled.Loader.dll'
Extracting 'Atomiled.Loader.dll' into '/user/SCP/SCP Secret Laboratory/PluginAPI/plugins/7777/Atomiled.Loader.dll'...
Installation complete
```

