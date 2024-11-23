# 1. modul Az osztály tagjai

- Példányszintű tagok
- Osztályszintű tagok
- Osztálydeklaráció
- Osztály tagjainak elérése


## Példányszintű tagok

- **Példányszintű tagok**: mező és metódus. Példányhoz rendelve tudjuk meghívni

```c#
    double[] d = new double[5];
    List<int> e = new List<int>();
    Random rnd = new Random();

    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine(rnd.Next(1, 3));
    }

    // Az e példánynak hívjuk meg az indexOf-ját
    e.IndexOf(3); //A 3-as elem indexe, vagy -1 ha nincs
```

## Osztályszintű tagok
- **Osztályszintű tagok**: `static` mező és `static` metódus. Osztályhoz rendelve

```c#
    //Tömb esetén az osztály IndexOf-ját hívjuk meg
    Array.IndexOf(d, 3);
```

## Osztálydeklaráció
Az objektumorientált programozás (OOP) négy alapelve a következő:

- Encapsulation (Adat elrejtés): Az adatok és a hozzájuk tartozó műveletek egy egységbe (objektumba) zárása. Ez segít az adatok védelmében és a kód modularitásának növelésében.
- Inheritance (Öröklődés): Lehetővé teszi, hogy egy új osztály (gyermek osztály) örökölje egy meglévő osztály (szülő osztály) tulajdonságait és metódusait. Ez újrafelhasználhatóvá teszi a kódot és megkönnyíti a bővítést.
- Polymorphism (Polimorfizmus): Az a képesség, hogy különböző objektumok ugyanazt a metódust különböző módon valósítsák meg. Ez rugalmasságot biztosít a kód számára.
- Abstraction (Absztrakció): Az adatok és a műveletek elrejtése a felhasználó elől, csak a lényeges információk megjelenítése. Ez egyszerűsíti a komplex rendszerek kezelését.

Deklaráció:
  - Program.cs-ben a class Program {} mellé,
  - Külön állományba (Solution Explorer/Project hm-je/Add/Class),

```c#
    class TesztOsztaly {
        //példányszintű tagok (mező, metódus) példányhoz rendelve tudjuk meghívni
        int szam1 = 15;      
        void OsszegKiir()
        {
            Console.WriteLine("Az összeg: " + (szam1 + szam2));
            this.szam1 = 11;
            this.szam2 = 22;
            SzorzatKiir();
            this.SzorzatKiir();
        }

        //osztályszintű tagok (static mező, static metódus) osztályhoz rendelve tudjuk meghívni
        static int szam2 = 24;
        static void SzorzatKiir()
        {
            Console.WriteLine("A szorzat: " + (szam1 * szam2));
            this.szam1 = 11;
            this.szam2 = 22;
            OsszegKiir();
            this.OsszegKiir();
        }
        
    }
```

## Osztály tagjainak elérése

### 1. kör példa:
```c#
    TesztOsztaly.
```
-Nem látszik semmi

### 2. kör példa:
-a két metódus elé írjunk `public`-ot, 
-ekkor már a `SzorzatKiir()` metódus fog látszani a `TesztOsztaly.` -ra

### 3. kör példa:
-Példányosítsunk egy to példányt
```c#
   TesztOsztaly to = new TesztOsztaly();
```
-Példányosítsunk egy to példányt
-Ekkor a `to.` -ra az `OsszegKiir()` fog látszani

### 4. kör:
**Az osztályok tagjainak elérési (hozzáférési) szintjei**:

-private   => csak az adott osztályon belülről érhetjük el (default)

-public    => a névtéren belül bárhonnan elérhetjük

-protected => az osztályon kívül nem elérhetők, de a gyermek(utód)osztályból igen

-internal  => a program osztályaiból lehet elérni

-protected internal => programon belülről, vagy az utódosztályából érhető el


-példányszintű mezőt a példányszintű metódus látja (`this`: példányra hivatkozik, de `this` nélkül is jó)  `szam1`
-osztályszintű tagot a példányszintű metódus látja (`this` esetén hiba, enélkül megy a dolog) `szam2`, `SzorzatKiir()`
-példányszintű tagot az osztályszintű tag nem látja
            


<details>
<summary>Nyiss le a forrásért!</summary>

### `Program.cs` példa:

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_1
{
    /*
     Az osztályok tagjainak elérési (hozzáférési) szintjei:
    -private   => csak az adott osztályon belülről érhetjük el (default)
    -public    => a névtéren belül bárhonnan elérhetjük
    -protected => az osztályon kívül nem elérhetők, de a gyermek(utód)osztályból igen
    -internal  => a program osztályaiból lehet elérni
    -protected internal => programon belülről, vagy az utódosztályából érhető el
     
     
     */
    class TesztOsztaly {
        //példányszintű tagok (mező, metódus) példányhoz rendelve tudjuk meghívni
        int szam1 = 15;      
        public void OsszegKiir()
        {
            Console.WriteLine("Az összeg: " + (szam1 + szam2));
            this.szam1 = 11;
            this.szam2 = 22;
            SzorzatKiir();
            this.SzorzatKiir();
        }

        //osztályszintű tagok (static mező, static metódus) osztályhoz rendelve tudjuk meghívni
        static int szam2 = 24;
        static void SzorzatKiir()
        {
            Console.WriteLine("A szorzat: " + (szam1 * szam2));
            this.szam1 = 11;
            this.szam2 = 22;
            OsszegKiir();
            this.OsszegKiir();
        }
        
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //https://www.youtube.com/watch?v=tMjsRF4vmw0&list=PL0-s1rSpvk00JjRXHNlEeNxpVxKiFYPGq&index=1
            double[] d = new double[5];
            List<int> e = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(rnd.Next(1, 3));
            }

            
            // Az e példánynak hívjuk meg az indexOf-ját
            e.IndexOf(3); //A 3-as elem indexe, vagy -1 ha nincs

            //Tömb esetén az osztály IndexOf-ját hívjuk meg
            Array.IndexOf(d, 3);

            //Tesztosztály
            //1. körben nem látszik semmi:
            //TesztOsztaly.

            //2. kör: a két metódus elé írjunk publicot, ekkor már a SzorzatKiir() metódus fog látszani a TesztOsztaly. -ra

            //3. kör: Példányosítsunk egy to példányt
            TesztOsztaly to = new TesztOsztaly();
            //ekkor a to. -ra az OsszegKiir() fog látszani

            //4. kör: Az osztályon belüli láthatóságok:
            //-példányszintű mezőt a példányszintű metódus látja (this: példányra hivatkozik, de this nélkül is jó)  szam1
            //-osztályszintű tagot a példányszintű metódus látja (this esetén hiba, enélkül megy a dolog) szam2, SzorzatKiir()
            //-példányszintű tagot az osztályszintű tag nem látja
            
            Console.ReadKey();

        }
    }
}


```

</details>

https://www.youtube.com/watch?v=tMjsRF4vmw0&list=PL0-s1rSpvk00JjRXHNlEeNxpVxKiFYPGq&index=1
