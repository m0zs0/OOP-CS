# LINQ és a List<T> függvényei
# LINQ (Language Integrated Query)

**`LINQ` egy olyan technológia, amely lehetővé teszi a különböző adatforrások (például listák, tömbök, adatbázisok) lekérdezését és manipulálását egy egységes, deklaratív szintaxissal. A LINQ lekérdezések hasonlóak az SQL lekérdezésekhez, de közvetlenül beépülnek a C# nyelvbe.**

**`Lambda kifejezés`-ek pedig rövid, névtelen függvények, amelyeket gyakran használnak a LINQ lekérdezésekben a feltételek és műveletek meghatározására. Például egy egyszerű LINQ lekérdezés, amely egy lista elemeit szűri, így nézhet ki:**

```c#
int evenNumbers = numbers.Where(n => n % 2 == 0);
```

A C# függvények (mint például MinBy, Sum, Average) és a LINQ (Language Integrated Query) függvények (mint például Where, OrderBy) mind a LINQ részei, de különböző célokat szolgálnak és különböző típusú műveleteket végeznek.

## Beépített C# Függvények (Aggregáló függvények)
*Ezek a függvények általában aggregáló műveleteket végeznek, amelyek egy gyűjtemény elemeit egyetlen értékké redukálják. Néhány példa:*

`Sum`: Összeadja a gyűjtemény elemeit.
```c#
double osszesFutottKm = autok.Sum(auto => auto.FutottKm);
```
`Average`: Kiszámítja a gyűjtemény elemeinek átlagát.
```c#
double atlagosFutottKm = autok.Average(auto => auto.FutottKm);
```
`Min`: Kiválasztja a legkisebb értéket a gyűjteményből.
```c#
double legkevesebbFutottKm = autok.Min(auto => auto.FutottKm);
```
`Max`: Kiválasztja a legnagyobb értéket a gyűjteményből.
```c#
double legtobbFutottKm = autok.Max(auto => auto.FutottKm);
```
`Count`: Megszámolja a gyűjtemény elemeit.
```c#
int autoSzam = autok.Count();
```
`MinBy`: Kiválasztja a legkisebb értékkel rendelkező elemet egy adott kulcs alapján.
```c#
Auto legidosebbAuto = autok.MinBy(auto => auto.Evjarat);
```
`MaxBy`: Kiválasztja a legnagyobb értékkel rendelkező elemet egy adott kulcs alapján.
```c#
Auto legujabbAuto = autok.MaxBy(auto => auto.Evjarat);
```


## LINQ Függvények (Szűrő és rendező függvények)
*Ezek a függvények általában szűrési, rendezési és egyéb transzformációs műveleteket végeznek a gyűjtemény elemein. Néhány példa:*

`Where`: Szűri a gyűjtemény elemeit egy feltétel alapján.
```c#
IEnumerable<Auto> ujAutok = autok.Where(auto => auto.Evjarat > 2017);
```
ahol az IEnumerable<Auto> egy generikus interfész, amely a C# nyelvben egy olyan gyűjteményt reprezentál, amely elemek sorozatát tartalmazza, és amelyeken végig lehet iterálni.az `IEnumerable` az interfész, amely meghatározza az iterálható gyűjtemények alapvető viselkedését, az `<Auto>` a generikus típusparaméter, amely meghatározza, hogy a gyűjtemény milyen típusú elemeket tartalmaz. Ebben az esetben az Auto típusú elemeket.

A `generikus` kifejezés a programozásban olyan típusokat és metódusokat jelöl, amelyek típusparaméterekkel dolgoznak, így különböző típusokkal is használhatók anélkül, hogy újra kellene írni őket. A generikus programozás lehetővé teszi az általános és újrafelhasználható kód írását, amely különböző típusokkal működhet.

**Generikus Típusok és Metódusok**

**Generikus Típusok**: Olyan osztályok vagy struktúrák, amelyek típusparamétereket használnak. Például a `List<T>` egy generikus típus, ahol a T helyére bármilyen típus behelyettesíthető.

```c#
List<int> szamok = new List<int>();
szamok.Add(1);
szamok.Add(2);

List<string> szavak = new List<string>();
szavak.Add("hello");
szavak.Add("world");
```

Ebben a példában a List<T> generikus típus, ahol a T helyére az int és a string típusok kerültek.

**Generikus Metódusok**: Olyan metódusok, amelyek típusparamétereket használnak. Ezek a metódusok különböző típusokkal hívhatók meg anélkül, hogy újra kellene írni őket.

```c#
public T GetFirstElement<T>(List<T> lista)
{
    return lista[0];
}

List<int> szamok = new List<int> { 1, 2, 3 };
int elsoSzam = GetFirstElement(szamok);

List<string> szavak = new List<string> { "hello", "world" };
string elsoSzo = GetFirstElement(szavak);
```

Ebben a példában a GetFirstElement metódus generikus, és bármilyen típusú listával használható.


`OrderBy`: Rendez egy gyűjteményt egy adott kulcs alapján.
```c#
IOrderedEnumerable<Auto> rendezettAutok = autok.OrderBy(auto => auto.Evjarat);
```
ahol IOrderedEnumerable<Auto>: Egy rendezett gyűjtemény, amely egy rendezési művelet eredményeként jön létre, és amelyen végig lehet iterálni.

`OrderByDescending`: Rendez egy gyűjteményt csökkenő sorrendben egy adott kulcs alapján.
```c#
IOrderedEnumerable<Auto> forditottRendezettAutok = autok.OrderByDescending(auto => auto.Evjarat);
```
`Select`: Transzformálja a gyűjtemény elemeit egy új formátumba.
```c#
IEnumerable<int> futottKmLista = autok.Select(auto => auto.FutottKm);
```
`GroupBy`: Csoportosítja a gyűjtemény elemeit egy adott kulcs alapján.
```c#
IEnumerable<IGrouping<int, Auto>> evjaratCsoportok = autok.GroupBy(auto => auto.Evjarat);
```
`Join`: Két gyűjteményt kapcsol össze egy közös kulcs alapján.
```c#
public class AutoTulajdonos
{
    public Auto Auto { get; set; }
    public Tulajdonos Tulajdonos { get; set; }
}

IEnumerable<AutoTulajdonos> autokEsTulajdonosok = autok.Join(
    tulajdonosok,
    auto => auto.TulajdonosId,
    tulajdonos => tulajdonos.Id,
    (auto, tulajdonos) => new AutoTulajdonos { Auto = auto, Tulajdonos = tulajdonos }
);
```
`Distinct`: Eltávolítja a duplikált elemeket a gyűjteményből.
```c#
IEnumerable<int> egyediEvjaratok = autok.Select(auto => auto.Evjarat).Distinct();
```
`Take`: Kiválaszt egy adott számú elemet a gyűjtemény elejéről.
```c#
IEnumerable<Auto> elsoKetAuto = autok.Take(2);
```
`Skip`: Átugrik egy adott számú elemet a gyűjtemény elejéről.
```c#
IEnumerable<Auto> kettoUtan = autok.Skip(2);
```











```c#
List<Auto> a = ...
```

-a.ForEach(x => Console.WriteLine(x));

-int osszeg = a.Sum(auto => auto.FutottKm);

-double atlag = a.Average(auto => auto.FutottKm);

-int db = a.Count(auto => auto.Marka==keresettMarka);

-Auto legidosebbAuto = a.OrderBy(auto => auto.Evjarat).FirstOrDefault();

  -Auto legidosebbAuto = a.MinBy(auto => auto.Evjarat);
  
-Auto legtobbetFutottAuto = a.OrderByDescending(auto => auto.FutottKm).FirstOrDefault();
  
  -Auto legtobbetFutottAuto = a.MaxBy(auto => auto.FutottKm);

-Auto keresettAuto = a.FirstOrDefault(auto => auto.Rendszam==keresettRendszam);

vagy

```c#
Auto megtalaltAuto = null;
foreach (Auto auto in a){
   if (auto.Rendszam.Equals(keresesRendszam, StringComparison.OrdinalIgnoreCase)){
       megtalaltAuto = auto;
       break;
   }
}
if (megtalaltAuto == null){
   Console.WriteLine("Nincs ilyen adat");
}else{
   Console.WriteLine(megtalaltAuto);
}
```

-Statisztika:

```c#
IEnumerable<IGrouping<string, Auto>> autokMarkaSzerint = a.GroupBy(auto => auto.Marka);
foreach (IGrouping<string, Auto> csoport in autokMarkaSzerint){
    Console.WriteLine($"{csoport.Key}: {csoport.Count()} db");
    //itt akár foreach-el végigiteráléva ki is írathatók...
    /*foreach (Auto auto in csoport){
        Console.WriteLine($"\t{auto}");
    }*/
}
```
vagy
```c#
Dictionary<string, List<Auto>> autokMarkaSzerint = new Dictionary<string, List<Auto>>();
foreach (Auto auto in a){
   if (!autokMarkaSzerint.ContainsKey(auto.Marka)){
      autokMarkaSzerint[auto.Marka] = new List<Auto>();
   }
   autokMarkaSzerint[auto.Marka].Add(auto);
}

foreach (KeyValuePair<string, List<Auto>> markakCsoport in autokMarkaSzerint){
   Console.WriteLine($"{markakCsoport.Key} ({markakCsoport.Value.Count()}db)");
   foreach (Auto csoportbeliAuto in markakCsoport.Value){
      Console.WriteLine($"  {csoportbeliAuto}");
   }
}
```
