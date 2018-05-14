$currentloc = [string](Get-Location)
$parentloc = (Get-Item $currentloc).Parent.Parent.Parent.FullName
Set-Location $parentloc\Frontend\mk-spike-web-ui-options-aspcore\Careers.Freshlook
docker-compose -p dfcspike up -d
Start-Sleep 5
& "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" http://localhost:5000