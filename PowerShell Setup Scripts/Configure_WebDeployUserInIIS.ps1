########################################################################
# Author: Gary A. Stafford
# Revised: 2014-06-02
# Assign non-admin User in IIS for Web Deploy
# Reference: http://blogs.msdn.com/b/carlosag/archive/2009/10/23/adding-iis-manager-users-and-permissions-through-powershell.aspx
########################################################################

########################################################################
# Main variables (Change these!)
[string]$userName       = "USER_NAME_HERE"     # mjones
[string]$WcfServiceSite = "SERVICE_SITE_HERE"  # MenuWcfRestService
[string]$Website        = "WEBSITE_HERE"       # RestaurantDemoSite
########################################################################

[System.Reflection.Assembly]::LoadWithPartialName("Microsoft.Web.Management")

# Below line allows you to create a user in IIS,
# but we already have a local Windows user created, so we don't need...
# [Microsoft.Web.Management.Server.ManagementAuthentication]::CreateUser(`
#   "MyUser", "ThePassword")

[Microsoft.Web.Management.Server.ManagementAuthorization]::Grant(`
  $userName, "$Env:COMPUTERNAME\MenuWcfRestService", $FALSE)
[Microsoft.Web.Management.Server.ManagementAuthorization]::Grant(`
  $userName, "$Env:COMPUTERNAME\RestaurantDemoSite", $FALSE)