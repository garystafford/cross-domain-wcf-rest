###############################################################
# Author: Gary A. Stafford
# Revised: 2014-05-23
# Build Projects on AppVeyor
###############################################################

# Build WCF service
# (AppVeyor config ignores website Project in Solution)
msbuild Restaurant\Restaurant.sln `
  /p:Configuration=AppVeyor /verbosity:minimal /nologo

# Build website
msbuild Restaurant\RestaurantDemoSite\website.publishproj `
  /p:Configuration=Release /verbosity:minimal /nologo

Write-Host "*** Solution builds complete."
