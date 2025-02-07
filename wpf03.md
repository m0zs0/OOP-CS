# Grid: TicTacToe

## Feladat:

Solution neve: **Wpf_1_TicTacToe**

Projekt leírása: hozz létre egy 3x3-as Grid-et, aminek minden cellájába egy-egy (összesen 9db) felirat nélküli, strech-elt Button-t helyezz el

Működés: ...

```c#
<Window x:Class="Wpf_1_TicTacToe.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:Wpf_1_TicTacToe"
        mc:Ignorable="d"
        Title="TicTacToe" Height="600" Width="600">
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
            <Button x:Name="Button00" Grid.Row="0" Grid.Column="0" Click="Button_Click" FontSize="100"/>
            <Button x:Name="Button01" Grid.Row="0" Grid.Column="1" Click="Button_Click" FontSize="100"/>
            <Button x:Name="Button02" Grid.Row="0" Grid.Column="2" Click="Button_Click" FontSize="100"/>
            <Button x:Name="Button10" Grid.Row="1" Grid.Column="0" Click="Button_Click" FontSize="100"/>
            <Button x:Name="Button11" Grid.Row="1" Grid.Column="1" Click="Button_Click" FontSize="100"/>
            <Button x:Name="Button12" Grid.Row="1" Grid.Column="2" Click="Button_Click" FontSize="100"/>
            <Button x:Name="Button20" Grid.Row="2" Grid.Column="0" Click="Button_Click" FontSize="100"/>
            <Button x:Name="Button21" Grid.Row="2" Grid.Column="1" Click="Button_Click" FontSize="100"/>
            <Button x:Name="Button22" Grid.Row="2" Grid.Column="2" Click="Button_Click" FontSize="100"/>
        </Grid>
</Window>

```

```c#
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

namespace Wpf_1_TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[,] amoba = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        private bool player1 = true;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Content == null)
            {
                //button.Content = player1 ? "x" : "o";
                //player1 = !player1;
                int row = Grid.GetRow(button);
                int col = Grid.GetColumn(button);
                if (player1)
                {
                    button.Content = "x";
                    player1 = false;
                    amoba[row, col] = 1;
                }
                else
                {
                    button.Content= "o";
                    player1 = true;
                    amoba[row,col] = 2;
                }
                WinnerCheck();
            }
        }
        private void WinnerCheck()
        {
            string winner = string.Empty;
            //columncheck
            for (int i = 0; i < amoba.GetLength(0); i++)
            {
                if (amoba[0,i]!= 0 && amoba[0,i] == amoba[1,i] && amoba[1,i] == amoba[2,i])
                {
                    winner = amoba[0, i] == 1 ? "x" : "o";
                    break;
                }
            }
            //rowcheck
            for (int i = 0;i < amoba.GetLength(1); i++)
            {
                if (amoba[i, 0] != 0 && amoba[i, 0] == amoba[i, 1] && amoba[i, 1] == amoba[i, 2])
                {
                    winner = amoba[i, 0] == 1 ? "x" : "o";
                    break;
                }
            }
            //crosscheck
            if ((amoba[0,0] != 0 && amoba[0,0] == amoba[1, 1] && amoba[1, 1] == amoba[2, 2]) ||
                (amoba[0, 2] != 0 && amoba[0, 2] == amoba[1, 1] && amoba[1, 1] == amoba[2, 0]))
            {
                winner = amoba[1, 1] == 1 ? "x" : "o";
            }
            if (winner != "")
            {
                MessageBox.Show(winner);
                Restart();
            }
        }
        private void Restart()
        {
            Button00.Content = null;
            Button01.Content = null;
            Button02.Content = null;
            Button10.Content = null;
            Button11.Content = null;
            Button12.Content = null;
            Button00.Content = null;
            Button21.Content = null;
            Button22.Content = null;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    amoba[i, j] = 0;
                }
            }
        }
    }
}
```
