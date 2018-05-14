$currentloc = [string](Get-Location)
$parentloc = (Get-Item $currentloc).Parent.Parent.Parent.FullName

Set-Location $parentloc\SkillsContentService\DFCSkillsMicroservice\DFC.Microservices.Skills
docker-compose -p dfcspike up -d

Set-Location $parentloc\SkillsRepo\dfc.skills.data\dfc.skills.repo.docker
docker-compose -p dfcspike up -d
