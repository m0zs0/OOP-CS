# 6. modul BasicCalculator + Tesztelés

Készíts egy egyszerű számológép alkalmazást a BasicCalculator névtérben, amely alapvető matematikai műveleteket végez. Az alkalmazásnak támogatnia kell az összeadást, kivonást, szorzást, osztást, négyzetgyök számítást és hatványozást.

## Hozz létre egy BasicCalculator névteret (értsd projektet). `.Net 8`
### A BasicCalculator névtérben hozz létre egy Calculator osztályt.
**Hozd létre az alábbi osztályszintű metódusokat:**

-Az Add metódus két számot adjon össze.

-A Subtract metódus két számot vonjon ki egymásból.

-A Multiply metódus két számot szorozzon össze.

-A Divide metódus két számot osszon el egymással, és dobjon DivideByZeroException kivételt, ha a második szám nulla.

-A SquareRoot metódus számítsa ki egy szám négyzetgyökét, és dobjon ArgumentException kivételt, ha a szám negatív.

-A Power metódus számítsa ki az első szám hatványát a második szám alapján.


<details>
<summary>Nyiss le a Calculator.cs forrásáért!</summary>

### `Calculator.cs` példa:
```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCalculator
{
    public class Calculator
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Nem lehet nullával osztani.");
            }
            return a / b;
        }

        public static double SquareRoot(double a)
        {
            if (a < 0)
            {
                throw new ArgumentException("Negatív szám négyzetgyökét nem lehet kiszámítani.");
            }
            return Math.Sqrt(a);
        }

        public static double Power(double a, double b)
        {
            return Math.Pow(a, b);
        }
    }
}

```
</details>


### Hozd létre a főprogramot

-Amely bekér egy számot 

-Egy műveletet 

-Illetve egy második számot, ha szükség van rá (pl sqrt(szam1)-nél nincs szükség rá)

-Majd kiírja a végeredményt.


<details>
<summary>Nyiss le a Program.cs forrásáért!</summary>

### `Program.cs` példa:
```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCalculator
{
    internal class Program
    {
        static double BekerSzam(string cim)
        {
            Console.Write(cim);
            double beSzam = Convert.ToDouble(Console.ReadLine());
            return beSzam;
        }

        static string BekerMuvelet(string cim)
        {
            Console.Write(cim);
            string beMuvelet = Console.ReadLine();
            return beMuvelet;
        }
        static void Main(string[] args)
        {

            double szam1 = BekerSzam("Első szám: ");
            string muvelet = BekerMuvelet("Művelet [+, -, *, /, sqrt, ^]: ");
            double szam2 = 0;
            if (muvelet != "sqrt")
            {
                szam2 = BekerSzam("Második szám: ");
            }

            double eredmeny = 0;
            try
            {
                switch (muvelet)
                {
                    case "+":
                        eredmeny = Calculator.Add(szam1, szam2);
                        break;
                    case "-":
                        eredmeny = Calculator.Subtract(szam1, szam2);
                        break;
                    case "*":
                        eredmeny = Calculator.Multiply(szam1, szam2);
                        break;
                    case "/":
                        eredmeny = Calculator.Divide(szam1, szam2);
                        break;
                    case "sqrt":
                        eredmeny = Calculator.SquareRoot(szam1);
                        break;
                    case "^":
                        eredmeny = Calculator.Power(szam1, szam2);
                        break;
                    default:
                        Console.WriteLine("Érvénytelen művelet.");
                        return;
                }

                if (muvelet != "sqrt")
                {
                    Console.WriteLine($"{szam1}{muvelet}{szam2} = {eredmeny}");
                }
                else
                {
                    Console.WriteLine($"{muvelet}({szam1}) = {eredmeny}");
                }

                Console.WriteLine("Nyomj egy billentyűt a kilépéshez!");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba történt: {ex.Message}");
            }
        }
    }
}


```
</details>

### Hozz létre unitteszteket:
**Hozz létre egy külön tesztprojektet BasicCalculator.Tests névvel.**

-Solution Explorer/Solution 'BasicCalculator'/Add/New Project

-Test xUnit `.Net 8` BasicCalculator.Tests névvel

-A Dependencies / Add project References-ben add hozzá a BasicCalculator-t

**Írj unit teszteket az összes metódushoz az xUnit keretrendszer használatával.**

-Biztosítsd, hogy a tesztek lefedjék a normál működést és a kivételkezelést is.

**Futtasd le a teszteket**

-Test Explorer / Run All Tests


<details>
<summary>Nyiss le a UnitTest1.cs forrásáért!</summary>

### `UnitTest1.cs` példa:
```c#
namespace BasicCalculator.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Osszeadas_HelyesOsszegetAdVissza()
        {
            double eredmeny = Calculator.Add(2, 3);
            Assert.Equal(5, eredmeny);
        }

        [Fact]
        public void Kivonas_HelyesKulonbsegetAdVissza()
        {
            double eredmeny = Calculator.Subtract(5, 3);
            Assert.Equal(2, eredmeny);
        }

        [Fact]
        public void Szorzas_HelyesSzorzatotAdVissza()
        {
            double eredmeny = Calculator.Multiply(2, 3);
            Assert.Equal(6, eredmeny);
        }

        [Fact]
        public void Osztas_HelyesHanyadostAdVissza()
        {
            double eredmeny = Calculator.Divide(6, 3);
            Assert.Equal(2, eredmeny);
        }

        [Fact]
        public void Osztas_Nullaval_DivideByZeroExceptionKiveteltDob()
        {
            Assert.Throws<DivideByZeroException>(() => Calculator.Divide(6, 0));
        }

        [Fact]
        public void Negyzetgyok_HelyesEredmenytAdVissza()
        {
            double eredmeny = Calculator.SquareRoot(9);
            Assert.Equal(3, eredmeny);
        }

        [Fact]
        public void Negyzetgyok_NegativSzam_ArgumentExceptionKiveteltDob()
        {
            Assert.Throws<ArgumentException>(() => Calculator.SquareRoot(-1));
        }

        [Fact]
        public void Hatvany_HelyesEredmenytAdVissza()
        {
            double eredmeny = Calculator.Power(2, 3);
            Assert.Equal(8, eredmeny);
        }
    }
}
```
</details>

