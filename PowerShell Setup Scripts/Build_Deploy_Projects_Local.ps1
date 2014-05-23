###############################################################
# Author: Gary A. Stafford
# Revised: 2014-05-23
# Build & Deploy Projects to Local Machine in Debug Mode
###############################################################

# Change and set GIT_REPOS environment variable first
# [Environment]::SetEnvironmentVariable("GIT_REPOS", "path\to\my\local\git\repos", "Machine")

# WCF Service
cd "$env:GIT_REPOS\cross-domain-wcf-rest\Restaurant\RestaurantWcfService"
msbuild RestaurantWcfService.csproj /p:DeployOnBuild=true `
	/p:PublishProfile=LocalMachine /p:Configuration=Debug `
	/verbosity:minimal /nologo

# Website
cd "$env:GIT_REPOS\cross-domain-wcf-rest\Restaurant\RestaurantDemoSite"
msbuild website.publishproj /p:DeployOnBuild=true `
	/p:PublishProfile=LocalMachine /p:Configuration=Debug `
	/verbosity:minimal /nologo