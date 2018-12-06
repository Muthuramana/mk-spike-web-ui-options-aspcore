#Create repo under
$loc = [string](Get-Location)
$currentloc = $loc

try
{
    Set-Location $loc
    Remove-Item $loc\Frontend -recurse -Force -ErrorAction SilentlyContinue
    Remove-Item $loc\ContentService -recurse -Force -ErrorAction SilentlyContinue
    Remove-Item $loc\SkillsContentService -recurse -Force -ErrorAction SilentlyContinue
    Remove-Item $loc\SkillsContentService-v2 -recurse -Force -ErrorAction SilentlyContinue
    Remove-Item $loc\SkillsRepo -recurse -Force -ErrorAction SilentlyContinue

    mkdir Frontend -Force
    mkdir ContentService -Force
    mkdir SkillsContentService -Force
    mkdir SkillsContentService-v2 -Force
    mkdir SkillsRepo -Force

    Set-Location $loc\Frontend
    git clone https://github.com/Muthuramana/mk-spike-web-ui-options-aspcore.git
    Set-Location .\mk-spike-web-ui-options-aspcore\Careers.Freshlook
    docker-compose -p dfcspike up -d --build

    Set-Location $loc\ContentService
    git clone https://github.com/Muthuramana/SitefinityMicroservice.git
    Set-Location .\SitefinityMicroservice\DFC.Sitefinity.MicroService.API
    docker-compose -p dfcspike up -d --build
    Start-Sleep 5
    Invoke-WebRequest http://localhost:5002/api/jobprofile/updatejobprofilerepo
    #&"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" http://localhost:5002/api/jobprofile/plumber

    Set-Location $loc\SkillsContentService
    git clone https://github.com/Muthuramana/DFCSkillsMicroservice.git
    Set-Location .\DFCSkillsMicroservice\DFC.Microservices.Skills
    docker-compose -p dfcspike up -d --build

    Set-Location $loc/SkillsContentService-v2
    git clone https://github.com/Muthuramana/DFCSkillsMicroservice-v2.git
    # Set-Location .\DFCSkillsMicroservice\DFC.Microservices.Skills
    # docker-compose -p dfcspike up -d --build

    Set-Location $loc\SkillsRepo
    git clone https://github.com/Muthuramana/dfc.skills.data.git
    Set-Location .\dfc.skills.data\dfc.skills.repo.docker
    docker-compose -p dfcspike up -d --build
    Set-Location $loc\SkillsRepo\dfc.skills.data
    npm install
    node .\server.js

    &"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" http://localhost:5000
}
finally
{
    Set-Location $currentloc
}
