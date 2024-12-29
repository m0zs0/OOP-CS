using LezerLovesek;
using System.Runtime.CompilerServices;
using System.Text;

static List<Loves> Beolvas()
{
    List<Loves> l = new List<Loves>();
    try
    {
        using (StreamReader sr = new StreamReader("lovesek.txt", Encoding.UTF8))
        {
            string sor = sr.ReadLine();
            Loves.KozepX = Convert.ToDouble(sor.Split(';')[0]);
            Loves.KozepY = Convert.ToDouble(sor.Split(';')[1]);
            int id = 0;
            while ((sor = sr.ReadLine()) != null)
            {
                string[] seged = sor.Split(';');
                id++;
                l.Add(new Loves(seged[0], Convert.ToDouble(seged[1]), Convert.ToDouble(seged[2]), id));
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"File beolvasasi hiba: {ex.Message}");
    }
    return l;
}
static Loves LegpontosabbLoves(List<Loves> l)
{
    Loves legpontosabb = l[0];
    foreach (Loves loves in l)
    {
        if (legpontosabb.Tavolsag() > loves.Tavolsag())
        {
            legpontosabb = loves;
        }
    }
    return legpontosabb;
}
static int NullaPontosLovesek(List<Loves> l)
{
    int nullapontdb = 0;
    foreach (Loves loves in l)
    {
        if (loves.Pontszam==0)
        {
            nullapontdb++;
        }
    }
    return nullapontdb;
}

static Dictionary<string, List<double>> Statisztika(List<Loves> l)
{
    Dictionary<string, List<double>> s = new Dictionary<string, List<double>>();

    foreach (Loves loves in l)
    {
        if (!s.ContainsKey(loves.Nev))
        {
            s[loves.Nev] = new List<double>();
        }
        s[loves.Nev].Add(loves.Pontszam);
    }
    return s;
}

static void LeadottLovesekSzama(Dictionary<string, List<double>> s)
{
    Console.WriteLine("Leadott lövések száma: ");
    foreach (KeyValuePair<string, List<double>> jatekos in s)
    {
        Console.WriteLine($"\t {jatekos.Key} {jatekos.Value.Count} lövést adott le.");
    }
}

static void AtlagPontszam(Dictionary<string, List<double>> s)
{
    Console.WriteLine("Átlagpontszámok: ");
    foreach (KeyValuePair<string, List<double>> jatekos in s)
    {
        Console.WriteLine($"\t {jatekos.Key} átlagpontszáma: {jatekos.Value.Average():f2}");
    }
}

static void NyertesJatekos(Dictionary<string, List<double>> s)
        {
            double legnagyobbAtlagPontszam = 0;
            string legnagyobbAtlagPontszamNev = "";
            foreach (KeyValuePair<string, List<double>> jatekos in s)
            {
                if (jatekos.Value.Average() > legnagyobbAtlagPontszam)
                {
                    legnagyobbAtlagPontszam = jatekos.Value.Average();
                    legnagyobbAtlagPontszamNev = jatekos.Key;
                }
            }
            Console.WriteLine($"A nyertes játékos: {legnagyobbAtlagPontszamNev} az átlagpontszáma: {legnagyobbAtlagPontszam:f2}");
        }

List<Loves> lovesek = Beolvas();
Console.WriteLine($"A játékosok {lovesek.Count} lövést adtak le a játék során");
Loves legpontosabbloves = LegpontosabbLoves(lovesek);
Console.WriteLine($"A legpontosabb lövést {legpontosabbloves.Nev} adta le, koordinátái: ({legpontosabbloves.X}, {legpontosabbloves.Y}).");
int nullapontos = NullaPontosLovesek(lovesek);
Console.WriteLine($"A nulla pontos lövések száma: {nullapontos}");
Dictionary<string,List<double>> statisztika = Statisztika(lovesek);
Console.WriteLine($"A játékban résztvevő játékosok száma: {statisztika.Count}");
LeadottLovesekSzama(statisztika);
AtlagPontszam(statisztika);
NyertesJatekos(statisztika);
Console.WriteLine("Nyomj egy gombot a kilepeshez");
Console.ReadKey();