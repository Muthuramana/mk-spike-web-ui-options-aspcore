$currentloc = [string](Get-Location)
try
{
    docker stop dfcspike_dfc.microservices.skills_1

    $parentloc = (Get-Item $currentloc).Parent.Parent.Parent.FullName

    #Set-Location $parentloc
    #Remove-Item .\SkillsContentService-v2 -recurse -Force -ErrorAction SilentlyContinue
    #mkdir SkillsContentService-v2 -Force

    Set-Location $parentloc/SkillsContentService-v2
    #git clone https://github.com/trevorkapswarah/DFCSkillsMicroservice.git

    Set-Location .\DFCSkillsMicroservice\DFC.Microservices.Skills
    docker-compose -p dfcspike up -d

    Set-Location $parentloc\SkillsRepo\dfc.skills.data\dfc.skills.repo.docker
    docker-compose -p dfcspike up -d
}
finally
{
    Set-Location $currentloc
}