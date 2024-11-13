# 3. modul

- Tulajdonságok (Properties)
- Getter és setter metódusok
- Lambda kifejezés

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