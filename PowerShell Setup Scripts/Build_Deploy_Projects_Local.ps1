###############################################################
# Author: Gary A. Stafford
# Revised: 2017-05-26
# Build & Deploy Projects to Local Machine in Debug Mode
# Assumes MSBuild.exe directory is on %PATH%
# For example : C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin
###############################################################

########################################################################
# Main variables (Change these!)
[string]$git_repos = "C:\Users\gary.stafford\Source\Repos"  # C:\git_repos
########################################################################

# WCF Service
cd "$git_repos\cross-domain-wcf-rest\Restaurant\RestaurantWcfService"
msbuild RestaurantWcfService.csproj /p:DeployOnBuild=true `
  /p:PublishProfile=LocalMachine /p:Configuration=Debug `
  /verbosity:minimal /nologo

# Website
cd "$git_repos\cross-domain-wcf-rest\Restaurant\RestaurantDemoSite"
msbuild website.publishproj /p:DeployOnBuild=true `
  /p:PublishProfile=LocalMachine /p:Configuration=Debug `
  /verbosity:minimal /nologo

$host.enternestedprompt()