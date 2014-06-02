###############################################################
# Author: Gary A. Stafford
# Revised: 2014-05-14
# Create directory and security settings for restaurant orders
###############################################################

# Create new restaurant orders directory
$newDirectory = "c:\RestaurantOrders"

if (-not (Test-Path $newDirectory)){
  New-Item -Type directory -Path $newDirectory > null
  Write-Host "*** '$newDirectory' directory created."
}

$acl = Get-Acl $newDirectory
$ar = New-Object System.Security.AccessControl.FileSystemAccessRule(`
	"INTERACTIVE","Modify","ContainerInherit, ObjectInherit", "None", "Allow")
$acl.SetAccessRule($ar)
Set-Acl $newDirectory $acl