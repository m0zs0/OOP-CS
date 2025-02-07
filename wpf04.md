# Grid: Torpedo

## Feladat:

Solution neve: **Wpf_1_Torpedo**

Projekt leírása: 
2)
5x5-ös Játéktér: Board
A cellákba Buttonok, vagy Rectangle-ek
A hajók helyének reprezentáláshoz egy 5x5-ös mátrix (boardMx)
{ {0,0,0,0,0},
  {0,1,0,0,0},
  {0,1,0,1,1},
  {0,1,0,0,0},
  {0,0,0,0,0}}
Egy 2 és egy 3 hosszú hajó van a mátrixban
A BoardGrid celláiban lévő kontrollokhoz ugyanaz az eseménykezelő van rendelve
Az eseménykezelőben, ha még nem volt kattintva az adott kontrollon, akkor megnézzük, hogy hajót találtunk-e el, ha igen akkor azt a kontroll piros színűvé válása mutatja, ha nem akkor a kontroll kék színűvé válik.
3)
Vizsgáljuk, hogy megvolt-e már a két hajó kilövése, ha igen akkor kiírjuk, hogy hány lépésben sikerült kilőni a két hajót
4)
Legyen a Board felett egy információs panel, amelybe mindig kiírjuk, hogy Talált vagy Nem talált az adott torpedo.
5)
Ha minden hajót kilőttek, akkor álljon vissza minden alapállapotba (Board színei, változók tartalma)
Segítség a Boardon lévő kontrollokat a következő kóddal lehet bejárni:
foreach (UIElement element in Board.Children)...


+5) A hajókat véletlenszerűen helyezzük el


```c#



```
