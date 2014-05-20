###############################################################
# Author: Gary A. Stafford
# Revised: 2014-05-14
# Create main website and WCF service website
###############################################################

# Create main website
$newSite = "MenuWcfRestService"

if (-not (Test-Path IIS:\Sites\$newSite)){
    New-Website -Name $newSite -Port 9250 -PhysicalPath c:\$newSite -ApplicationPool "DefaultAppPool"
}

# Create WCF service website
$newSite = "RestaurantDemoSite"

if (-not (Test-Path IIS:\Sites\$newSite)){
    New-Website -Name $newSite -Port 9255 -PhysicalPath c:\$newSite -ApplicationPool "DefaultAppPool"
}
