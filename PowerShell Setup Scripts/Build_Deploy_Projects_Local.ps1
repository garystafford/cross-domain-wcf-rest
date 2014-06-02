###############################################################
# Author: Gary A. Stafford
# Revised: 2014-06-02
# Build & Deploy Projects to Local Machine in Debug Mode
###############################################################

########################################################################
# Main variables (Change these!)
[string]$git_repos = "PATH_HERE"  # C:\git_repos
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