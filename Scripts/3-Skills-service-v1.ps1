$currentloc = [string](Get-Location)
try
{
    docker stop dfcspike_dfc.microservices.skills_1

    $parentloc = (Get-Item $currentloc).Parent.Parent.Parent.FullName

    Set-Location $parentloc\SkillsContentService\DFCSkillsMicroservice\DFC.Microservices.Skills
    docker-compose -p dfcspike up -d --build

    Set-Location $parentloc\SkillsRepo\dfc.skills.data\dfc.skills.repo.docker
    docker-compose -p dfcspike up -d
}
finally
{
    Set-Location $currentloc
}