# 5. modul Összefoglalás

- Osztályok
- Osztálytagok
- Konstruktor
- Tulajdonságok
- Objektumlista
- Kivételkezelés

## Autók nyilvántartása
- Készíts egy Beolvas metódust, amely beolvassa az autók adatait egy fájlból egy List<Auto> típusú listába.
- Készíts egy KepernyoreKiir metódust, amely kiírja az autók listáját a konzolra.
- Készíts egy Rendez metódust, amely rendezi az autók listáját gyártási év szerint növekvő sorrendben.
- Készíts egy KeresesRendszamAlapjan metódust, amely bekér egy rendszámot a felhasználótól, és megkeresi az autót a listában. Ha megtalálja, kiírja az autó adatait.
- Készíts egy LegidosebbAuto metódust, amely megkeresi és kiírja a legidősebb autó adatait a listából.
- Készíts egy LegtobbetFutottAuto metódust, amely megkeresi és kiírja a legtöbbet futott autó adatait a listából.
- Készíts egy AtlagosKm metódust, amely kiszámítja és kiírja az autók átlagos futott kilométerét.
- Készíts egy AutokSzamaMarkaSzerint metódust, amely megszámolja és kiírja, hogy hány autó van minden egyes márkából.
- Készíts egy AutokListajaMarkaSzerint metódust, amely csoportosítja és kiírja az autókat márkák szerint.
- Készíts egy AutokListajaEvjaratSzerint metódust, amely csoportosítja és kiírja az autókat évjárat szerint.
- Készíts egy AutokListajaFutottKmSzerint metódust, amely csoportosítja és kiírja az autókat futott kilométer szerint.


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
    }
```
</details>
<details>
<summary>Nyiss le a Program.cs forrásáért!</summary>

### `Program.cs` példa:
```c#
    class Program
    {
        static List<Auto> Beolvas()
        {
            List<Auto> a = new List<Auto>();
            try
            {
                using(StreamReader sr = new StreamReader("autok.csv" , Encoding.UTF8))
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
        static void Main(string[] args)
        {
            List<Auto> autok = Beolvas();

            Console.WriteLine("Nyomj egy billentyűt a kilépéshez");
            Console.ReadKey();
        }
    }
```
</details>
