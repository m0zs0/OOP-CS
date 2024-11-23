# 7. modul Kő-Papír-Olló játék megírása

**Működési alapvetések:**
- Mind Console-os mind WPF-es implementációban működni kell
- Az osztályokat ennek megfelelően alakítsuk ki


![KPO feladat megoldása](PICTURES/OOP_2_KPO_Solution.png)

## 1. Konzolos projekt létrehozása (.NET8):
-Hozz létre egy új Console Application projektet a megoldásban. Solution neve: OOP_2_KPO; Projekt neve: ConsoleApp
## 2. Class Library projekt létrehozása:
-A Solution Explorer-ben kattints jobb gombbal a Solution nevére, és válaszd az "Add" > "New Project..." > "Class Library" projekt típust, és nevezd el "ClassLibrary"-nek.
-Hozz létre egy "Classes" mappát a ClassLibrary projektben, és ide helyezd el a közös osztályokat (Player, Match).
-Hozzuk létre a Player osztályt a Classes mappában (kattints jobb gombbal a Classes mappa nevére, és válaszd az "Add" > "Class" lehetőséget, majd gépeld be: Player)

<details>
<summary>Nyiss le a Player.cs forrásáért!</summary>
### `Player.cs` példa:
```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary.Classes
{
    public class Player
    {
        private static string[] _hands = new string[] { "kő", "papír", "olló" };

        public Player(int lives=3, string name = "Anonymus")
        {
            Name = name;
            Lives = lives;
        }

        public string Name { get; set; }
        public int Lives { get; set; }
        public int Hand { get; set; } //1 = kő, 2 = papír, 3 = olló!

        /// <summary>
        /// A játékos választása szövegesen.
        /// </summary>
        /// <returns>kő | papír | olló</returns>
        public string GetHandAsString()
        {
            return _hands[Hand-1];
        }

        /// <summary>
        /// A játékos megadott neve stringként.
        /// </summary>
        /// <returns>Name</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Csak konzolos alkalmazásoknál használható metódus a név beállításához.
        /// </summary>
        public void SetName()
        {
            Console.Write("Kérlek add meg a neved: ");
            Name = Console.ReadLine();
        }
        /// <summary>
        /// A játékos élete eggyel csökken.
        /// </summary>
        public void Fail()
        {
            Lives--;
        }

        
        /// <summary>
        /// A játékos életereje>0
        /// </summary>
        /// /// <returns>Lives>0</returns>
        public bool IsAlive { get => Lives > 0; }
    }
}

```
</details>

<details>
<summary>Nyiss le a Match.cs forrásáért!</summary>
### `Match.cs` példa:
```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes
{
    public class Match
    {
        private Player p1, p2;
        private int winner;
        private int round;

        public Match(Player p1, Player p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public void NextRound()
        {
            round++;
            
            winner = this.GetWinner(p1, p2);

            if (winner == -1)
            {
                p2.Fail();
            }
            else if (winner == 1)
            {
                p1.Fail();
            }
        }

        public bool IsFinished
        {
            get => !p1.IsAlive || !p2.IsAlive;
        }

        public string Info()
        {
            string result = "";
            result+=$"{round}. kör: \n";
            result += $"{p1}: {p1.GetHandAsString()} ({p1.Hand}) - ";
            result += $"{p2}: {p2.GetHandAsString()} ({p2.Hand})";
            string ny = "döntetlen";
            if (winner > 0)
            {
                ny = p2.Name;
            }
            else if (winner < 0)
            {
                ny = p1.Name;
            }
            result += $"\nKör nyertese: {ny}  ";
            result += $"\nPontszámok: {p1}: {p1.Lives} {p2}: {p2.Lives}\n";
            return result;
        }

        public int GetWinner(Player p1, Player p2)
        {
            int winner = 0; //-1: p1; 0: döntetlen; 1: p2 nyert 
            /*
             * 
                                         p2-p1
             akármi     ugyanaz          a-a =  0     döntetlen  
             1 (Kő)     2 (Papír)        2-1 =  1     p2 
             1 (Kő)     3 (Olló)         3-1 =  2     p1?     
             2 (Papír)  1 (Kő)           1-2 = -1     p1
             2 (Papír)  3 (Olló)         3-2 =  1     p2 
             3 (Olló)   1 (Kő)           1-3 = -2     p2? 
             3 (Olló)   2 (Papír)        2-3 = -1     p1
             */

            winner = p2.Hand - p1.Hand;
            if (Math.Abs(winner) == 2)
            {
                winner /= -2;
            }
            return winner;
        }

        public string GameWinner
        {
            get
            {
                if (IsFinished)
                {
                    if (p1.IsAlive)
                    {
                        return p1.Name;
                    }
                    if (p2.IsAlive)
                    {
                        return p2.Name;
                    }
                }
                return "";
            }
        }
    }
}

```
</details>

<details>
<summary>Nyiss le a Program.cs forrásáért!</summary>
### `Program.cs` példa:
```c#
using ClassLibrary.Classes;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System.Xml.Serialization;

class Program
{
    /// <summary>
    /// Csak konzolos alkalmazásoknál használható metódus a játéko választásának bekérésére.
    /// </summary>
    static void Choice(Player p1, Player p2)
    {
        Random _rnd = new Random();
        int choice = 0;
        do
        {
            Console.Write($"{p2.Name}, válassz: 1: kő, 2: papír, 3: olló [1|2|3]:  ");
        } while (int.TryParse(Console.ReadLine(), out choice) && !(choice >= 1 && choice <= 3));
        p2.Hand = choice;

        p1.Hand = _rnd.Next(3) + 1;

    }
    static void Main(string[] args)
    {
        Player _player1 = new Player();
        Player _player2 = new Player(3);
        _player2.SetName();
        
        Match match = new Match(_player1, _player2);

        while (true)
        {
            if (match.IsFinished)
            {
                break;
            }
            Choice(_player1, _player2);
            match.NextRound();
            Console.WriteLine(match.Info());
        }
        Console.WriteLine($"{match.GameWinner} játékos nyert!");
    }
}

```
</details>

## 3. WPF projekt létrehozása:
-Hozz létre egy új WPF Application projektet a Solutionban (WpfApp).

<details>
<summary>Nyiss le a MainWindow.xaml forrásáért!</summary>
### `MainWindow.xaml` példa:
```c#
<Window x:Class="WpfApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <Label Content="A Játék állása:" HorizontalAlignment="Left" Margin="367,4,0,0" VerticalAlignment="Top"/>
        <TextBox x:Name="tb_player1Name" HorizontalAlignment="Left" Height="21" Margin="114,35,0,0" TextWrapping="Wrap" Text="pl1 name" VerticalAlignment="Top" Width="264" IsEnabled="False" />
        <TextBox x:Name="tb_player1Lives" HorizontalAlignment="Left" Height="21" Margin="112,96,0,0" TextWrapping="Wrap" Text="pl1 lives" VerticalAlignment="Top" Width="264" IsEnabled="False"/>
        <TextBox x:Name="tb_player2Name" HorizontalAlignment="Left" Height="22" Margin="440,35,0,0" TextWrapping="Wrap" Text="pl2 name" VerticalAlignment="Top" Width="264" TextChanged="tb_player2Name_TextChanged"/>
        <TextBox x:Name="tb_player2Lives" HorizontalAlignment="Left" Height="21" Margin="440,96,0,0" TextWrapping="Wrap" Text="pl2 lives" VerticalAlignment="Top" Width="264" IsEnabled="False"/>

        <Button x:Name="btn_ko" Content="kő" HorizontalAlignment="Left" Height="31" Margin="194,167,0,0" VerticalAlignment="Top" Width="100" Click="btn_ko_Click"/>
        <Button x:Name="btn_papir" Content="papír" HorizontalAlignment="Center" Height="31" Margin="0,167,0,0" VerticalAlignment="Top" Width="100" Click="btn_papir_Click"/>
        <Button x:Name="btn_ollo" Content="olló" HorizontalAlignment="Left" Height="31" Margin="522,167,0,0" VerticalAlignment="Top" Width="100" Click="btn_ollo_Click"/>

        <TextBox x:Name="tb_player1Choice" HorizontalAlignment="Left" Height="21" Margin="112,240,0,0" TextWrapping="Wrap" Text="pl1 choice" VerticalAlignment="Top" Width="264" IsEnabled="False"/>
        <TextBox x:Name="tb_player2Choice" HorizontalAlignment="Left" Height="21" Margin="440,240,0,0" TextWrapping="Wrap" Text="pl2 choice" VerticalAlignment="Top" Width="264" IsEnabled="False"/>
        <TextBox x:Name="tb_info" HorizontalAlignment="Left" Height="86" Margin="114,302,0,0" TextWrapping="Wrap" Text="Info" VerticalAlignment="Top" Width="590" IsEnabled="False"/>

    </Grid>
</Window>

```
</details>

<details>
<summary>Nyiss le a MainWindow.xaml.cs forrásáért!</summary>
### `MainWindow.xaml.cs` példa:
```c#
using ClassLibrary.Classes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player player1;
        private Player player2;
        private Match match;
        private static Random _rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            player1 = new Player();
            tb_player1Name.Text = player1.Name;
            tb_player1Lives.Text=player1.Lives.ToString();
            player2 = new Player();
            tb_player2Name.Text = player2.Name;
            tb_player2Lives.Text=player2.Lives.ToString();   
            match = new Match(player1, player2);
        }


        private void PlayRound(int choice)
        {
            player1.Hand = _rnd.Next(3) + 1;
            tb_player1Choice.Text = player1.GetHandAsString();
            player2.Hand = choice;
            tb_player2Choice.Text = player2.GetHandAsString();
            match.NextRound();
            tb_player1Lives.Text = player1.Lives.ToString();
            tb_player2Lives.Text = player2.Lives.ToString();
            tb_info.Text = match.Info();
            if (match.IsFinished)
            {
                MessageBox.Show($"{match.GameWinner} játékos nyert!");
                this.Close();
            }
        }

        private void btn_ko_Click(object sender, RoutedEventArgs e)
        {
            PlayRound(1);
        }

        private void btn_papir_Click(object sender, RoutedEventArgs e)
        {
            PlayRound(2);
        }

        private void btn_ollo_Click(object sender, RoutedEventArgs e)
        {
            PlayRound(3);
        }

        private void tb_player2Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (player2 != null)
            {
                player2.Name = (sender as TextBox).Text;
            }
        }
    }
}
```
</details>

## 4. Hivatkozások beállítása:
-A konzolos és a WPF projektben is hozzá kell adnod a hivatkozást a ClassLibrary projektre. Ehhez kattints jobb gombbal a konzolos vagy WPF projekt nevére a Solution Explorer-ben, válaszd az "Add" > "Project Reference..." lehetőséget, majd válaszd ki a ClassLibrary projektet.
-Ezután a konzolos és a WPF projektben is ki kell adni a `using ClassLibrary.Classes;` utasítást
## 5. OOP_2_KPO.Tests projekt létrehozása
-Solution Explorer/Solution 'OOP_2_KPO'/Add/New Project
-OOP_2_KPO.Tests Test xUnit `.Net 8`
-A Dependencies / Add project References-ben add hozzá a ClassLibrary-t
-Hozd létre a tesztelő osztályokat (PlayerTests.cs, MatchTest.cs), ehhez kattints jobb gombbal a OOP_2_KPO.Tests-re > "Add" > "Class" lehetőségre. (Az alapértelmezett osztályt is át tudod nevezni!)

<details>
<summary>Nyiss le a PlayerTests.cs forrásáért!</summary>
### `PlayerTests.cs` példa:
```c#
using ClassLibrary.Classes;

namespace OOP_2_KPO.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void PlayerInitializationTest()
        {
            // Arrange
            var player = new Player(3, "TestPlayer");

            // Act & Assert
            Assert.Equal("TestPlayer", player.Name);
            Assert.Equal(3, player.Lives);
        }

        [Fact]
        public void PlayerHandTest()
        {
            // Arrange
            var player = new Player();
            player.Hand = 1;

            // Act
            var hand = player.GetHandAsString();

            // Assert
            Assert.Equal("kő", hand);
        }

        [Fact]
        public void PlayerFailTest()
        {
            // Arrange
            var player = new Player(3);

            // Act
            player.Fail();

            // Assert
            Assert.Equal(2, player.Lives);
        }

        [Fact]
        public void PlayerIsAliveTest()
        {
            // Arrange
            var player = new Player(1);

            // Act
            player.Fail();

            // Assert
            Assert.False(player.IsAlive);
        }
    }
}
```
</details>

<details>
<summary>Nyiss le a MatchTest.cs forrásáért!</summary>
### `MatchTest.cs` példa:
```c#
using ClassLibrary.Classes;

namespace OOP_2_KPO.Tests
{
    public class MatchTests
    {
        [Fact]
        public void MatchInitializationTest()
        {
            // Arrange
            var player1 = new Player();
            var player2 = new Player();
            var match = new Match(player1, player2);

            // Act & Assert
            Assert.NotNull(match);
        }

        [Fact]
        public void MatchNextRoundTest()
        {
            // Arrange
            var player1 = new Player();
            var player2 = new Player();
            var match = new Match(player1, player2);

            // Act
            player1.Hand = 1; // kő
            player2.Hand = 2; // papír
            match.NextRound();

            // Assert
            Assert.Equal(2, player1.Lives); // player1 veszít egy életet
            Assert.Equal(3, player2.Lives); // player2 nem veszít életet
        }

        [Fact]
        public void MatchIsFinishedTest()
        {
            // Arrange
            var player1 = new Player(1);
            var player2 = new Player();
            var match = new Match(player1, player2);

            // Act
            player1.Hand = 1; // kő
            player2.Hand = 2; // papír
            match.NextRound();

            // Assert
            Assert.True(match.IsFinished);
        }

        [Fact]
        public void MatchGameWinnerTest()
        {
            // Arrange
            var player1 = new Player(1, "Player1");
            var player2 = new Player(3, "Player2");
            var match = new Match(player1, player2);

            // Act
            player1.Hand = 1; // kő
            player2.Hand = 2; // papír
            match.NextRound();

            // Assert
            Assert.Equal("Player2", match.GameWinner);
        }
    }
}
```
</details>


