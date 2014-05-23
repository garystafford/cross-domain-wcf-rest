###############################################################
# Author: Gary A. Stafford
# Revised: 2014-05-14
# Create directories and security settings for IIS directories
###############################################################

#The possible values for Rights are 
# ListDirectory, ReadData, WriteData 
# CreateFiles, CreateDirectories, AppendData 
# ReadExtendedAttributes, WriteExtendedAttributes, Traverse
# ExecuteFile, DeleteSubdirectoriesAndFiles, ReadAttributes 
# WriteAttributes, Write, Delete 
# ReadPermissions, Read, ReadAndExecute 
# Modify, ChangePermissions, TakeOwnership
# Synchronize, FullControl


# Create new website directory
$newDirectory = "c:\RestaurantDemoSite"

if (-not (Test-Path $newDirectory)){
  New-Item -Type directory -Path $newDirectory
}

$acl = Get-Acl $newDirectory
$ar = New-Object System.Security.AccessControl.FileSystemAccessRule(
  "IUSR","ReadAndExecute","ContainerInherit, ObjectInherit", "None", "Allow")
$acl.SetAccessRule($ar)
Set-Acl $newDirectory $acl


# Create new WCF service directory
$newDirectory = "c:\MenuWcfRestService"

if (-not (Test-Path $newDirectory)){
  New-Item -Type directory -Path $newDirectory
}

$acl = Get-Acl $newDirectory
$ar = New-Object System.Security.AccessControl.FileSystemAccessRule(
  "IUSR","ReadAndExecute","ContainerInherit, ObjectInherit", "None", "Allow")
$acl.SetAccessRule($ar)

Set-Acl $newDirectory $acl
$ar = New-Object System.Security.AccessControl.FileSystemAccessRule(
  "IIS_IUSRS","ReadAndExecute","ContainerInherit, ObjectInherit", "None", "Allow")
$acl.SetAccessRule($ar)
Set-Acl $newDirectory $acl
