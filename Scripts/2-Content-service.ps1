$currentloc = [string](Get-Location)
try
{
    $parentloc = (Get-Item $currentloc).Parent.Parent.Parent.FullName
    Set-Location $parentloc\ContentService\SitefinityMicroservice\DFC.Sitefinity.MicroService.API
    docker-compose -p dfcspike up -d
}
finally
{
    Set-Location $currentloc
}