# 1
Get-Date

# 2
Get-Service

# 3
(Get-Service)[0..2]
(Get-Service)[0..2].Name

# 4
Get-Process

# 5
(Get-Process)[0..2]

# 6
$weekday="torsdag"
Write-Host $weekday

# 7
$prime = 2,3,5,7,11
Write-Host $prime

# 8 - Ingenting händer
$foo

# 9
Write-Host -ForegroundColor Green "Hej!"

# 10
Write-Host -ForegroundColor Red -BackgroundColor Yellow "Sweden"

# 11
$fruit = "Banan"
"Ge mig en $fruit"

# 12
Get-ChildItem C:\Users

# 13
Get-ChildItem C:\Users | select Name
Get-ChildItem C:\Users | Select-Object Name

# 14
Get-ChildItem C:\Users | sort Name
Get-ChildItem C:\Users | Sort-Object Name

# 15
Get-ChildItem C:\Users | Sort-Object Name -Descending  

# 16
Get-ChildItem C:\Users | Sort-Object Name -Descending | select Name

# 17 
Get-ChildItem C:\Users | ForEach-Object {$_.FullName} 

# 18
Get-ChildItem C:\Users | Select-Object  -Property CreationTime, Name

# 19
Get-ChildItem C:\Users | ForEach-Object {Write-Host -ForegroundColor Green $_}

# 20
Get-ChildItem C:\Users | Write-Host -ForegroundColor Green

# 21
(Get-ChildItem C:\Users).LastWriteTime | Write-Host -ForegroundColor Green

# 22
Get-ChildItem C:\Users | Sort-Object LastWriteTime | Select-Object -Last 1

# 23
$env:COMPUTERNAME 
${env:ProgramFiles(x86)}
$env:windir

# 24
'Hello' | Get-Member 

# 25
$svc = Get-Service
$svc[2].Name

# 26
(Get-Service)[2].Name

# 27
Get-ChildItem C:\Users | Sort-Object Name -Descending | select name | Export-Csv C:\Temp\foo2.txt

# 28
Set-ExecutionPolicy -ExecutionPolicy Undefined -Scope CurrentUser
.\hello.ps1 -firstname Lisa -age 23 -toupper no
.\hello.ps1 -age 45 -toupper no
.\hello.ps1 -firstname Laban -age 37 -toupper yes

# 29
Get-Content .\colors.txt

# 30
(Get-Content .\colors.txt)[1]

# 31
Get-Process | Sort-Object CPU -Descending | Select-Object -First 10

# 32
Get-Service -Name ("WinDefend","UserManager")

# 33
Get-Service -Name (Get-Content .\service-names.txt)

# 34 
Get-Service | Select-Object -First 5 | ForEach-Object {"En service: " + $_.Name}

# 35
Remove-Item C:\Temp\MVC02Test -Force -Recurse

# 36
New-Item C:\Temp\Play -ItemType Directory
New-Item C:\Temp\Play\SubFolder -ItemType Directory

# 37
New-Item C:\Temp\Play\Test1.txt -ItemType File

# 38
New-Item C:\Temp\Play\Test1.txt -ItemType File -Force

# 39
New-Item C:\Temp\Play\colors.txt -Value Red`r`Green`r`Blue

# 40
1..10 | ForEach-Object { New-Item -Name text$_.txt -Force -ItemType File }

# 41
Get-Content .\colors.txt | ForEach-Object { New-Item C:\Temp\Play\Server-$_.txt -ItemType File -Force }

# 42
$result = (Invoke-WebRequest -Uri "https://www.trafikverket.se/")
$result.Links.Href | Where-Object {$_.StartsWith("tel:")} 

# 43
$result = (Invoke-WebRequest -Uri "https://www.trafikverket.se/")
$result.Links.Href | Where-Object {$_.StartsWith("/om-oss/jobb-och-framtid/Lediga-jobb")}

# 44
$result = (Invoke-WebRequest -Uri "https://www.trafikverket.se/")
$result.Links.Href | Where-Object {$_.StartsWith("http://") -or $_.StartsWith("https://") }

# 45
$socialmedia = new-object System.Text.RegularExpressions.Regex ('^https?://www.(facebook|instagram|twitter|youtube|linkedin)')
$result = (Invoke-WebRequest -Uri "https://www.trafikverket.se/")
$result.Links.Href | Where-Object {$socialmedia.IsMatch($_) }





