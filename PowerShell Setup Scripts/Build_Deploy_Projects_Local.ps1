###############################################################
# Author: Gary A. Stafford
# Revised: 2017-05-26
# Build & Deploy Projects to Local Machine in Debug Mode
# Assumes MSBuild.exe directory is on %PATH%
# For example : C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin
###############################################################

########################################################################
# Main variables (Change these!)
[string]$projectLocation = "C:\Users\gary.stafford\Source\Repos\cross-domain-wcf-rest\Restaurant"
########################################################################

# WCF Service
msbuild "$projectLocation\RestaurantWcfService\RestaurantWcfService.csproj" `
  /p:DeployOnBuild=true `
  /p:PublishProfile=LocalMachine /p:Configuration=Debug `
  /verbosity:minimal /nologo

# Website
msbuild "$projectLocation\RestaurantDemoSite\website.publishproj" `
  /p:DeployOnBuild=true `
  /p:PublishProfile=LocalMachine /p:Configuration=Debug `
  /verbosity:minimal /nologo

# Pause script before closing to check output - only for manual execution!
$host.enternestedprompt()