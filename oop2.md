# 2. modul

- Static mező használata
- Paraméteres konstruktor
- ToString override
- Ellenőrzött adatbevitel billentyűzetről (+kivételkezelés)
- Programozási tételek megvalósítása

## Állatok
Készíts egy C# konzolos alkalmazást, amely különböző állatok adatait kezeli. Az alkalmazásnak a következő funkciókat kell megvalósítania:

-**Adatfelvitel**: Kérjen be a felhasználótól különböző állatok adatait, amíg az Enter billentyűt nem nyomja meg üres bemenetként. Az adatok a következők legyenek: Faj neve, Az állat lábainak száma, A kifejlett hím egyed átlagos súlya kg-ban, Védett-e az állat (igen/nem)

-**Adatkiírás**: Listázza ki az összes megadott állat adatait.

-**Faj adatainak keresése**:  Kérjen be egy fajnevet, és keresse meg az adott faj adatait. Ha megtalálja, írja ki az adatokat, ha nem, jelezze, hogy nincs találat.

-**Védett fajok listázása**: Listázza ki az összes védett állatot.

-**A legnehezebb faj kiírása**: Írja ki a legnehezebb állat adatait.

-**Kilépés**: Lehetővé teszi a programból való kilépést.

<details>
<summary>Nyiss le az Allat.cs forrásáért!</summary>

### `Allat.cs` példa:
```c#
internal class Allat
    {
        public static Allat legnehezebbAllat;

        public string nev;
        public int labakSzama;
        public double atlagosSuly;
        public bool vedett;

        public Allat(string nev, int labakSzama, double atlagosSuly, bool vedett)
        {
            this.nev = nev;
            this.labakSzama = labakSzama;
            this.atlagosSuly = atlagosSuly;
            this.vedett = vedett;

            //Már az új példány létrehozásakor eltároljuk a legnehezebb állat példányt, így a LegnehezebbFajKiirasa() fgv nagyon leegyszerűsödik.
            if (legnehezebbAllat == null || atlagosSuly > legnehezebbAllat.atlagosSuly)
            {
                legnehezebbAllat = this;
            }
        }

        public override string ToString()
        {
            return $"Név: {nev}, Lábak száma: {labakSzama}, Átlagos súly: {atlagosSuly} kg, Védett: {vedett}";
        }
    }

```
</details>

<details>
<summary>Nyiss le a Main() forrásáért!</summary>

### `Main` példa:
```c#
static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            List<Allat> allatok = new List<Allat>();
            while (true)
            {
                Console.WriteLine("1. Adatfelvitel");
                Console.WriteLine("2. Adatkiírás");
                Console.WriteLine("3. Faj adatainak keresése");
                Console.WriteLine("4. Védett fajok listázása");
                Console.WriteLine("5. A legnehezebb faj kiírása");
                Console.WriteLine("6. Kilépés");
                Console.Write("Válassz egy opciót:");
                
                char valasztas = Console.ReadKey(true).KeyChar;
                Console.WriteLine();

                switch (valasztas)
                {
                    case '1':
                        Adatfelvitel(allatok);
                        break;
                    case '2':
                        Adatkiiras(allatok);
                        break;
                    case '3':
                        FajKeresese(allatok);
                        break;
                    case '4':
                        VedettFajokListazasa(allatok);
                        break;
                    case '5':
                        LegnehezebbFajKiirasa();
                        break;
                    case '6':
                        Console.WriteLine("Nyomj egy billentyűt a kilépéshez!");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Érvénytelen választás, próbáld újra.");
                        break;
                }

            }
        }
```
</details>

<details>
<summary>Nyiss le az Adatfelvitel() forrásáért!</summary>

### `Adatfelvitel()` példa:
```c#
        static void Adatfelvitel(List<Allat> allatok)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Add meg a faj nevét (vagy nyomj Entert a befejezéshez):");
                    string nev = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(nev))
                        break;

                    Console.WriteLine("Add meg az állat lábainak számát:");
                    if (!int.TryParse(Console.ReadLine(), out int labakSzama))
                    {
                        Console.WriteLine("Érvénytelen számformátum. Próbáld újra.");
                        continue;
                    }

                    Console.WriteLine("Add meg a kifejlett hím egyed átlagos súlyát kg-ban:");
                    if (!double.TryParse(Console.ReadLine(), out double atlagosSuly))
                    {
                        Console.WriteLine("Érvénytelen számformátum. Próbáld újra.");
                        continue;
                    }

                    Console.WriteLine("Védett? (i/n):");
                    char vedettInput = Console.ReadKey(false).KeyChar;
                    bool vedett = vedettInput == 'i' ? true : vedettInput == 'n' ? false : throw new ArgumentException("Érvénytelen válasz.");
                    Console.WriteLine();

                    allatok.Add(new Allat(nev, labakSzama, atlagosSuly, vedett));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hiba történt: {ex.Message}. Próbáld újra.");
                }
            }
        }


```
</details>

<details>
<summary>Nyiss le az Adatkiiras() forrásáért!</summary>

### `Adatkiiras()` példa:
```c#
        static void Adatkiiras(List<Allat> allatok)
        {
            Console.WriteLine("\nMegadott fajok:");
            if (allatok.Count > 0)
            {
                foreach (Allat allat in allatok)
                {
                    //Használjuk az override-olt ToString() -et, ki sem kell írni a ToString() függvényt mert így is az hívódik meg 
                    Console.WriteLine(allat);
                }
            }
            else
            {
                Console.WriteLine("Nincs találat.");
            }
        }

```
</details>


<details>
<summary>Nyiss le a FajKeresese() forrásáért!</summary>

### `FajKeresese()` példa:
```c#
        static void FajKeresese(List<Allat> allatok)
        {
            Console.Write("Add meg a keresett faj nevét: ");
            string keresettNev = Console.ReadLine();
            Allat talalat = null;

            foreach (Allat allat in allatok)
            {
                if (allat.nev.Equals(keresettNev, StringComparison.OrdinalIgnoreCase))
                {
                    talalat = allat;
                    break;
                }
            }

            if (talalat != null)
            {
                Console.WriteLine("Talált faj:");
                Console.WriteLine(talalat);
            }
            else
            {
                Console.WriteLine("Nincs találat.");
            }
        }


```
</details>


<details>
<summary>Nyiss le a VedettFajokListazasa() forrásáért!</summary>

### `VedettFajokListazasa()` példa:
```c#
        static void VedettFajokListazasa(List<Allat> allatok)
        {
            Console.WriteLine("Védett fajok:");
            List<Allat> vedettFajok = new List<Allat>();
            //List<Allat> vedettFajok = allatok.FindAll(a => a.vedett);

            foreach (Allat allat in allatok)
            {
                if (allat.vedett)
                {
                    vedettFajok.Add(allat);
                }
            }

            if (vedettFajok.Count > 0)
            {
                Console.WriteLine("Védett fajok:");
                foreach (Allat allat in vedettFajok)
                {
                    Console.WriteLine(allat);
                }
            }
            else
            {
                Console.WriteLine("Nincs találat.");
            }
        }


```
</details>


<details>
<summary>Nyiss le a LegnehezebbFajKiirasa() forrásáért!</summary>

### `LegnehezebbFajKiirasa()` példa:
```c#
        static void LegnehezebbFajKiirasa()
        {
            if (Allat.legnehezebbAllat != null)
            {
                Console.WriteLine("A legnehezebb faj:");
                Console.WriteLine(Allat.legnehezebbAllat);
            }
            else
            {
                Console.WriteLine("Nincs megadott faj.");
            }
        }

```
</details>

