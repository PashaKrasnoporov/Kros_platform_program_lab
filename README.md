# Розгортання та конфігурація пакету

Цей репозиторій містить скрипти та конфігурації для пакування, розгортання та налаштування пакету NuGet AAleksandruk. Нижче наведені детальні інструкції та конфігурації для різних операційних систем.

## 1. Пакування та Вивантаження на Сервер
Щоб упакувати та вивантажити пакет PKrasnopyorov на сервер, слідуйте цим командам:

```sh
dotnet pack -c Release
dotnet nuget push PKrasnopyorov.1.0.0.nupkg --source http://127.0.0.1/nuget
```

Переконайтесь, що .NET SDK встановлено та правильно налаштовано на вашому комп’ютері.

## 2. Конфігурація Vagrant для Linux

Нижче наведено конфігурацію Vagrant для налаштування середовища Linux (Ubuntu Bionic 64):

```sh
Vagrant.configure("2") do |config|
  config.vm.box = "ubuntu/bionic64"
  config.vm.network "private_network", type: "dhcp"

  config.vm.provision "shell", inline: <<-SHELL
    # Оновлення репозиторіїв
    sudo apt-get update

    # Встановлення необхідних компонентів для .NET
    sudo apt-get install -y apt-transport-https wget

    # Додавання репозиторію пакетів Microsoft
    wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
    sudo dpkg -i packages-microsoft-prod.deb

    # Встановлення .NET SDK 7
    sudo apt-get update
    sudo apt-get install -y dotnet-sdk-7.0
    
    sudo apt install -y nuget

    nuget install AAleksandruk -Source http://10.0.2.2:8080/nuget

    export AAleksandruk=~/AAleksandruk.1.0.0/lib/net7.0/Lab4.dll

    echo 'export PATH=$PATH:$HOME/.dotnet/tools' >> /home/vagrant/.bash_profile

    su - vagrant -c "dotnet nuget add source http://10.0.2.2:8080/nuget"
    su - vagrant -c "dotnet tool install -g AAleksandruk --version 1.0.0 --ignore-failed-sources"
  SHELL
end
```

Переконайтесь, що у вас встановлено Vagrant і сумісний провайдер (наприклад, VirtualBox).

## 3. Конфігурація Vagrant для Windows

Нижче наведено конфігурацію Vagrant для налаштування середовища Windows 10:

```sh
Vagrant.configure("2") do |config|
  config.vm.box = "gusztavvargadr/windows-10"
  
  config.vm.network "private_network", type: "dhcp"
  config.vm.communicator = "winrm"
  config.winrm.transport = :plaintext

  config.vm.provision "shell", privileged: true, inline: <<-SHELL
    # Переконайтесь, що PowerShell використовує TLS1.2
    [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

    # Встановлення .NET Core SDK
    Invoke-WebRequest -OutFile dotnet-sdk-installer.exe https://download.visualstudio.microsoft.com/download/pr/d0348cb9-c348-4c68-93aa-70122dd44a33/5f982a6ffdb29ed70af11ffc08d3189e/dotnet-sdk-7.0.402-win-x64.exe
    Start-Process -Wait -FilePath .\dotnet-sdk-installer.exe
    Remove-Item dotnet-sdk-installer.exe
  SHELL
end
```

Переконайтесь, що у вас встановлено Vagrant і сумісний провайдер (наприклад, VirtualBox).

## 4. Команди для Windows

Після налаштування середовища Windows за допомогою Vagrant, ви можете виконати наступні команди у PowerShell або Command Prompt, щоб додати джерело NuGet і встановити інструмент AAleksandruk:

```powershell
dotnet nuget add source http://10.0.2.2:8080/nuget
dotnet tool install -g AAleksandruk --version 1.0.0 --ignore-failed-sources
```

