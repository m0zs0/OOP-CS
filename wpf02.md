# Grid: TetrisShapeDesigner

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
        public MainWindow()
        {
            InitializeComponent();
        }

	private bool isBlack(Button button) { 
	    return button.Background == Brushes.Black;
	}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button){
                button.Background = isBlack(button) ? Brushes.LightGray : Brushes.Black;
        }
    }
}
```
## Feladat2
Biztosítsuk, hogy a felhasználók elmenthessék és később betölthessék a saját Tetris formájukat.

9. **A UI áttervezése**

Az eredeti `DesignerGrid` Drid-ünket egy nagyobb Gridbe foglaljuk, úgy hogy a nagy Grid-nek 2 sora van, amiből a 0. sorban a tervezőgombok, az 1. sorban a Load és a Save gombok vannak:

```c#
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition/>
        <RowDefinition Height="Auto"/>
    </Grid.RowDefinitions>

    <Grid x:Name="DesignerGrid" Grid.Row="0">
        ...
    </Grid>

    <!-- Grid a mentés és betöltés gombokhoz -->
    <Grid x:Name="MenuGrid" Grid.Row="1">
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <Button x:Name="ButtonLoad" Content="Load" Grid.Column="0" Click="LoadButton_Click" HorizontalAlignment="Center" Width="90" Height="54" Margin="10"/>
        <Button x:Name="ButtonSave" Content="Save" Grid.Column="1" Click="SaveButton_Click" HorizontalAlignment="Center" Width="90" Height="54" Margin="10"/>
    </Grid>
</Grid>
```

10. **Eseménykezelők módosítása**

Majd vegyünk fel egy tömböt, amit egyből nullákkal fel is töltünk. 0: nincs színezve (!= fekete), 1: színezve van (==fekete): 

```c#
private int[,] tetrisForm = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
```

A gomb lenyomásakor a tömbbeli értéket is átállítjuk:
```c#

private void Button_Click(object sender, RoutedEventArgs e)
{
    // button létezik
    int row = Grid.GetRow(button);
    int column = Grid.GetColumn(button);
    tetrisForm[row, column] = isBlack(button) ? 1 : 0;
    // ...
}
```

Mentés fájlba:

A tömböt kiírjuk egy egyzerű text fájlba:

```c#
private void SaveButton_Click(object sender, RoutedEventArgs e)
{
    using (StreamWriter sw = new StreamWriter("tetrisDesign1.txt"))
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                sw.Write(tetrisForm[i, j]);
            }
            sw.WriteLine();
        }
    }
    MessageBox.Show("Mentve :)");
}
```

Betöltés fájlból:

Beolvassuk a fájl tartalmát egy tömbbe, majd hozzárendeljük a mátrix indexek alapján a Grid cellákat és beállítjuk a színt:

```c#
private void LoadButton_Click(object sender, RoutedEventArgs e)
{
    using (StreamReader sr = new StreamReader("tetrisDesign1.txt"))
    {
        for (int i = 0; i < 3; i++)
        {
            string sor = sr.ReadLine();
            for (int j = 0; j < 3; j++)
            {
                tetrisForm[i, j] = int.Parse(sor[j].ToString());
                Button button = GetButton(i, j);
                button.Background = tetrisForm[i, j] == 1 ? Brushes.Black : Brushes.LightGray;
            }
        }
    }
    MessageBox.Show("Betöltve :)");
}
```

De hogyan érjük el az adott gombot?

Egy gombot keresünk a DesignerGrid nevű Grid vezérlőben, amely a megadott sorban (row) és oszlopban (column) található. 

`DesignerGrid.Children`: Ez a DesignerGrid nevű Grid vezérlő összes gyermek elemét adja vissza egy UIElementCollection típusba.

`.Cast<UIElement>()`: Ez a metódus az összes gyermek elemet UIElement típusúvá alakítja, hogy LINQ lekérdezéseket lehessen használni rajtuk.

`.First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == column)`: Ez a LINQ lekérdezés az első olyan elemet keresi, amelynek a sor- és oszlopindexe megegyezik a megadott row és column értékekkel. A Grid.GetRow(e) és Grid.GetColumn(e) metódusok segítségével lekérdezzük az elem sor- és oszlopindexét.

`(Button)`: Végül az eredményt Button típusúvá alakítjuk, mivel biztosak vagyunk benne, hogy a keresett elem egy gomb.

```c#
private Button GetButton(int row, int column)
{
    return (Button)DesignerGrid.Children
        .Cast<UIElement>()
        .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == column);
}
```

<details>
<summary>Nyiss le az xaml forrásáért!</summary>

### `MainWindows.xaml` példa:
```c#
<Window x:Class="Wpf_1_TetrisDesigner1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="600" Width="600">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>

        <!-- DesignerGrid a tervező gombokhoz -->
        <Grid x:Name="DesignerGrid" Grid.Row="0">
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

        <!-- Grid a mentés és betöltés gombokhoz -->
        <Grid Grid.Row="1">
            <Grid.ColumnDefinitions>
                <ColumnDefinition/>
                <ColumnDefinition/>
            </Grid.ColumnDefinitions>
            <Button x:Name="ButtonLoad" Content="Load" Grid.Column="0" Click="LoadButton_Click" HorizontalAlignment="Center" Width="90" Height="54" Margin="10"/>
            <Button x:Name="ButtonSave" Content="Save" Grid.Column="1" Click="SaveButton_Click" HorizontalAlignment="Center" Width="90" Height="54" Margin="10"/>
        </Grid>
    </Grid>
</Window>   

```
</details>


<details>
<summary>Nyiss le az xaml.cs forrásáért!</summary>

### `MainWindows.xaml.cs` példa:
```c#
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_1_TetrisDesigner1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[,] tetrisForm = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("tetrisDesign1.txt"))
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        sw.Write(tetrisForm[i, j]);
                    }
                    sw.WriteLine();
                }
            }
            MessageBox.Show("Mentve :)");
        }

        private bool isBlack(Button button) { 
            return button.Background == Brushes.Black;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button) { 
                button.Background = isBlack(button) ? Brushes.LightGray : Brushes.Black;
                int row = Grid.GetRow(button);
                int column = Grid.GetColumn(button);
                tetrisForm[row, column] = isBlack(button) ? 1 : 0;
            }
            
        }

        private Button GetButton(int row, int column)
        {
            return (Button)DesignerGrid.Children
                .Cast<UIElement>()
                .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == column);
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("tetrisDesign1.txt"))
            {
                for (int i = 0; i < 3; i++)
                {
                    string sor = sr.ReadLine();
                    for (int j = 0; j < 3; j++)
                    {
                        tetrisForm[i, j] = int.Parse(sor[j].ToString());
                        Button button = GetButton(i, j);
                        button.Background = tetrisForm[i, j] == 1 ? Brushes.Black : Brushes.LightGray;
                    }
                }
            }
            MessageBox.Show("Betöltve :)");
        }
    }
}

```
</details>


## Patch

Mostmár csak annyi a probléma, hogy alapértelmezésben, ha megállunk egy gomb felett, akkor a háttérszín helyett a template hover-ében beállított színnel lefedi a hátteret.

1. megoldás Módosíthatjuk a gombok stílusát úgy, hogy ne változzon a háttérszínük, amikor az egér föléjük kerül. Ezt megtehetjük egy egyedi stílus létrehozásával a XAML-ben.
2. megoldás: Ne Buttont használjunk hanem pl Rectangle vezérlőt. 

Ugyanebben a Solution-ban adjunk hozzá egy új projektet `Wpf_1_TetrisDesigner2` néven. Majd minden DesignerGrid-ben lévő gomb helyett egy-egy Rectangle vezérlőt tegyünk be. Arra is figyeljünk, hogy ennek a MouseDown() eseményére kell feliratkoznunk. 


<details>
<summary>Nyiss le az xaml forrásáért!</summary>

### `MainWindows.xaml` példa:
```c#
<Window x:Class="Wpf_1_TetrisDesigner2.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="600" Width="600">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>

        <!-- GameGrid a játék elemekhez -->
        <Grid x:Name="DesignerGrid" Grid.Row="0">
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

            <Rectangle x:Name="Rect00" Grid.Column="0" Grid.Row="0" Fill="LightGray" MouseDown="Rectangle_MouseDown"/>
            <Rectangle x:Name="Rect01" Grid.Column="1" Grid.Row="0" Fill="LightGray" MouseDown="Rectangle_MouseDown"/>
            <Rectangle x:Name="Rect02" Grid.Column="2" Grid.Row="0" Fill="LightGray" MouseDown="Rectangle_MouseDown"/>
            <Rectangle x:Name="Rect10" Grid.Column="0" Grid.Row="1" Fill="LightGray" MouseDown="Rectangle_MouseDown"/>
            <Rectangle x:Name="Rect11" Grid.Column="1" Grid.Row="1" Fill="LightGray" MouseDown="Rectangle_MouseDown"/>
            <Rectangle x:Name="Rect12" Grid.Column="2" Grid.Row="1" Fill="LightGray" MouseDown="Rectangle_MouseDown"/>
            <Rectangle x:Name="Rect20" Grid.Column="0" Grid.Row="2" Fill="LightGray" MouseDown="Rectangle_MouseDown"/>
            <Rectangle x:Name="Rect21" Grid.Column="1" Grid.Row="2" Fill="LightGray" MouseDown="Rectangle_MouseDown"/>
            <Rectangle x:Name="Rect22" Grid.Column="2" Grid.Row="2" Fill="LightGray" MouseDown="Rectangle_MouseDown"/>
        </Grid>

        <!-- Grid a mentés és betöltés gombokhoz -->
        <Grid Grid.Row="1">
            <Grid.ColumnDefinitions>
                <ColumnDefinition/>
                <ColumnDefinition/>
            </Grid.ColumnDefinitions>
            <Button x:Name="ButtonLoad" Content="Load" Grid.Column="0" Click="LoadButton_Click" HorizontalAlignment="Center" Width="90" Height="54" Margin="10"/>
            <Button x:Name="ButtonSave" Content="Save" Grid.Column="1" Click="SaveButton_Click" HorizontalAlignment="Center" Width="90" Height="54" Margin="10"/>
        </Grid>
    </Grid>
</Window>
 

```
</details>


<details>
<summary>Nyiss le az xaml.cs forrásáért!</summary>

### `MainWindows.xaml.cs` példa:
```c#
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_1_TetrisDesigner2
{
    public partial class MainWindow : Window
    {
        private int[,] tetrisForm = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("tetrisDesign1.txt"))
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        sw.Write(tetrisForm[i, j]);
                    }
                    sw.WriteLine();
                }
            }
            MessageBox.Show("Mentve :)");
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Rectangle rect)
            {
                int row = Grid.GetRow(rect);
                int column = Grid.GetColumn(rect);
                if (rect.Fill == Brushes.Black)
                {
                    rect.Fill = Brushes.LightGray;
                    tetrisForm[row, column] = 0;
                }
                else
                {
                    rect.Fill = Brushes.Black;
                    tetrisForm[row, column] = 1;
                }
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("tetrisDesign1.txt"))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        string line = sr.ReadLine();
                        for (int j = 0; j < 3; j++)
                        {
                            tetrisForm[i, j] = int.Parse(line[j].ToString());
                            Rectangle rect = GetRectangle(i, j);
                            rect.Fill = tetrisForm[i, j] == 1 ? Brushes.Black : Brushes.LightGray;
                        }
                    }
                }
                MessageBox.Show("Betöltve :)");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a betöltés során: {ex.Message}");
            }
        }

        private Rectangle GetRectangle(int row, int column)
        {
            return DesignerGrid.Children
                .OfType<Rectangle>()
                .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == column);
        }
    }
}

```
</details>



