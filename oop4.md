# 4. modul

- Tulajdonságok (Properties)
- Getter és setter metódusok
- Lambda kifejezés
- Automatikus tulajdonság


## Tulajdonság (Property)

**A tulajdonságok (properties) fontos szerepet játszanak az objektumorientált programozásban. **
- Encapsulation: Lehetővé teszik az adatok elrejtését és védelmét, szabályozott hozzáférést biztosítanak hozzájuk.
- Validation: Segítségével érvényesítési logikát adhatsz meg az adatok beállításakor vagy lekérdezésekor.
- Readability: Használatuk növeli a kód olvashatóságát és karbantarthatóságát. 
- Flexibility: A tulajdonságok lehetővé teszik a getter és setter metódusok testreszabását

## getter és setter
**A privát osztálymezők (pl _rendszam) elérését szabályozhatjuk vele**
- get lekérdezi az értéket
- set beállítja az értéket. Itt a rossz értékek lekezelése is megtörténhet!


## lambda operátor
A => operátor (lambda kifejezés) a getter és setter metódusokban csak akkor használható, ha a művelet egy egyszerű értékadás vagy egy egyszerű kifejezés kiértékelése. Ha a getter vagy setter metódusban összetettebb logikát kell megvalósítani, akkor hagyományos metódusokat kell használni.

## Automatikus tulajdonság
Az automatikus tulajdonságok (auto-implemented properties) azok, amelyek automatikusan létrehoznak egy háttérmezőt a tulajdonság számára.Ez leegyszerűsíti a kódot, ha nincs szükséged extra logikára a getter és setter metódusokban. Tehát nincs megjelenített privát mező!

<details>
<summary>Nyiss le az Auto.cs forrásáért!</summary>

### `Auto.cs` példa:
```c#
    class Auto
    {
        private string _rendszam;

        public void SetRendszam(string rendszam)
        {
            this._rendszam = rendszam;
        }

        private string _marka;

        public string GetMarka()
        {
            return this._marka;
        }

        public void SetMarka(string marka)
        {
            this._marka = marka;
        }

        private string _tipus;
        
        public string Tipus {
            get { return _tipus; }
            set { _tipus = value; }
        }

        private int _evjarat;
        
        public int Evjarat { get => _evjarat; set => _evjarat = value; }

        public int futottKm;

        public Auto()
        {
        }

        public Auto(string rendszam, string marka, string tipus, int evjarat, int futottKm)
        {
            this._rendszam = rendszam;
            this._marka = marka;
            this.Tipus = tipus;
            this.Evjarat = evjarat;
            this.futottKm = futottKm;
        }
    }

```
</details>

<details>
<summary>Nyiss le a Program.cs forrásáért!</summary>

### `Program.cs` példa:
```c#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_1_Autok
{
    class Program
    {

        static void Main(string[] args)
        {
            Random rnd = new Random();
            Auto a1 = new Auto();
            // a1.rendszam = "ACB-123";
            a1.SetRendszam("ACB-123");
            //a1.marka = "Ford";
            a1.SetMarka("Ford");
            a1.Tipus = "Mustang";
            a1.Evjarat = 2000;
            a1.futottKm = 220000;

            Auto a2= new Auto("ABC-234" ,"Audi", "A4" , 2015 , 168000 );
            Console.WriteLine(a2.GetMarka());
            string seged = a1.Tipus;
            Console.WriteLine(seged);

        }
    }
}
```
</details>

https://www.youtube.com/watch?v=dzEWTcWJDn8&list=PLd5MvFV1xur5yyJ-hTmuE8vb83BTyAyBi&index=9
