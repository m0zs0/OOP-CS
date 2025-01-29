# Visual Studio 2022 verziókezelt projektek szinkronizálása OneDrive-on keresztül

## OneDrive alkalmazás beállítása
1. Kattints a OneDrive ikonra a tálcán (jobb alsó sarokban).
2. Lépj be az otthoni Windows-os accountoddal. 
3. Válaszd a Beállítások lehetőséget.
4. Az Fiók fülön kattints a Mappák kiválasztása gombra.
5. A megjelenő ablakban válaszd ki azt a mappát, amelyet szinkronizálni szeretnél a felhővel C:\?\repos. 


## Új, verziókezelt projekt létrehozása
0. Megjegyzés: Ha így használod a VS2022 Community-t, akkor nem feltétlen kell bejelentkezni a VS2022-be
```console
1. Create New Project
```
2. Válaszd ki a kívánt projekt típusát (pl. Console App, WPF App stb.), majd kattints a Next gombra.
3. A Configure your new project ablakban, a Location mezőben válaszd ki a kívánt könyvtárat, ahol a projektet létre szeretnéd hozni. 
4. Add meg a projekt nevét és egyéb szükséges adatokat, majd kattints a Create gombra.
```console
5. A Solution Explorer ablakban kattints jobb gombbal a Solution-ra, majd válaszd a Create Git Repository lehetőséget.
```
6. Győződj meg róla, hogy a projekt mappáját választod ki a repozitórium helyeként, majd kattints a Create gombra.
```console
7. Ezután a Git Changes ablakban láthatod a módosított fájlokat
```
8. Írj egy Commit Message-et, majd Commit All gombra, hogy a változtatásokat elmentsd a helyi repozitóriumba. Innen a OneDrive automatikusan feltölti a fájlokat a felhőbe.
9. Az "Amend" pipa: lehetővé teszi, hogy módosítsd az utolsó commit-ot anélkül, hogy új commit-ot hoznál létre. Ez különösen akkor hasznos, ha elfelejtettél valamit hozzáadni az utolsó commit-hoz, vagy ha javítani szeretnél egy hibát az utolsó commit üzenetében.

10. Új branch létrehozása: A Git Changes ablakban kattints a New Branch gombra. Add meg az új branch nevét, majd kattints a Create Branch gombra.
11. Branch váltása: A Git Changes ablakban kattints a Branches fülre. Válaszd ki a kívánt branch-et, majd kattints a Checkout gombra.
12. Push a távoli repozitóriumba: Ha a változtatásokat egy távoli repozitóriumba is fel szeretnéd tölteni (pl. GitHub vagy Azure DevOps), kattints a Push gombra a Git Changes ablakban.
13. Pull a távoli repozitóriumból: Ha szeretnéd letölteni a legfrissebb változtatásokat a távoli repozitóriumból, kattints a Pull gombra a Git Changes ablakban.
14. Konfliktusok megoldása: Ha konfliktusok merülnek fel a merge vagy pull műveletek során, a Visual Studio megjeleníti a konfliktusokat a Git Changes ablakban. Kattints a konfliktusos fájlokra, és használd a beépített eszközöket a konfliktusok megoldásához.
