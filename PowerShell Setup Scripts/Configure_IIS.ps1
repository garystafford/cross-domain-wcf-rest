###############################################################
# Author: Gary A. Stafford
# Revised: 2017-05-26
# Create main website and WCF service website in IIS
###############################################################


########################################################################
# Main variables (Change these!)
[string]$WcfServiceSite = "MenuWcfRestService"  # MenuWcfRestService
[string]$Website        = "RestaurantDemoSite"  # RestaurantDemoSite
########################################################################

# Import WebAdministration Module
Import-Module -Name WebAdministration

# Create main website in IIS
if (-not (Test-Path IIS:\Sites\$WcfServiceSite)){
  New-Website -Name $WcfServiceSite -Port 9250 -PhysicalPath `
	c:\$WcfServiceSite -ApplicationPool "DefaultAppPool"
}

# Create WCF service website in IIS
if (-not (Test-Path IIS:\Sites\$Website)){
  New-Website -Name $Website -Port 9255 -PhysicalPath `
	c:\$Website -ApplicationPool "DefaultAppPool"
}
