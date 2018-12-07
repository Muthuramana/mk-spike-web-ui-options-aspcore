$currentloc = [string](Get-Location)
try
{
    #docker stop dfcspike_dfc.microservices.skills_1

    $parentloc = (Get-Item $currentloc).Parent.Parent.Parent.FullName

    Set-Location $parentloc/UMSMicroService/DFCUMSMicroservice/DFC.UMS.Microservice
    docker-compose -p dfcspike up -d --build
}
finally
{
    Set-Location $currentloc
}