# Grid: TetrisDesigner v1

## Feladat:

Projekt neve: **Wpf_1_TetrisDesigner1**

Projekt leírása: hozz létre, egy 3x3-as Grid minden cellájába egy-egy (összesen 9db) feliret nélküli, strech-elt Button elhelyezése

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
    <Grid>
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
7. A Button_Click metódus-ban meg kell állapítani, hogy melyik gombon történt a kattintás, ezt az object típusú sender paraméter tartalmazza. Tehát megszerezzük a sender-ből a Buttont. 
Button button = sender as Button. (ehelyett a Button button = (Button) sender is jó lenne)
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
            Button button = (Button)sender;
	    if (button != null){
                button.Background = isBlack ? Brushes.LightGray : Brushes.Black;
                isBlack = !isBlack;
        }
    }
}
```
