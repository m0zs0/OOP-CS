```xaml
<Window x:Class="Wpf_1_Word1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:nud="clr-namespace:ControlLib;assembly=NumericUpDown"
        xmlns:local="clr-namespace:Wpf_1_Word1"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition Height="*"/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <StackPanel Grid.Row="0" Orientation="Horizontal" HorizontalAlignment="Center" Margin="10">
            <StackPanel Margin="30,0,30,0">
                <TextBlock Text="Betutipus"/>
                <RadioButton x:Name="TimesNewRomanRadioButton" GroupName="FontFamily" Content="Times New Roman" IsChecked="True" Checked="FontFamily_Checked"/>
                <RadioButton x:Name="ArialRadioButton" GroupName="FontFamily" Content="Arial" Checked="FontFamily_Checked"/>
                <RadioButton x:Name="CourierNewRadioButton" GroupName="FontFamily" Content="Courier New" Checked="FontFamily_Checked"/>
            </StackPanel>
            <StackPanel Margin="30,0,30,0">
                <TextBlock Text="Betustilus"/>
                <CheckBox x:Name="BoldCheckBox" Content="Félkövér" Checked="FontStyle_Checked" Unchecked="FontStyle_Checked"/>
                <CheckBox x:Name="ItalicCheckBox" Content="Dölt" Checked="FontStyle_Checked" Unchecked="FontStyle_Checked" />
                <CheckBox x:Name="UnderlinedCheckBox" Content="Aláhúzott" Checked="FontStyle_Checked" Unchecked="FontStyle_Checked"/>
            </StackPanel>
            <StackPanel Margin="30,0,30,0">
                <TextBlock Text="Betűméret"/>
                <nud:NumericUpDown x:Name="nudFontSize" MinValue="8" MaxValue="72" Value="14" ValueChanged="FontSize_ValueChanged" Width="50"/>
            </StackPanel>
            <StackPanel Margin="30,0,30,0">
                <TextBlock Text="Betűszín" />
                <ComboBox SelectedIndex="0" SelectionChanged="ComboBox_SelectionChanged" Width="100">
                    <ComboBoxItem Content="Kék" Tag="Blue"/>
                    <ComboBoxItem Content="Zöld" Tag="Green"/>
                    <ComboBoxItem Content="Piros" Tag="Red"/>
                    <ComboBoxItem Content="Fekete" Tag="Black"/>
                </ComboBox>
            </StackPanel>
            <StackPanel Margin="30,0,30,0">
                <TextBlock Text="Háttérszín" />
                <ComboBox x:Name="BackgroundComboBox" SelectedIndex="0" SelectionChanged="BackgroundComboBox_SelectionChanged" Width="100">
                    <ComboBoxItem Content="Fehér" Tag="White"/>
                    <ComboBoxItem Content="Sárga" Tag="Yellow"/>
                    <ComboBoxItem Content="Szürke" Tag="Gray"/>
                    <ComboBoxItem Content="VilágosKék" Tag="LightBlue"/>
                </ComboBox>
            </StackPanel>
        </StackPanel>
        <StackPanel Grid.Row="1">
            <TextBox x:Name="TextTextBox" TextWrapping="Wrap" Text="TextBox" Width="800" Height="145" FontFamily="Times New Roman"/>
        </StackPanel>
        <StackPanel Grid.Row="2" Orientation="Horizontal" HorizontalAlignment="Center">
            <Button x:Name="LoadButton" Content="Betöltés" Height="30" Padding="10,5,10,5" Margin="0,0,100,0" Click="LoadButton_Click"/>
            <Button x:Name="SaveButton" Content="Mentés" Height="30" Padding="10,5,10,5"  Margin="100,0,0,0" Click="SaveButton_Click"/>
        </StackPanel>


    </Grid>
</Window>

```


```cs
using Microsoft.Win32;
using System.Printing;
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
using System.IO;

namespace Wpf_1_Word1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FontFamily_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radio && TextTextBox != null)
            {
                TextTextBox.FontFamily = new FontFamily(radio.Content.ToString());
            }
        }

        private void FontStyle_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkbox)
            {
                string style = checkbox.Content.ToString();
                if (style == "Félkövér")
                {
                    TextTextBox.FontWeight = checkbox.IsChecked == true ? FontWeights.Bold : FontWeights.Normal;
                }
                else if (style == "Dölt")
                {
                    TextTextBox.FontStyle = checkbox.IsChecked == true ? FontStyles.Italic : FontStyles.Normal;
                }
                else if (style == "Aláhúzott")
                {
                    TextTextBox.TextDecorations = checkbox.IsChecked == true ? TextDecorations.Underline : null;
                }
            }
        }

        private void FontSize_ValueChanged(object sender, ControlLib.ValueChangedEventArgs e)
        {
            if (TextTextBox != null && nudFontSize.Value != null)
            {
                TextTextBox.FontSize = nudFontSize.Value;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TextTextBox != null && sender is ComboBox comboBox  && comboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string color= selectedItem.Tag.ToString();
                TextTextBox.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
            }
            
        }

        private void BackgroundComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TextTextBox != null && sender is ComboBox comboBox && comboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string color = selectedItem.Tag.ToString();
                TextTextBox.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, TextTextBox.Text);
                MessageBox.Show("A mentés megtörtént.");
            }
                
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                TextTextBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
                
        }
    }
}
```
