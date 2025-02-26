```xaml
<Window x:Class="Wpf_1_WORD1_0.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:Wpf_1_WORD1_0"
        xmlns:nud="clr-namespace:ControlLib;assembly=NumericUpDown"
        mc:Ignorable="d"
        Title="Word 1.0" Height="450" Width="800">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>

        <!-- 0. sor: Betűtípus, Betűstílus, Színek -->
        <StackPanel Grid.Row="0" Orientation="Horizontal" Margin="10" HorizontalAlignment="Center" >
            <!-- Betűtípus -->
            <StackPanel Margin="0,0,30,0">
                <TextBlock Text="Betűtípus:" Margin="0,0,10,0"/>
                <RadioButton x:Name="rbTimesNewRoman" Content="Times New Roman" GroupName="FontType" Checked="FontType_Checked"/>
                <RadioButton x:Name="rbArial" Content="Arial" GroupName="FontType" Checked="FontType_Checked"/>
                <RadioButton x:Name="rbCourierNew" Content="Courier New" GroupName="FontType" Checked="FontType_Checked"/>
            </StackPanel>

            <!-- Betűstílus -->
            <StackPanel Margin="30,0,30,0">
                <TextBlock Text="Betűstílus:" Margin="0,0,10,0"/>
                <CheckBox x:Name="cbBold" Content="Félkövér" Checked="FontStyle_Checked" Unchecked="FontStyle_Checked"/>
                <CheckBox x:Name="cbItalic" Content="Dőlt" Checked="FontStyle_Checked" Unchecked="FontStyle_Checked"/>
                <CheckBox x:Name="cbUnderline" Content="Aláhúzott" Checked="FontStyle_Checked" Unchecked="FontStyle_Checked"/>
            </StackPanel>
            
            <!-- Betűméret -->
            <StackPanel Margin="30,0,30,0">
                <TextBlock Text="Betűméret:" FontWeight="Bold" Margin="0,0,0,5"/>
                <nud:NumericUpDown Name="nudFontSize" MinValue="8" MaxValue="72" Value="14" ValueChanged="FontSize_ValueChanged" Width="50"/>
            </StackPanel>
            
            <!-- Színek -->
            <StackPanel Margin="30,0,30,0">
                <TextBlock Text="Betűszín:" FontWeight="Bold" Margin="0,0,0,5"/>
                <ComboBox Name="cbFontColor" SelectionChanged="FontColor_SelectionChanged" SelectedIndex="0" Width="100">
                    <ComboBoxItem Content="Fekete" Tag="Black"/>
                    <ComboBoxItem Content="Piros" Tag="Red"/>
                    <ComboBoxItem Content="Zöld" Tag="Green"/>
                    <ComboBoxItem Content="Kék" Tag="Blue"/>
                </ComboBox>
            </StackPanel>
            <StackPanel Margin="30,0,0,0">
                <TextBlock Text="Háttérszín:" FontWeight="Bold" Margin="0,0,0,5"/>
                <ComboBox Name="cbBackgroundColor" SelectionChanged="BackgroundColor_SelectionChanged" SelectedIndex="0" Width="100">
                    <ComboBoxItem Content="Fehér" Tag="White"/>
                    <ComboBoxItem Content="Sárga" Tag="Yellow"/>
                    <ComboBoxItem Content="Szürke" Tag="Gray"/>
                    <ComboBoxItem Content="Világoskék" Tag="LightBlue"/>
                </ComboBox>
            </StackPanel>
        </StackPanel>

```


```cs
namespace Wpf_1_WORD1_0
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FontType_Checked(object sender, RoutedEventArgs e)
        {
            if (rbTimesNewRoman.IsChecked == true)
                txtEditor.FontFamily = new FontFamily("Times New Roman");
            else if (rbArial.IsChecked == true)
                txtEditor.FontFamily = new FontFamily("Arial");
            else if (rbCourierNew.IsChecked == true)
                txtEditor.FontFamily = new FontFamily("Courier New");
        }

        private void FontStyle_Checked(object sender, RoutedEventArgs e)
        {
            txtEditor.FontWeight = cbBold.IsChecked == true ? FontWeights.Bold : FontWeights.Normal;
            txtEditor.FontStyle = cbItalic.IsChecked == true ? FontStyles.Italic : FontStyles.Normal;
            txtEditor.TextDecorations = cbUnderline.IsChecked == true ? TextDecorations.Underline : null;
        }

        private void FontSize_ValueChanged(object sender, ControlLib.ValueChangedEventArgs e)
        {
            if (txtEditor != null && nudFontSize.Value != null)
            {
                txtEditor.FontSize = nudFontSize.Value;
            }
        }

        private void FontColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtEditor != null && cbFontColor.SelectedItem is ComboBoxItem selectedItem)
            {
                string color = selectedItem.Tag.ToString();
                txtEditor.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
            }
        }

        private void BackgroundColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtEditor != null && cbBackgroundColor.SelectedItem is ComboBoxItem selectedItem)
            {
                string color = selectedItem.Tag.ToString();
                txtEditor.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txtEditor.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);
            }
        }


    }
}
```
