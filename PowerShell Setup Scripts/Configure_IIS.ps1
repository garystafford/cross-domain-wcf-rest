###############################################################
# Author: Gary A. Stafford
# Revised: 2014-05-27
# Create main website and WCF service website in IIS
###############################################################

# Import WebAdministration Module
Import-Module -Name WebAdministration

# Create main website in IIS
$newSite = "MenuWcfRestService"

if (-not (Test-Path IIS:\Sites\$newSite)){
  New-Website -Name $newSite -Port 9250 -PhysicalPath `
	c:\$newSite -ApplicationPool "DefaultAppPool"
}

# Create WCF service website in IIS
$newSite = "RestaurantDemoSite"

if (-not (Test-Path IIS:\Sites\$newSite)){
  New-Website -Name $newSite -Port 9255 -PhysicalPath `
	c:\$newSite -ApplicationPool "DefaultAppPool"
}
