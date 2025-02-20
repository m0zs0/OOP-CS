# WORD 1.0 - Szövegszerkesztő alkalmazás készítése WPF-ben

![WORD 1.0](PICTURES/Wpf_1_WORD1_0.png)

Feladat: Készíts egy egyszerű szövegszerkesztő alkalmazást (Wpf_1_WORD1_0), amely lehetővé teszi a szöveg formázását és a szöveg formázás nélküli betöltését és mentését.

Felhasználói felület kialakítása:
A főablak (MainWindow) tartalmazzon egy Grid elrendezést három sorral:
Az első sorban helyezz el különböző vezérlőelemeket a betűtípus, betűstílus, (+ betűméret,) betűszín és háttérszín kiválasztásához.
A második sorban legyen egy TextBox vezérlőelem, amelyben a felhasználó szerkesztheti a szöveget.
A harmadik sorban helyezz el két gombot a szöveg betöltéséhez és mentéséhez.

Betűtípus kiválasztása:
Helyezz el három RadioButton vezérlőelemet a következő betűtípusok kiválasztásához: Times New Roman, Arial, Courier New.
Az eseménykezelőben (FontType_Checked) állítsd be a TextBox betűtípusát a kiválasztott értéknek megfelelően.

Betűstílus kiválasztása:
Helyezz el három CheckBox vezérlőelemet a következő betűstílusok kiválasztásához: Félkövér, Dőlt, Aláhúzott.
Az eseménykezelőben (FontStyle_Checked) állítsd be a TextBox betűstílusát a kiválasztott értékeknek megfelelően.

+Betűméret kiválasztása (*):
Helyezz el egy NumericUpDown vezérlőelemet a betűméret kiválasztásához.
Az eseménykezelőben (FontSize_ValueChanged) állítsd be a TextBox betűméretét a kiválasztott értéknek megfelelően.

Színek kiválasztása:
Helyezz el két ComboBox vezérlőelemet a betűszín és a háttérszín kiválasztásához.
Az eseménykezelőkben (FontColor_SelectionChanged és BackgroundColor_SelectionChanged) állítsd be a TextBox betűszínét és háttérszínét a kiválasztott értékeknek megfelelően.

Szöveg betöltése és mentése:
Helyezz el két gombot a szöveg betöltéséhez és mentéséhez.
Az eseménykezelőkben (Load_Click és Save_Click) valósítsd meg a fájlok betöltését és mentését Dialog-okkal.




(*) NumericUpDown telepítése:

1. Solution Explorer / projekt nevének gyorsmenüje / "Manage NuGet Packages..."
2. Browse: "NumericUpDown", és telepítsd
3. Az xaml-be be kell írni egy deklarációt, ehhez menj a View / Object Browser / NumericUpDown -ra. Itt állapítsd meg az Assembly nevét (NumericUpDown) és a namespace nevét (ControlLib), majd az alábbi sort szúrd be a xaml fejlécébe:
```
xmlns:nud="clr-namespace:ControlLib;assembly=NumericUpDown"
```
itt egyébként a tulajdonságait és az eseményeit is meg tudod nézni. Pl: Value
4. Szintén az xaml-ben a megfelelő helyre be tudod szúrni a vezérlőt:
```
<nud:NumericUpDown Name="nudFontSize" MinValue="8" MaxValue="72" Value="14" ValueChanged="FontSize_ValueChanged" Width="50"/>
```
5. Az Eventlistában ki kell keresni a ValueChange-t, amit szintén az Object Browser-ből látunk és itt 2x kell kattintani, majd megírni az eseménykezelőt:
```
private void FontSize_ValueChanged(object sender, ControlLib.ValueChangedEventArgs e)
{
    if (txtEditor != null && nudFontSize.Value != null)
    {
        txtEditor.FontSize = nudFontSize.Value;
    }
}
```
