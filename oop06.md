# 5. modul Összefoglalás

- Ismétlés: Érték/Referencia típusú változók; paraméterátadás
- Osztályok
- Osztálytagok
- Konstruktor
- Tulajdonságok
- Objektumlista
- Kivételkezelés

## 1. Érték szerinti paraméterátadás

## 1.a. Érték típusok: int, bool, double,...

Az alábbi DuplazR() nem működik helyesen:
<details>
<summary>Nyiss le a Program.cs forrásáért!</summary>

### `Program.cs` példa:
```c#
        static void Main(string[] args){
            //Érték típusok: int, bool, double
            int a = 100;
            int b = 200;
            int c = 300;

            b = a;
            c = 50;

            DuplazR(a);
        }
        
        static void DuplazR(int szam){
            szam = szam * 2;
        }

```
</details>

Az alábbi DuplazJ() helyesen működik:
<details>
<summary>Nyiss le a Program.cs forrásáért!</summary>

### `Program.cs` példa:
```c#
        static void Main(string[] args){
            //Érték típusok: int, bool, double
            int a = 100;
            int b = 200;
            int c = 300;

            b = a;
            c = 50;

            DuplazJ(a);
        }
        
        static int DuplazJ(int szam){
            szam = szam * 2;
            return szam;
        }

```
</details>

https://www.youtube.com/watch?v=DDbWbiafroQ&list=PLd5MvFV1xur5yyJ-hTmuE8vb83BTyAyBi&index=3

## 1.b. Referencia típusok: String, Array, List, Class

<details>
<summary>Nyiss le a Program.cs forrásáért!</summary>

### `Program.cs` példa:
```c#
        static void Main(string[] args){
            //Referencia típusok: String, Array, List, Class
            int[] t1 = new int[2];
            t1[0] = 100;
            t1[1] = 200;

            int[] t2 = new int[2];
            t2[0] = t1[0]; //érték típusok közötti másolás
            t2[1] = t1[1];

            int[] t3 = t1; //referencia típusokközötti masolás elsődleges dobozok közötti értékadás, tehát címet másol

            t3[0] = 500; //t1[0] = 500;
            
            Atir(t1);  
        }
        static void Atir(int[] szamok) {
            szamok[0] = 1000;
            szamok[1] = 2000;
        }
```
</details>

https://www.youtube.com/watch?v=gOqwAgeYnAQ&list=PLd5MvFV1xur5yyJ-hTmuE8vb83BTyAyBi&index=4

## 2. Cím szerinti paraméterátadás

<details>
<summary>Nyiss le a Program.cs forrásáért!</summary>

### `Program.cs` példa:
```c#
        static void Main(string[] args){
            //Cím szerinti paraméterátadás
            int a = 100;
            int[] t1 = new int[2];
            t1[0] = 100;
            t1[1] = 200;
            
            DuplazC(ref a);
            
            AtirC(ref t1);

            int d;
            BetoltC(ref d); //ez a sor hibát ad
            BetoltO(out d);
        }
        static void DuplazC(ref int szam) {
            szam = szam * 2;
        }
        static void AtirC(ref int[] szamok){
            szamok[0] = 4000;
            szamok[1] = 8000;
        }

        static void BetoltC(ref int szam){
            szam = 2;
        }
        static void BetoltO(out int szam) {
            szam = 2;
        }

```
</details>

https://www.youtube.com/watch?v=gO6N7osCuMI&list=PLd5MvFV1xur5yyJ-hTmuE8vb83BTyAyBi&index=5


## Autók nyilvántartása
- Készíts egy Beolvas metódust, amely beolvassa az autók adatait egy fájlból egy List<Auto> típusú listába.
- Készíts egy KepernyoreKiir metódust, amely kiírja az autók listáját a konzolra.
- Készíts egy AtlagosKm metódust, amely kiszámítja és kiírja az autók átlagos futott kilométerét.
- Készíts egy LegidosebbAuto metódust, amely megkeresi és kiírja a legidősebb autó adatait a listából.

(- Készíts egy LegtobbetFutottAuto metódust, amely megkeresi és kiírja a legtöbbet futott autó adatait a listából.)
- Készíts egy KeresesRendszamAlapjan metódust, amely bekér egy rendszámot a felhasználótól, és megkeresi az autót a listában. Ha megtalálja, kiírja az autó adatait.
- Készíts egy Rendez metódust, amely rendezi az autók listáját gyártási év szerint növekvő sorrendben.
- Készíts egy AutokListajaMarkaSzerint metódust, amely csoportosítja és kiírja az autókat márkák szerint (darabszámukat is).
  
(- Készíts egy AutokListajaEvjaratSzerint metódust, amely csoportosítja és kiírja az autókat évjárat szerint.)

(- Készíts egy AutokListajaFutottKmSzerint metódust, amely csoportosítja és kiírja az autókat futott kilométer szerint.)


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
