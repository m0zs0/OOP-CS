# 6. modul Összefoglalás

- Osztályok
- Osztálytagok
- Konstruktor
- Tulajdonságok
- Objektumlista
- Kivételkezelés

## Autók nyilvántartása
1. Készíts egy Auto osztályt
  - az alábbi adattagokkal: rendszam, marka, tipus, evjarat, futottKm
  - az evjarat-mezőbe csak 1900-at vagy azutánit fogadjon el
  - a ToString metódust definiáld újra úgy, hogy a példány összes mezőjét írja ki

<details>
<summary>Nyiss le az Auto.cs forrásáért!</summary>

### `Auto.cs` példa:
```c#
class Auto
    {
        string _rendszam;
        string _marka;
        string _tipus;
        int _evjarat;
        int _futottKm;

        public Auto(string rendszam, string marka, string tipus, int evjarat, int futottKm)
        {
            Rendszam = rendszam;
            Marka = marka;
            Tipus = tipus;
            Evjarat = evjarat;
            FutottKm = futottKm;
        }

        public string Rendszam { get => _rendszam; set => _rendszam = value; }
        public string Marka { get => _marka; set => _marka = value; }
        public string Tipus { get => _tipus; set => _tipus = value; }
        public int Evjarat {
            get => _evjarat;
            set
            {
                if (value>=1900 && value<=DateTime.Now.Year)
                {
                    _evjarat = value;
                }
                else
                {
                    throw new ArgumentException("Az évjárat kívül esik a megadható tartományon");
                }
            }
        }
        public int FutottKm { get => _futottKm; set => _futottKm = value; }

        public override string ToString()
        {
            return $"{this.Rendszam}, {this.Marka}, {this.Tipus}, {this.Evjarat}, {this.FutottKm}";
        }
    }
}
```
</details>
2. Készíts egy Beolvas metódust, amely beolvassa az autók adatait egy fájlból egy List<Auto> típusú listába.
<details>
<summary>Nyiss le a Beolvas metódus forrásáért!</summary>

### `Beolvas` példa:
```c#
/// <summary>
/// Beolvassa a fájl sorait listában Auto példányokba
/// </summary>
static List<Auto> Beolvas()
{
    List<Auto> a = new List<Auto>();
    try
    {
        using (StreamReader sr = new StreamReader("autok.csv", Encoding.UTF8))
        {
            string sor;
            while ((sor = sr.ReadLine()) != null)
            {
                string[] seged = sor.Split(',');
                a.Add(new Auto(seged[0], seged[1], seged[2], Convert.ToInt32(seged[3]), Convert.ToInt32(seged[4])));
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Hiba: {ex.Message}");
        Console.ReadKey();
        Environment.Exit(1);
    }
    return a;
}
```
</details>
3. Készíts egy KepernyoreKiir metódust, amely kiírja az autók listáját a konzolra.
<details>
<summary>Nyiss le a KepernyoreKiir metódus forrásáért!</summary>

### `KepernyoreKiir` példa:
```c#
/// <summary>
/// Kiírja képernyőre az autok lista tartalmat
/// </summary>
/// <param name="a">autok</param>
/// <param name="cim">rendezés előtt vagy után</param>
static void KepernyoreKiir(List<Auto> a, string cim)
{
    Console.WriteLine($"\n{cim}");
    foreach (Auto auto in a)
    {
        Console.WriteLine(auto);
    }
   
    //a.ForEach(x => Console.WriteLine(x));
}
```
</details>

4. Készíts egy AtlagosKm metódust, amely kiszámítja és kiírja az autók átlagos futott kilométerét.
<details>
<summary>Nyiss le a AtlagosKm metódus forrásáért!</summary>

### `AtlagosKm` példa:
```c#
static void AtlagosKm(List<Auto> a)
{
    double osszeg = 0;
    foreach (Auto auto in a)
    {
        osszeg += auto.FutottKm;
    }
    double atlag = osszeg / a.Count();
    //double atlag = a.Average(auto => auto.FutottKm);
    Console.WriteLine($"Az autók átlagos futott km: {atlag:f2}");
}
```
</details>

5. Készíts egy LegidosebbAuto metódust, amely megkeresi és kiírja a legidősebb autó adatait a listából.
<details>
<summary>Nyiss le a LegidosebbAuto metódus forrásáért!</summary>

### `LegidosebbAuto` példa:
```c#
static void LegidosebbAuto(List<Auto> a)
{
    //Auto legidosebbAuto = a.MinBy(auto => auto.Evjarat);
    Auto legidosebbAuto = a.OrderBy(auto => auto.Evjarat).FirstOrDefault();
    Console.WriteLine($"\nLegidősebb autó adatai: {legidosebbAuto}");
}
```
</details>

(6. Készíts egy LegtobbetFutottAuto metódust, amely megkeresi és kiírja a legtöbbet futott autó adatait a listából.)
<details>
<summary>Nyiss le a LegtobbetFutottAuto metódus forrásáért!</summary>

### `LegtobbetFutottAuto` példa:
```c#
static void LegtobbetFutottAuto(List<Auto> a)
{
    //Auto legtobbetFutottAuto = a.MaxBy(auto => auto.FutottKm);
    Auto legtobbetFutottAuto = a.OrderByDescending(auto => auto.FutottKm).FirstOrDefault();
    Console.WriteLine($"\nLegtöbett futott km autó adatai: {legtobbetFutottAuto}");
}
```
</details>


7. Készíts egy KeresesRendszamAlapjan metódust, amely bekér egy rendszámot a felhasználótól, és megkeresi az autót a listában. Ha megtalálja, kiírja az autó adatait.
<details>
<summary>Nyiss le a KeresesRendszamAlapjan metódus forrásáért!</summary>

### `KeresesRendszamAlapjan` példa:
```c#
static void KeresesRendszamAlapjan(List<Auto> a)
{
    Console.Write("Kérem a rendszámot: ");
    string keresesRendszam = Console.ReadLine();
    Auto megtalaltAuto = null;
    foreach (Auto auto in a)
    {
        if (auto.Rendszam.Equals(keresesRendszam, StringComparison.OrdinalIgnoreCase))
        {
            megtalaltAuto = auto;
            break;
        }
    }
    if (megtalaltAuto == null)
    {
        Console.WriteLine("Nincs ilyen adat");
    }
    else
    {
        Console.WriteLine(megtalaltAuto);
    }
}
```
</details>

8. Készíts egy Rendez metódust, amely rendezi az autók listáját gyártási év szerint növekvő sorrendben.
<details>
<summary>Nyiss le a Rendez metódus forrásáért!</summary>

### `Rendez` példa:
```c#
static void Rendez(List<Auto> a)
{
    for (int i = 0; i < a.Count-1; i++)
    {
        for (int j = i+1; j < a.Count; j++)
        {
            if (a[i].Evjarat > a[j].Evjarat)
            {
                Auto seged = a[i];
                a[i] = a[j];
                a[j] = seged;
            }
        }
    }
}
```
</details>

9. Készíts egy AutokListajaMarkaSzerint metódust, amely csoportosítja és kiírja az autókat márkák szerint (darabszámukat is).
<details>
<summary>Nyiss le a AutokListajaMarkaSzerint metódus forrásáért!</summary>

### `AutokListajaMarkaSzerint` példa:
```c#
static void AutokListajaMarkaSzerint(List<Auto> a)
{
    Console.WriteLine("\nAz autók csoportosítva márka szerint: ");
    //Csoportosítás márka szerint:
    Dictionary<string, List<Auto>> autokMarkaSzerint = new Dictionary<string, List<Auto>>();
    foreach (Auto auto in a)
    {
        if (!autokMarkaSzerint.ContainsKey(auto.Marka))
        {
            autokMarkaSzerint[auto.Marka] = new List<Auto>();
        }
        autokMarkaSzerint[auto.Marka].Add(auto);
    }
    //var autokMarkaSzerint = a.GroupBy(auto => auto.Marka);

    //Csoportok kiírása
    foreach (KeyValuePair<string, List<Auto>> markakCsoport in autokMarkaSzerint)
    {
        Console.WriteLine($"{markakCsoport.Key} ({markakCsoport.Value.Count()}db)");
        foreach (Auto csoportbeliAuto in markakCsoport.Value)
        {
            Console.WriteLine($"  {csoportbeliAuto}");
        }
    }
   
    /*foreach (var markakCsoport in autokMarkaSzerint)
    {
        Console.WriteLine(markakCsoport.Key);
        foreach (var csoportbeliAuto in markakCsoport)
        {
            Console.WriteLine($"  {csoportbeliAuto}");
        }
    }*/
}
```
</details>
  
(10. Készíts egy AutokListajaEvjaratSzerint metódust, amely csoportosítja és kiírja az autókat évjárat szerint.)
<details>
<summary>Nyiss le a AutokListajaEvjaratSzerint metódus forrásáért!</summary>

### `AutokListajaEvjaratSzerint` példa:
```c#
static void AutokListajaEvjaratSzerint(List<Auto> a)
{
    Console.WriteLine("\nAz autók csoportosítva évjárat szerint: ");
    //Csoportosítás márka szerint:
    var autokEvjaratSzerint = a.GroupBy(auto => auto.Evjarat);

    //Csoportok kiírása
    foreach (var evjaratCsoport in autokEvjaratSzerint)
    {
        Console.WriteLine(evjaratCsoport.Key);
        foreach (var csoportbeliAuto in evjaratCsoport)
        {
            Console.WriteLine($"  {csoportbeliAuto}");
        }
    }
}
```
</details>

(- Készíts egy AutokListajaFutottKmSzerint metódust, amely csoportosítja és kiírja az autókat futott kilométer szerint.)



<details>
<summary>Nyiss le a Program.cs forrásáért!</summary>

### `Program.cs` példa:
```c#
static void Main(string[] args){
    List<Auto> autok = Beolvas();
    KepernyoreKiir(autok, "Rendezés előtt");
    Rendez(autok);
    KepernyoreKiir(autok, "Rendezés után");
    LegidosebbAuto(autok);
    LegtobbetFutottAuto(autok);
    KeresesRendszamAlapjan(autok);
    AtlagosKm(autok);
    AutokListajaMarkaSzerint(autok);
    AutokListajaEvjaratSzerint(autok);

    Console.WriteLine("Nyomj egy billentyűt a kilépéshez");
    Console.ReadKey();
}    

```
</details>


## Elméleti kérdések
1. Mi az objektumorientált programozás (OOP) alapelvei?
2. Mit jelent az enkapszuláció az OOP-ban?
3. Mi a különbség a példány és a statikus tagok között?
4. Hogyan definiálunk tulajdonságokat (properties) C#-ban?
5. Mi az automatikus tulajdonság (auto-implemented property)?
6. Hogyan működik a getter és a setter C#-ban?
7. Mi a lambda kifejezés, és hogyan használható a getter és setter metódusokban?
8. Hogyan lehet érvényesítési logikát hozzáadni egy tulajdonsághoz?
9. Mi a DateTime osztály, és mire használható?
10. Hogyan lehet létrehozni egy DateTime objektumot a jelenlegi dátummal és idővel?
11. Hogyan lehet formázni egy DateTime objektumot különböző formátumokban?
12. Hogyan lehet kiszámítani a két DateTime objektum közötti különbséget?
13. Mi a különbség a privát és a nyilvános (private és public) tagok között?
14. Hogyan lehet egy osztályban privát mezőket (fields) definiálni?
15. Mi a konstruktor, és hogyan használható C#-ban?
16. Hogyan lehet felüldefiniálni a ToString() metódust egy osztályban?
