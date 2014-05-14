###############################################################
# Author: Gary A. Stafford
# Revised: 2014-05-14
# Prep Azure VM for 'cross-domain-wcf-rest' project deployment
# Create main website and WCF service website
###############################################################

# Create main website
$newSite = "MenuWcfRestService"

if (-not (Test-Path IIS:\Sites\$newSite)){
    New-Website -Name $newSite -Port 9250 -PhysicalPath c:\$newSite -ApplicationPool "ASP.NET v4.0"
}

# Create WCF service website
$newSite = "RestaurantDemoSite"

if (-not (Test-Path IIS:\Sites\$newSite)){
    New-Website -Name $newSite -Port 9255 -PhysicalPath c:\$newSite -ApplicationPool "ASP.NET v4.0"
}
