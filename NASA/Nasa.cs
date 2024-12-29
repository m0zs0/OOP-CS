using NASA;
using System.Text;

static List<Keres> Beolvas() { 
    List<Keres> k = new List<Keres>();
    try
    {
        using (StreamReader sr = new StreamReader("NASAlog.txt", Encoding.UTF8))
        {
            string sor;
            while ((sor = sr.ReadLine()) != null)
            {
                k.Add(new Keres(sor));
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Hiba: {ex.Message}");
        Console.ReadKey();
        Environment.Exit(1);
    }
    return k;
}

static int ValaszokOsszesMerete(List<Keres> k) {
    int osszMeret = k.Sum(k => k.ByteMeret);
    /*int osszMeret = 0;
    foreach (Keres keres in k) {
        osszMeret += keres.ByteMeret;
    }*/
    return osszMeret;
}

static int DomainekSzama(List<Keres> k) {
    int db = k.Count(k => k.Domain);
    /*int db = 0;
    foreach (Keres keres in k) {
        if (keres.Domain) {
            db++;
        }
    }*/
    return db;
}

static void Statisztika(List<Keres> k) {
    IEnumerable<IGrouping<string, Keres>> csoportok = k.GroupBy(k => k.HttpKod);
    foreach (IGrouping<string, Keres> csoport in csoportok) { 
        Console.WriteLine($"\t{csoport.Key}: {csoport.Count()} db");
    }

    /*Dictionary<string, int> stat = new Dictionary<string, int>();
    foreach (Keres keres in k) {
        if (stat.ContainsKey(keres.HttpKod)) {
            stat[keres.HttpKod]++;
        }
        else {
            stat.Add(keres.HttpKod, 1);
        }
    }
    foreach (KeyValuePair<string, int> item in stat) {
        Console.WriteLine($"\t{item.Key}: {item.Value} db");
    }*/
}

static Keres ElsoDomainNelkuliKeres(List<Keres> k) {
    /*Keres keresett = null;
    foreach (Keres keres in k)
    {
        if (!keres.Domain)
        {
            keresett = keres;
            break;
        }
    }
    return keresett;*/

    return k.FirstOrDefault(k => !k.Domain);
}

List<Keres> keresek = Beolvas();
Console.WriteLine($"5. feladat: Kérések száma: {keresek.Count}");
Console.WriteLine($"6. feladat: Válaszok összes mérete: {ValaszokOsszesMerete(keresek)} byte");
Console.WriteLine($"8. Feladat: Domain-es kérések: {(double)DomainekSzama(keresek) / keresek.Count:P}");
Console.WriteLine("9. feladat: Statisztika");
Statisztika(keresek);
Keres elsoDomainNelkuli = ElsoDomainNelkuliKeres(keresek);
Console.WriteLine($"10. feladat: Az első Domain nélküli kérés adatai: \n{(elsoDomainNelkuli == null?"Nincs ilyen": elsoDomainNelkuli)}");