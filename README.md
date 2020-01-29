# MadMaths
university project @ Worms University of Applied Science

## Beschreibung des Projekts
Das Programm soll ein Rechentraining für die Klassen 1-13 sein. Der User kann nach freiem belieben Übungsaufgaben für die jeweiligen Klassenstufen erledigen. Hierbei werden nicht geschaffte Aufgaben gespeichert, sodass der User wieder auf diese zugreifen und sie wiederholen kann. Des Weiteren wird ein Punktesystem eingeführt, welches den User motivieren soll.
Später soll ein Rangsystem eingeführt werden, sodass die User untereinander ihre Leistungen vergleichen können. Darüber hinaus wird es den User dazu motivieren mehr Übungen zu machen, um in den Rängen aufzusteigen.

## Benutzeranforderungen:
1.	Auswahl von verschiedenen Klassenstufen und den jeweiligen Themen
2.	Tests zum prüfen gelernter Kenntnisse
3.	Speichern von nicht geschafften Aufgaben zur Wiederholung
4.	Aufgabenfortschritt visuell einsehbar
5.	Level- und Rangsystem zur Motivation des Übenden

## Design und Struktur
Das Main Window ist in kleine Bereiche unterteilt.
Am linken Rand ist die Übersicht der Stufen. Oben rechts wird das Profil mit einem änderbaren Profilbild, dem momentanen Level und einem Fortschrittsbalken angezeigt. Rechts unter dem Profil wird das Ranking und links vom Ranking wird die letzte Übung angezeigt und andere Optionen.
Hauptfarbton Orange mit verschiedenen Akzenten.

## Aufgabensammlung
Die Aufgaben werden in einer .json Datei gespeichert und von dort aus herausgelesen.


## Systemvoraussetzungen

### Zum Ausführen:
 - Bildschirm mit einer Auflösung von mind. 1100x670
 - RAM 2GB
 - 64MB Festplattenspeicher
 - mind. Windows 7 SP1
 - .NET Framework 4.7.2
 - Internetverbindung empfohlen

### Zum Bauen:
 - Microsoft Visual Studio (s. Voraussetzungen auf der offizellen Seite)
 - .NET Framework 4.7.2 Developer Pack
 - Newtonsoft.Json
