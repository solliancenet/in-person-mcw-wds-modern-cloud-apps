function Disable-InternetExplorerESC {
    $AdminKey = "HKLM:\SOFTWARE\Microsoft\Active Setup\Installed Components\{A509B1A7-37EF-4b3f-8CFC-4F3A74704073}"
    $UserKey = "HKLM:\SOFTWARE\Microsoft\Active Setup\Installed Components\{A509B1A8-37EF-4b3f-8CFC-4F3A74704073}"
    Set-ItemProperty -Path $AdminKey -Name "IsInstalled" -Value 0 -Force
    Set-ItemProperty -Path $UserKey -Name "IsInstalled" -Value 0 -Force
    Stop-Process -Name Explorer -Force
    Write-Host "IE Enhanced Security Configuration (ESC) has been disabled." -ForegroundColor Green
}

# Resolves an error caused by Powershell defaulting to TLS 1.0 to connect to website, but website security requires TLS 1.2.
[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls, [Net.SecurityProtocolType]::Tls11, [Net.SecurityProtocolType]::Tls12, [Net.SecurityProtocolType]::Ssl3
[Net.ServicePointManager]::SecurityProtocol = "Tls, Tls11, Tls12, Ssl3"

# Disable IE ESC
Disable-InternetExplorerESC

# Download and extract the starter solution files
Invoke-WebRequest 'https://github.com/microsoft/MCW-Modern-cloud-apps/archive/refs/heads/main.zip' -OutFile 'C:\MCW.zip'
Expand-Archive -LiteralPath 'C:\MCW.zip' -DestinationPath 'C:\MCW' -Force

# Download and install Azure Data Studio
Invoke-WebRequest 'https://go.microsoft.com/fwlink/?linkid=2160780' -OutFile 'C:\azuredatastudio.exe'
Start-Process C:\azuredatastudio.exe /VERYSILENT

# Download and istall Microsoft Edge
Invoke-WebRequest 'https://go.microsoft.com/fwlink/?linkid=2108834&Channel=Stable&language=en' -OutFile 'C:\MicrosoftEdgeSetup.exe'
Start-Process C:\MicrosoftEdgeSetup.exe /VERYSILENT
