# Gyakorló feladatsor

```c#
List<Auto> a = ...
```

-a.ForEach(x => Console.WriteLine(x));

-int osszeg = a.Sum(auto => auto.FutottKm);

-double atlag = a.Average(auto => auto.FutottKm);

-int db = a.Count(auto => auto.Marka==keresettMarka);

-Auto legidosebbAuto = a.OrderBy(auto => auto.Evjarat).FirstOrDefault();

  -Auto legidosebbAuto = a.MinBy(auto => auto.Evjarat);
  
-Auto legtobbetFutottAuto = a.OrderByDescending(auto => auto.FutottKm).FirstOrDefault();
  
  -Auto legtobbetFutottAuto = a.MaxBy(auto => auto.FutottKm);

-Auto keresettAuto = a.FirstOrDefault(auto => auto.Rendszam==keresettRendszam);

vagy

```c#
Auto megtalaltAuto = null;
foreach (Auto auto in a){
   if (auto.Rendszam.Equals(keresesRendszam, StringComparison.OrdinalIgnoreCase)){
       megtalaltAuto = auto;
       break;
   }
}
if (megtalaltAuto == null){
   Console.WriteLine("Nincs ilyen adat");
}else{
   Console.WriteLine(megtalaltAuto);
}
```

-Statisztika:

```c#
IEnumerable<IGrouping<string, Auto>> autokMarkaSzerint = a.GroupBy(auto => auto.Marka);
foreach (IGrouping<string, Auto> csoport in autokMarkaSzerint){
    Console.WriteLine($"{csoport.Key}: {csoport.Count()} db");
    //itt akár foreach-el végigiteráléva ki is írathatók...

}
```
vagy
```c#
Dictionary<string, List<Auto>> autokMarkaSzerint = new Dictionary<string, List<Auto>>();
foreach (Auto auto in a){
   if (!autokMarkaSzerint.ContainsKey(auto.Marka)){
      autokMarkaSzerint[auto.Marka] = new List<Auto>();
   }
   autokMarkaSzerint[auto.Marka].Add(auto);
}

foreach (KeyValuePair<string, List<Auto>> markakCsoport in autokMarkaSzerint){
   Console.WriteLine($"{markakCsoport.Key} ({markakCsoport.Value.Count()}db)");
   foreach (Auto csoportbeliAuto in markakCsoport.Value){
      Console.WriteLine($"  {csoportbeliAuto}");
   }
}
```
