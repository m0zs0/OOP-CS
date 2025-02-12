c# wpf akasztófa játék: 
4 játékrész van:

bal felül a feladvány a támamegjelöléssel

bal alul a betűgombok

jobb felül  Feladás és  Megadom a megoldást

jobb alul az akasztófa helye 11 hibalehetőséggel

Ha megnyom egy betűgombot, akkor ha benne van a szóban akkor beírja (a gomb zöldre változik), ha nincs benne, akkor egy új képet tölt be az akasztófa következő fázisával a betű pirosra változik.

A feladás gomb kiírja a megoldást, a Megadom a megoldást pedig egy szövegdobozon keresztül bekéri a szót. 

A szavak, kifejezések maximum 20 hosszúak legyenek (szóköz ne legyen benne), amik egy szavak.txt fájlból kerülnek betöltésre.

Kezdetben a szó betűszámának megfelelő aláhúzás szerepeljen, majd ha benne van a betű, akkor az íródjon át.

Ötletek:
```
List<Button> gombok = new List<Button>();

for (int i = 0; i < feladvany.Length; i++)
{
    Button btn = new Button();
    btn.Content = "_";
    btn.Tag = feladvany[i].ToString();
    btn.Name = "btn" + i;
    gombok.Add(btn);

    Hozzáadás a Grid-hez
    wordGrid.Children.Add(btn);
    Grid.SetColumn(btn, i); // Beállítja a gomb oszlopát
}
```

kép betöltés 
```
HangmanImage.Source = new BitmapImage(new Uri($"Images/akasztofa{errorCounter}.png", UriKind.Relative));
```
