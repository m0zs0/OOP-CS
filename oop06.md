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
<summary>Nyiss le a Beolvas metódus forrásáért!</summary>

### `Beolvas` példa:
```c#
```
</details>

4. Készíts egy AtlagosKm metódust, amely kiszámítja és kiírja az autók átlagos futott kilométerét.
<details>
<summary>Nyiss le a Beolvas metódus forrásáért!</summary>

### `Beolvas` példa:
```c#
```
</details>

5. Készíts egy LegidosebbAuto metódust, amely megkeresi és kiírja a legidősebb autó adatait a listából.
<details>
<summary>Nyiss le a Beolvas metódus forrásáért!</summary>

### `Beolvas` példa:
```c#
```
</details>

(6. Készíts egy LegtobbetFutottAuto metódust, amely megkeresi és kiírja a legtöbbet futott autó adatait a listából.)
<details>
<summary>Nyiss le a Beolvas metódus forrásáért!</summary>

### `Beolvas` példa:
```c#
```
</details>


7. Készíts egy KeresesRendszamAlapjan metódust, amely bekér egy rendszámot a felhasználótól, és megkeresi az autót a listában. Ha megtalálja, kiírja az autó adatait.
<details>
<summary>Nyiss le a Beolvas metódus forrásáért!</summary>

### `Beolvas` példa:
```c#
```
</details>

8. Készíts egy Rendez metódust, amely rendezi az autók listáját gyártási év szerint növekvő sorrendben.
<details>
<summary>Nyiss le a Beolvas metódus forrásáért!</summary>

### `Beolvas` példa:
```c#
```
</details>

 9. Készíts egy AutokListajaMarkaSzerint metódust, amely csoportosítja és kiírja az autókat márkák szerint (darabszámukat is).
     <details>
<summary>Nyiss le a Beolvas metódus forrásáért!</summary>

### `Beolvas` példa:
```c#
```
</details>
  
(10. Készíts egy AutokListajaEvjaratSzerint metódust, amely csoportosítja és kiírja az autókat évjárat szerint.)
<details>
<summary>Nyiss le a Beolvas metódus forrásáért!</summary>

### `Beolvas` példa:
```c#
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
