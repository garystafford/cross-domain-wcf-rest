###############################################################
# Author: Gary A. Stafford
# Revised: 2014-05-20
# Script to Deploy Projects to Local Machine in Debug Mode
###############################################################

# Change for your local environment
# [Environment]::SetEnvironmentVariable("GIT_REPOS", "path\to\my\local\git\repos", "Machine")
$gitRepositories = $env:GIT_REPOS

# WCF Service
cd "$gitRepositories\cross-domain-wcf-rest\Restaurant\RestaurantWcfService"
msbuild RestaurantWcfService.csproj /p:DeployOnBuild=true /p:PublishProfile=LocalMachine /p:Configuration=Debug

# Website
cd "$gitRepositories\cross-domain-wcf-rest\Restaurant\RestaurantDemoSite"
msbuild website.publishproj /p:DeployOnBuild=true /p:PublishProfile=LocalMachine /p:Configuration=Debug