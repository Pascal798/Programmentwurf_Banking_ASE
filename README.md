# Programmentwurf_Banking_ASE
Programmentwurf für die Vorlesung Advanced Software Engineering
## Implemented Features:
* Registrieren / Login
* Konto anlegen
* Geld auf Konto überweisen / Geld von Konto abbuchen
* Überweisung auf andere Konten (eigene und fremde Konten)
* Transaktionen einsehen
* Transaktionen eines Kontos als Mail senden
* Banken anlegen
* Passwort ändern

## Run the Project with Visual Studio 2019
Um die WebApi in Visual Studio 2019 zu starten, wird die gesamte Projektmappe mit Visual
Studio geöffnet. Im Solution-Explorer sind daraufhin folgende Projekte zu sehen:
* Programmentwurf_BankingApi
* Programmentwurf_Banking_Client
* Programmentwurf_Mock_Tests
* Programmentwurf_xUnit_Tests
* 
In „Programmentwurf_BankingApi “befinden sich die einzelnen Projekte der WebApi. Durch
Rechtsklick auf die Solution im Solution-Explorer kann unter „Startprojekte festlegen “ausgewählt
werden, welche Projekte durch drücken von F5 gestartet werden sollen. Hier wird für das
Projekt „0_Plugin “die Option „Starten “ausgewählt. Optional kann auch für das Projekt
„Programmentwurf_Banking_Client “die Option „Starten “ausgewählt werden, um auch den
Client direkt zu starten.

## Run the Project with VS Code
Um die WebApi in Visual Studio Code zu starten, muss das Projekt „0_Plugin “ausgeführt
werden. Dafür wird in den Ordner „Programmentwurf_BankingApi “navigiert und von dort in
den Projektordner „0_Plugin “. Dort wird über die Terminal-Konsole folgende Befehle ausgeführt:
* dotnet build
* dotnet run
Mit „dotnet “build wird versucht die Anwendung zu kompilieren. Dadurch werden auch alle
NuGet-Pakete heruntergeladen, die für die Entwicklung des Porgramms genutzt wurden.
Mit „dotnet run “wird daraufhin die Anwendung gestartet. Wird die Anwendung über Visual
Studio Code gestartet, ist sie über den localhost mit Port 5001 erreichbar
