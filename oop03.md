# 3. modul

- DateTime osztály
- this.szuletesiDatum.ToString("yyyy.MM.dd")
- Karakterkódolási hiba megoldása:
  
    ```c#
    Console.OutputEncoding = System.Text.Encoding.Unicode;
    Console.InputEncoding = System.Text.Encoding.Unicode;
    ```
- DateTime.Now.Year
- d.szuletesiDatum.Year
- Beolvasás file-ból

## Diákok
Készíts programot, mely a diákok nevét, születési helyét és születési dátumát kezeli. 
- Olvasd be a diákok adatait fájlból egy alkalmas adatszerkezetbe
- Írasd ki a diákok adatait
- Kérj be egy nevet és add meg a diák adatait
- Add meg legöregebb diák nevét és korát


<details>
<summary>Nyiss le a Diak.cs forrásáért!</summary>

### `Diak.cs` példa:
```c#
internal class Diak
    {
        public static Diak legoregebbDiak;

        public string nev;
        public string szuletesiHely;
        public DateTime szuletesiDatum; // Excel-szerű dátum sorszám

        public Diak() { }

        public Diak(string nev, string szuletesiHely, DateTime szuletesiDatum)
        {
            this.nev = nev;
            this.szuletesiHely = szuletesiHely;
            this.szuletesiDatum = szuletesiDatum;

            if (legoregebbDiak == null || this.szuletesiDatum < legoregebbDiak.szuletesiDatum)
            {
                legoregebbDiak = this;
            }

        }

        public override string ToString()
        {
            return $"Név: {this.nev}, Születési hely: {this.szuletesiHely}, Születési dátum: {this.szuletesiDatum.ToString("yyyy.MM.dd")}";
        }
    }
```
</details>

<details>
<summary>Nyiss le a Program.cs forrásáért!</summary>

### `Program.cs` példa:
```c#
internal class Program
    {
        static int Kor(Diak d) {
            return DateTime.Now.Year - d.szuletesiDatum.Year;
        }
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            List<Diak> diakok = new List<Diak>();

            // Beolvasás
            using (var sr = new StreamReader("diakok.csv", Encoding.UTF8))
            {
                string sor;
                while ((sor = sr.ReadLine()) != null)
                {
                    string[] seged = sor.Split(',');

                    /*Diak diak = new Diak();
                    diak.nev = seged[0];
                    diak.szuletesiHely = seged[1];
                    diak.szuletesiDatum = seged[2];

                    diakok.Add(diak);*/
                    int ev = int.Parse(seged[2].Substring(0, 4));
                    int honap = int.Parse(seged[2].Substring(5, 2));
                    int nap = int.Parse(seged[2].Substring(8, 2));

                    diakok.Add(new Diak(seged[0], seged[1], new DateTime(ev, honap, nap)));
                }
            }

            // Kiírás
            Console.WriteLine("Beolvasott diákok adatai:");
            foreach (Diak diak in diakok)
            {
                Console.WriteLine(diak.ToString());
            }

            // Név bekérése és életkor kiszámítása
            Console.Write("\nAdj meg egy nevet: ");
            string keresettNev = Console.ReadLine();
            Diak keresettDiak = null;

            foreach (Diak diak in diakok)
            {
                if (diak.nev.Trim().ToLower() == keresettNev.Trim().ToLower())
                {
                    keresettDiak = diak;
                    break;
                }
            }

            if (keresettDiak != null)
            {
                Console.WriteLine($"{keresettNev} {Kor(keresettDiak)} éves.");
            }
            else
            {
                Console.WriteLine("Nincs ilyen nevű diák.");
            }

            // Legöregebb diák megkeresése

            if (Diak.legoregebbDiak != null)
            {
                Console.WriteLine($"\nA legöregebb diák: {Diak.legoregebbDiak.nev} kora: {Kor(Diak.legoregebbDiak)}");
            }
            Console.WriteLine("Nyomj egy billentyűt a kilépéshez!");
            Console.ReadKey();
        }
    }

```
</details>
