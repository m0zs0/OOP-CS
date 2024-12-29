# 5. modul Ismétlés: Paraméterátadás

- Érték szerinti paraméterátadás
  - Érték típusú változók
  - Referencia típusú változók
- Cím szerinti paraméterátadás

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


