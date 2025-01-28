# Grid: TetrisDesigner v1

## Feladat:

Projekt neve: **Wpf_1_TetrisDesigner1**

Projekt leírása: hozz létre egy 3x3-as Grid-et, aminek minden cellájába egy-egy (összesen 9db) felirat nélküli, strech-elt Button-t helyezz el

Működés: Minden Button-ra kattintáskor színváltás alapszín és fekete között

1. Window méretét beállítjuk 600x600-asra
2. Grid: A Grid-et 3x3-asra osztjuk, hogy a Button-ok egyenletesen elhelyezkedjenek.
3. Button-ok: Minden Button-t elhelyeztünk a megfelelő cella (Row, Column) pozícióba. 
4. A buttonok property-jében beállítjuk a strech-elést mindkét irányban (margin 0) és a "Name"-t beállítjuk a cella pozíciójának megfelelően
5. A Click eseményre a  "Button_Click" eseménykezelőt állítjuk be minden Buttonra

```c#
<Window x:Class="Wpf_1_TetrisDesigner1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="600" Width="600">
    <Grid x:Name="DesignerGrid">
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>

        <Button x:Name="Button00" Grid.Column="0" Grid.Row="0" Click="Button_Click"/>
        <Button x:Name="Button01" Grid.Column="1" Grid.Row="0" Click="Button_Click"/>
        <Button x:Name="Button02" Grid.Column="2" Grid.Row="0" Click="Button_Click"/>
        <Button x:Name="Button10" Grid.Column="0" Grid.Row="1" Click="Button_Click"/>
        <Button x:Name="Button11" Grid.Column="1" Grid.Row="1" Click="Button_Click"/>
        <Button x:Name="Button12" Grid.Column="2" Grid.Row="1" Click="Button_Click"/>
        <Button x:Name="Button20" Grid.Column="0" Grid.Row="2" Click="Button_Click"/>
        <Button x:Name="Button21" Grid.Column="1" Grid.Row="2" Click="Button_Click"/>
        <Button x:Name="Button22" Grid.Column="2" Grid.Row="2" Click="Button_Click"/>
    </Grid>
</Window>
```

6. Felveszünk az osztályban egy isBlack változót, ami azt tárolja, hogy a gomb jelenleg fekete színű-e.
7. A Button_Click metódus-ban meg kell állapítani, hogy melyik gombon történt a kattintás, ezt az object típusú sender paraméter tartalmazza. Az object típus lehetővé teszi, hogy bármilyen típusú objektumot átadjunk az eseménykezelőnek, mert minden típus az object típusból származik, így az object típusú referencia bármilyen típusú objektumra mutathat. Az eseménykezelőn belül típuskonverziót végzünk a sender paraméteren, hogy a konkrét típusú objektumhoz férjünk hozzá. Például, ha a sender egy gomb, akkor Button típusra konvertáljuk, hogy a gomb tulajdonságait módosíthassuk. Erre 3 mód létezik: 
- 1: is operátor: ellenőrízzük, hogy a sender egy adott típusú objektum-e. Ez a legbiztonságosabb módszer.
```c#
if (sender is Button button)
    {
        button.Background = Brushes.Black;
    }
```
- 2: as operátor: biztonságosan próbálhatjuk meg konvertálni a sender-t egy adott típusra. Ha a konverzió sikertelen, akkor a eredmény null lesz.
```c#
Button button = sender as Button;
    if (button != null)
    {
        button.Background = Brushes.Black;
    }
```
- 3: Castolás: Sikertelenség esetén egy `InvalidCastException` kivétel dobódik és ezt kapjuk el.
```c#
try
    {
        Button buttonCast = (Button)sender;
        buttonCast.Background = Brushes.Green;
    }
    catch (InvalidCastException)
    {
        // Kezeljük a hibát, ha a konverzió sikertelen volt
        MessageBox.Show("A sender nem Button típusú!");
    }
```
8. Ha sikerül Button típusként azonosítani a sender-t, akkor a button.Background tulajdonsággal beállítjuk a Button háttérszínét, és az isBlack változó értékét megfordítjuk.

```c#
using System.Windows;
using System.Windows.Controls;

namespace Wpf_1_TetrisDesigner1
{

    public partial class MainWindow : Window
    {
        private bool isBlack = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
	    if (button != null){
                button.Background = isBlack ? Brushes.LightGray : Brushes.Black;
                isBlack = !isBlack;
        }
    }
}
```
## Feladat2
Biztosítsuk, hogy a felhasználók elmenthessék és később betölthessék a saját Tetris formájukat.

Ehhez vegyünk fel egy tömböt: 

```c#
private int[,] tetrisForm = new int[3, 3];
```

A gomb lenyomásakor a tömbbeli értéket is átállítjuk:
```c#

private void Button_Click(object sender, RoutedEventArgs e)
{
    // button létezik
    int row = Grid.GetRow(button);
    int column = Grid.GetColumn(button);
    tetrisForm[row, column] = isBlack ? 1 : 0;
    // ...
}```

Mentés fájlba:
```c#
private void SaveButton_Click(object sender, RoutedEventArgs e)
{
    using (StreamWriter writer = new StreamWriter("tetrisDesign1.txt"))
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                writer.Write(tetrisForm[i, j]);
            }
            writer.WriteLine();
        }
    }
}
```

Betöltés fájlból:

```c#
private void LoadButton_Click(object sender, RoutedEventArgs e)
{
    using (StreamReader reader = new StreamReader("tetrisDesign1.txt"))
    {
        string line;
        int row = 0;
        while ((line = reader.ReadLine()) != null)
        {
            for (int column = 0; column < 3; column++)
            {
                tetrisForm[row, column] = int.Parse(line[column].ToString());
                // Frissítsd a megfelelő gomb színét a tömb értéke alapján
            }
            row++;
        }
    }
}


```

De hogyan érjük el az adott gombot?
Minden UI elemnek, így a Button-nak is van egy Tag tulajdonsága. Ez egy általános célú tulajdonság, amelybe bármilyen típusú objektumot eltárolhatunk. Gyakran használják további adatok társítására az elemhez, amelyek nem közvetlenül a megjelenítéshez kapcsolódnak.

Amikor létrehozzuk a gombokat, állítsuk be a Tag tulajdonságukat egy olyan objektumra, amely tartalmazza a szükséges információkat, például a sor és oszlop indexet.
Például létrehozhatunk egy egyszerű osztályt:

```c#
public class ButtonData
{
    public int Row { get; set; }
    public int Column { get; set; }
}
```

A gomb létrehozásakor:
```c#
Button button = new Button();
button.Tag = new ButtonData { Row = row, Column = column };
```

A Click eseményben:
```c#
private void Button_Click(object sender, RoutedEventArgs e)
{
    Button button = (Button)sender;
    ButtonData buttonData = (ButtonData)button.Tag;
    int row = buttonData.Row;
    int column = buttonData.Column;
    // ...
}
```
