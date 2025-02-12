c# wpf akasztófa játék: 
4 játékrész van:
bal felül a feladvány a támamegjelöléssel
bal alul a betűgombok
jobb felül  Feladás és  Megadom a megoldást
jobb alul az akasztófa helye 11 hibalehetőséggel

Ha megnyom egy betűgombot, akkor ha benne van a szóban akkor beírja (a gomb zöldre változik), ha nincs benne, akkor egy új képet tölt be az akasztófa következő fázisával a betű pirosra változik.
Tag tulajdonság a reprezentált betű eltárolása.
kép betöltés: AkasztofaKep.Source = new BitmapImage(new Uri($"Images/akasztofa{errorCounter}.png", UriKind.Relative));
A feladás gomb kiírja a megoldást, a Megadom a megoldást pedig egy szövegdobozon keresztül bekéri a szót. 
A szavak, kifejezések maximum 20 hosszúak legyenek (szóköz ne legyen benne), amik egy szavak.txt fájlból kerülnek betöltésre.
Kezdetben a szó betűszámának megfelelő aláhúzás szerepeljen, majd ha benne van a betű, akkor az íródjon át.
