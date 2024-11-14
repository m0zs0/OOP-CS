# 4. modul

- Getter és setter metódusok
- Tulajdonságok (Properties)
- Lambda kifejezés
- Automatikus tulajdonság


## getter és setter
**A privát osztálymezők (pl _rendszam) elérését szabályozhatjuk vele**
- get lekérdezi az értéket
- set beállítja az értéket. Itt a rossz értékek lekezelése is megtörténhet!

Alaphelyzetben azok a tagok, melyek nincsenek eléréssel jelölve, azok privat tagok lesznek, tehát az alábbi két utasítás ekvivalens:
```c#
string rendszam;
private string rendszam;
```

Javasolt (a privat kulcsszó kiírása, mert pl a js-ben az alapértelmezés a public és) a privat valtozok '_'-al történő megjelölése:
```c#
private string _rendszam; 
```
Ha eddig eljutottunk akkor a _rendszam csak az Auto osztályban elérhető. Ez a konstruktornak (értsd konstruktorral való példányosítás) nem probléma, hiszen ő az osztályban van. 
```c#
Auto auto= new Auto("ABC-234" ,"Audi", "A4" , 2015 , 168000 );
```
Ha viszont szeretnénk a _rendszam értékét lekérni, akkor erre írhatunk az osztályban egy publikus metódust:
```c#
public string GetRendszam(){
    return this._rendszam;
}
```
Amit a Main-ban meghívva:
```c#
Console.WriteLine(auto.GetRendszam());
```
Vissza is kapjuk az "ABC-234" értéket.

Ugyanígy, ha beállítani szeretnénk a példány _rendszam mezőjét, azt egy másik publikus metódussal tehetjük meg:
```c#
public string SetRendszam(string rendszam){
    this._rendszam=rendszam;
}
```
```c#
a1.SetRendszam("ACB-123");
```

## Tulajdonság (Property)

**A tulajdonságok (properties) fontos szerepet játszanak az objektumorientált programozásban. **
- Encapsulation: Lehetővé teszik az adatok elrejtését és védelmét, szabályozott hozzáférést biztosítanak hozzájuk.
- Validation: Segítségével érvényesítési logikát adhatsz meg az adatok beállításakor vagy lekérdezésekor.
- Readability: Használatuk növeli a kód olvashatóságát és karbantarthatóságát. 
- Flexibility: A tulajdonságok lehetővé teszik a getter és setter metódusok testreszabását

Olyan gyakran kell egy példány mezőit elérni, hogy az előbbi két metódust elnevezték getter, illetve setter metódusnak és egyszerűsítést vezettek be a szintaxisukra:
Ha az IDE-ben jobbklikkelünk az adott privát változón, majd a `Quick action`/`Encapsulate field: use property` lehetőséget választjuk, akkor elkészül egy úgynevezett Property (Tulajdonság) "metódus", aminek a neve a privát mező nevével egyezik meg, csak nagybetűvel kezdődik, és tartalmaz egy get és egy set metódust:
```c#
public string Rendszam
{
    get { return _rendszam; }
    set { _rendszam = value; }
}
```
Mint látható a get könnyen értelmezhető, a set nél viszont a value a következőt jelenti.
Ha egy mező egy = (legyen egyenlő) bal oldalán szerepel akkor az egy set lesz, hiszen a jobb oldal értékét szeretném beletölteni a bal oldalon szereplő mezőbe. Kvázi a value érték annak a kifejezésnek lesz az értéke, ami az egyenlőségjel jobb oldalán szerepel. Tehát ez egy "automatikus paraméter".

## lambda operátor
A => operátor (lambda kifejezés) a getter és setter metódusokban csak akkor használható, ha a művelet egy egyszerű értékadás vagy egy egyszerű kifejezés kiértékelése. Ha a getter vagy setter metódusban összetettebb logikát kell megvalósítani, akkor hagyományos metódusokat kell használni.

Ezt a formátumot tovább egyszerűsíthetjük a lambda kifejezéssel a következő módon:
```c#
public int Rendszam { get => _rendszam; set => _rendszam = value; }
```

Sőt, ha csak ilyen egyszerű a két metódus, akkor:
```c#
public int Rendszam { get ; set; }
```

Megjegyzés: Bonyolultabb feltétel melletti beállítás formája a következő: Pl a Gyártási Év csak 1900-Mostani év -ig legyen elfogadva:
```c#
public int GyartasiEv
{
    get { return _gyartasiEv; }
    set {
        if (value >= 1900 && value <= DateTime.Now.Year)
        {
            _gyartasiEv = value;
        }
        else
        {
            throw new ArgumentException("A gyártási év nem lehet az 1900-2024 intervallumon kívül.");
        }

    }
}
```

Vagy egyszerűbben:
```c#
public int GyartasiEv
{
    get => _gyartasiEv;
    set => _gyartasiEv = value >= 1900 && value <= DateTime.Now.Year ? value : throw new ArgumentException("A gyártási év nem lehet az 1900-2024 intervallumon kívül.");
}
```


## Automatikus tulajdonság
Az automatikus tulajdonságok (auto-implemented properties) azok, amelyek automatikusan létrehoznak egy háttérmezőt a tulajdonság számára.Ez leegyszerűsíti a kódot, ha nincs szükséged extra logikára a getter és setter metódusokban. Tehát nincs megjelenített privát mező!

Megjegyzés: Amennyiben csak az egyszerű get, set metódusok lesznek használva az osztályban, akkor a privát változót sem kötelező felvenni, hanem elég csak a Tulajdonságot definiálni, és így is jól fog működni az osztályunk. Tehát a private string _rendszam; sor törölhető az osztályunkból, tekintve, hogy a legutolsó tulajdonságot tekintve nem is történik közvetlen hivatkozás _rendszam mezőre. 



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
