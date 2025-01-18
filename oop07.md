# LINQ (Language Integrated Query)

-delegate: névtelen függvény

-lambda kifejezés

-`IEnumerable<T>` és `List<T>`

-Aggregáló függvények

-Szűrő és rendező függvények

-Generikus Típusok és Metódusok

-`List<T>` Specifikus Metódusok

-Láncolás (method chaining)


**`LINQ` egy olyan technológia, amely lehetővé teszi a különböző adatforrások (például listák, tömbök, adatbázisok) lekérdezését és manipulálását egy egységes, deklaratív<span style="text-decoration: underline" title="A deklaratív megközelítés azt jelenti, hogy a kód leírja, mit szeretnénk elérni, nem pedig hogy hogyan (imperatív: lépésről lépésre) kell azt végrehajtani.">🔍</span> szintaxissal. A LINQ lekérdezések hasonlóak az SQL lekérdezésekhez, de közvetlenül beépülnek a C# nyelvbe.**

Az `anonim függvény`-ek lehetővé teszik, hogy név nélküli függvényeket hozz létre, amelyeket közvetlenül átadhatsz más metódusoknak. A `delegate`<span style="text-decoration: underline" title="A delegate-ek lehetővé teszik, hogy metódusokat paraméterként adjunk át más metódusoknak.">🔍</span> kulcsszót kell használni egy név nélküli függvény létrehozásához.

```c#
List<int> szamok = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

//!a var később kerül megmagyarázásra!
IEnumerable<int> parosSzamok = szamok.Where(delegate(int n) {
                                    return n % 2 == 0;
                               }
                               );
```
A delegate(int n) { return n % 2 == 0; } kifejezés egy anonim (névtelen) függvényt hoz létre. A Where metódus egy iterációt végez az IEnumerable<int> gyűjteményen, és minden egyes elemet egyesével vizsgál meg. Az elemeket a függvényben n-nek nevezi el, és a kifejezés logikája alapján dönti el, hogy az adott elem megfelel-e a feltételnek (n % 2 == 0: n elem osztható-e 2-vel maradék nélkül), ha igaz a kiértékelés, akkor az (n) elem bekerül az eredmény gyűjteménybe .

**`Lambda kifejezés`-ek pedig rövid, névtelen függvények, amelyeket gyakran használnak a LINQ lekérdezésekben a feltételek és műveletek meghatározására. Például egy egyszerű LINQ lekérdezés, amely egy lista elemeit szűri, így nézhet ki:**
```c#
List<int> szamok = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        
IEnumerable<int> parosSzamok = szamok.Where(n => n % 2 == 0);
Console.WriteLine("Páros számok:");
foreach (int szam in parosSzamok)
{
    Console.WriteLine(szam);
}
```

A System.Linq névtérben található metódusok bármilyen `IEnumerable<T>` típusú gyűjteményen használhatók, beleértve a `List<T>` típusú gyűjteményeket is. A LINQ metódusok gyakran IEnumerable<T> típusú értéket (amely lehetővé teszi a gyűjtemény elemeinek iterálását) vagy egyetlen más típusú értéket (int, double, Auto) adnak vissza. A `List<T>` osztály metódusai közvetlenül `List<T>` típusú eredményt adnak vissza.
Ha egy `List<T>`-t `IEnumerable<T>`-ként használunk, akkor csak az `IEnumerable<T>` által biztosított metódusokat érhetjük el. Ha szükség van a `List<T>` speciális metódusaira, vissza kell alakítani a gyűjteményt `List<T>` típusúvá a ToList metódussal.

```c#
IEnumerable<Auto> toyotaAutok = autok.Where(auto => auto.Marka == "Toyota");
```
helyett jó a
```c#
List<Auto> toyotaAutok = autok.Where(auto => auto.Marka == "Toyota").ToList();
```
vagy a 
```c#
List<Auto> toyotaAutok = autok.FindAll(auto => auto.Marka == "Toyota");
```



## Aggregáló függvények
*Egy gyűjtemény elemeit egyetlen értékké redukálják. Néhány példa:*

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


## Szűrő és rendező függvények
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

<details>
<summary>Nyiss le néhány linq utasítás forrásáért!</summary>

### `Program.cs` példa:
```c#

List<Diak> diakok = Beolvas<Diak>("diakok.txt");
List<Auto> autok = Beolvas<Auto>("autok.csv");

//Aggregátor függvények:
Console.WriteLine($"Autok száma: {autok.Count}");
Console.WriteLine($"Autók átlagéletkora: {autok.Average(auto => DateTime.Now.Year - auto.Evjarat):f2}");
Console.WriteLine($"Legtöbbet futott autó km-e: {autok.Max(auto => auto.FutottKm)} km");
Console.WriteLine($"Legtöbbet futott autó rendszáma: {(autok.MaxBy(auto => auto.FutottKm)).Rendszam}");
Console.WriteLine($"Diákok száma: {diakok.Count}");
Console.WriteLine($"Diákok átlagéletkora: {diakok.Average(diak => DateTime.Now.Year - diak.SzuletesDatuma.Year)}"  );
Console.WriteLine($"Legfiatalabb diák életkora: {diakok.Min(diak => DateTime.Now.Year - diak.SzuletesDatuma.Year)}");
Console.WriteLine($"Legfiatalabb diák neve: {diakok.MaxBy(diak => diak.SzuletesDatuma).Nev}");

//Szűrő és rendező függvények
IEnumerable<Auto> BMWk = autok.Where(auto => auto.Marka == "BMW");
Console.WriteLine($"BMW-k darabszáma: {BMWk.Count()}");
Console.WriteLine(  $"BMW-k átlagéletkora: {BMWk.Average(auto => DateTime.Now.Year - auto.Evjarat):f2}");

IEnumerable<Auto> evjaratSzerintRendezettAutok = autok.OrderBy(auto => auto.Evjarat);
foreach (Auto auto in evjaratSzerintRendezettAutok) { 
    Console.WriteLine(auto);
}
IEnumerable<Auto> evjaratSzerintCsokkenobeRendezettAutok = autok.OrderByDescending(auto => auto.Evjarat);

IEnumerable<int> futottKmLista = autok.Select(auto => auto.FutottKm);
Console.WriteLine(  futottKmLista.ToList().Sum());

IEnumerable<IGrouping<string, Auto>> markaCsoportok = autok.GroupBy(auto => auto.Marka);
foreach (IGrouping<string, Auto> csoport in markaCsoportok) {
    Console.WriteLine($"Márka: {csoport.Key}");
    foreach (Auto auto in csoport)
    {
        Console.WriteLine(auto);
    }
}


Console.WriteLine("Vége");

static List<T> Beolvas<T>(string fajl)
{
    List<T> l = new List<T>();
    try
    {
        using (StreamReader sr = new StreamReader(fajl)) { 
            string sor;
            while ((sor = sr.ReadLine()) != null)
            {
                l.Add((T)Activator.CreateInstance(typeof(T), sor));
            }
        }
    }

    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    
    return l;
}

public class Diak
{
    public Diak(string sor)
    {
        string[] seged = sor.Split(',');
        Nev = seged[0];
        SzuletesDatuma = Convert.ToDateTime(seged[1]);
        Eredmeny = Convert.ToInt32(seged[2]);
    }

    public string Nev { get; set; }
    public DateTime SzuletesDatuma { get; set; }
    public int Eredmeny { get; set; }
}

public class Auto
{
    public Auto(string sor)
    {
        string[] seged = sor.Split(',');
        Rendszam = seged[0];
        Marka = seged[1];
        Tipus = seged[2];
        Evjarat = Convert.ToInt32(seged[3]);
        FutottKm = Convert.ToInt32(seged[4]);
        

    }

    public string Rendszam { get; set; }
    public string Marka { get; set; }
    public string Tipus { get; set; }
    public int FutottKm { get; set; }
    public int Evjarat { get; set; }

    public override string? ToString()
    {
        return $"  Rendszám: {this.Rendszam}, Márka: {this.Marka}, Típus: {this.Tipus}, Futott km: {this.FutottKm}, Évjárat: {this.Evjarat}"; 
    }
}

```
</details>

## `List<T>` Specifikus Metódusok

`Add`: Egy elemet ad a lista végéhez.
```c#
autok.Add(new Auto ( FutottKm = 30000, Evjarat = 2021 ));
```
`AddRange`: Több elemet ad a lista végéhez.
```c#
autok.AddRange(new List<Auto> { new Auto ( FutottKm = 25000, Evjarat = 2019 ), new Auto ( FutottKm = 18000, Evjarat = 2020 ) });
```
`Insert`: Egy elemet szúr be a lista adott pozíciójára.
```c#
autok.Insert(1, new Auto ( FutottKm = 22000, Evjarat = 2016 ));
```
`InsertRange`: Több elemet szúr be a lista adott pozíciójára.
```c#
autok.InsertRange(1, new List<Auto> { new Auto ( FutottKm = 21000, Evjarat = 2017 ), new Auto ( FutottKm = 23000, Evjarat = 2018 ) });
```
`Remove`: Eltávolítja az első előfordulását egy adott elemnek a listából.
```c#
autok.Remove(someAuto);
```
`RemoveAt`: Eltávolítja a listából az adott indexen lévő elemet.
```c#
autok.RemoveAt(2);
```
`RemoveRange`: Eltávolítja a listából az adott tartományban lévő elemeket.
```c#
autok.RemoveRange(1, 2);
```
`Clear`: Eltávolítja az összes elemet a listából.
```c#
autok.Clear();
```
`Sort`: Rendezési műveletet hajt végre a listán.
```c#
autok.Sort((a1, a2) => a1.Evjarat.CompareTo(a2.Evjarat));
```
`Reverse`: Megfordítja a lista elemeinek sorrendjét.
```c#
autok.Reverse();
```
`BinarySearch`: Keresést végez egy rendezett listában.
```c#
int index = autok.BinarySearch(someAuto, new AutoComparer());
```
`Find`: Megkeresi az első elemet, amely megfelel egy feltételnek.
```c#
Auto auto = autok.Find(a => a.Marka == "Toyota");
```
`FindAll`: Megkeresi az összes elemet, amely megfelel egy feltételnek.
```c#
List<Auto> toyotaAutok = autok.FindAll(a => a.Marka == "Toyota");
```
`FindIndex`: Megkeresi az első olyan elem indexét, amely megfelel egy feltételnek.
```c#
int index = autok.FindIndex(a => a.Marka == "Toyota");
```
`FindLast`: Megkeresi az utolsó elemet, amely megfelel egy feltételnek.
```c#
Auto auto = autok.FindLast(a => a.Marka == "Toyota");
```
`FindLastIndex`: Megkeresi az utolsó olyan elem indexét, amely megfelel egy feltételnek.
```c#
int index = autok.FindLastIndex(a => a.Marka == "Toyota");
```

#Példák

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
Írassuk ki márkák alapján, hogy hány autót tartunk nyilván.
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
vagy (method chaining-el vagy láncolással)
```c#
public class MarkaSzam
{
    public string Marka { get; set; }
    public int Szam { get; set; }
}

IEnumerable<MarkaSzam> markaAutokSzama = a.GroupBy(auto => auto.Marka)
                                           .Select(group => new MarkaSzam { Marka = group.Key, Szam = group.Count() });

foreach (MarkaSzam item in markaAutokSzama)
{
    Console.WriteLine($"{item.Marka}: {item.Szam} db");
}
```

