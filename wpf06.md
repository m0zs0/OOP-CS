# WORD 1.0

![WORD 1.0](PICTURES/Wpf_1_WORD1_0.png)

NumericUpDown telepítése:

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
