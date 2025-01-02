# Mobilalkalmazásfejlesztés

<details>
<summary>Használt REST API</summary>

```
https://zip-api.eu/api/v1/info/HU-5310
{"country_code":"HU","postal_code":"5310","state":"J\u00e1sz-Nagykun-Szolnok","place_name":"Kis\u00fajsz\u00e1ll\u00e1s","lat":"47.21670000","lng":"20.76670000"}

https://zip-api.eu/api/v1/codes/place_name=HU-Kisújszállás

{"country_code":"HU","state":"J\u00e1sz-Nagykun-Szolnok","place_name":"Kis\u00fajsz\u00e1ll\u00e1s","postal_code":"5310","lat":"47.21670000","lng":"20.76670000"}
```
</details>


## .NET MAUI fejlesztői környezet telepítése VS2022 alá
-Visual Studio Installer megnyitása
-"Modify" gomb a Visual Studio 2022 mellett
-A "Workloads" fül alatt a ".NET Multi-platform App UI development" opció bejelölése (Xamarin nem kell)
-"Install" gomb

## Első .NET MAUI projekt létrehozása:
-"Create a new project" / ".NET MAUI App" / cityzip

### ApiService.cs
```c#
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cityzip
{
    internal class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetStringAsync(string url)
        {
            return await _httpClient.GetStringAsync(url);
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}
```

### MainPage.xaml
```c#
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="cityzip.MainPage">

    <StackLayout Padding="10">
        <Picker x:Name="CityPicker" Title="Válassz egy várost" SelectedIndexChanged="OnCitySelected">
            <Picker.ItemsSource>
                <x:Array Type="{x:Type x:String}">
                    <x:String>Kisújszállás</x:String>
                    <x:String>Karcag</x:String>
                    <x:String>Kunhegyes</x:String>
                </x:Array>
            </Picker.ItemsSource>
        </Picker>
        <Label x:Name="RequestUrlLabel" Text="Kérés URL-je" FontSize="Small" HorizontalOptions="Center" VerticalOptions="CenterAndExpand" />
        <Label x:Name="JsonResponseLabel" Text="JSON válasz" FontSize="Small" HorizontalOptions="Center" VerticalOptions="CenterAndExpand" />
        <Label x:Name="PostalCodeLabel" Text="Irányítószám" FontSize="Large" HorizontalOptions="Center" VerticalOptions="CenterAndExpand" />
    </StackLayout>
</ContentPage>
```

### MainPage.xaml.cs

```c#
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;

namespace cityzip
{
    public partial class MainPage : ContentPage
    {
        private readonly ApiService _apiService;

        public MainPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void OnCitySelected(object sender, EventArgs e)
        {
            var selectedCity = CityPicker.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedCity))
            {
                var requestUrl = $"https://zip-api.eu/api/v1/codes/place_name=HU-{selectedCity}";
                RequestUrlLabel.Text = $"Kérés URL-je: {requestUrl}";
                
                var jsonResponse = await _apiService.GetStringAsync(requestUrl);
                JsonResponseLabel.Text = $"JSON válasz: {jsonResponse}";

                var cityInfo = await _apiService.GetAsync<CityInfo>(requestUrl);
                PostalCodeLabel.Text = $"Irányítószám: {cityInfo.PostalCode}";
            }
        }
    }

    public class CityInfo
    {
        [JsonProperty("place_name")]
        public string PlaceName { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
    }

}
```


## Android emulátor indítása:
(
grafikus kártya driver frissítés ajánlott!
Hyper-V és a Windows Hypervisor Platform engedélyezése:
Nyisd meg a Control Panel-t, majd válaszd a Programs and Features lehetőséget.
Kattints a Turn Windows features on or off opcióra.
Jelöld be a Hyper-V és a Windows Hypervisor Platform lehetőségeket.
Indítsd újra a számítógépedet

Elvileg lehet fizikai eszközön is tezstelni, de ezt nem próbáltam:
Fizikai eszköz beállítása fejlesztéshez:
Csatlakoztasd az Android eszközödet a számítógépedhez USB kábellel.
Az eszközön nyisd meg a Settings alkalmazást, majd válaszd az About phone lehetőséget.
Koppints hétszer a Build number mezőre, hogy engedélyezd a fejlesztői módot.
Menj vissza a Settings menübe, válaszd a Developer options lehetőséget, és kapcsold be az USB debugging opciót
)


"Tools" menü / "Android" / "Android Device Manager" / "New"
Válaszd ki az alap eszközt (Pixel 5 - API34), és állítsd be hw.gpo.mode paramétert "off"-ra (nekem nVidia gtx750 volt ekkor).
"Create"
"Start" ekkor elindul az emulátor

Az IDE-ben válaszd ki a kívánt eszközt, a "zöld nyíl"-tól jobbra, majd kattints a zöld nyílra

Lehet a telepítés után az emulátoron ki és bekapcsolni szükséges a telót.


## APK készítés:

Solution Explorer / Properties / Android / Options
Győződj meg róla, hogy a Release mező értéke apk.
Zöld nyíl melletti nyilat legördíteni /  Configure startup project / Configuration Properties/ Configuration / Release konfiguráció választása
A Solution Explorer / Publish...
Az Archive Manager megnyílik, és a Visual Studio elkezdi archiválni az alkalmazásodat.
Archívum kiválasztása / Distribute... / Ad Hoc
A Distribute - Signing Identity párbeszédablakban kattints a + gombra egy új aláírási identitás létrehozásához.
A Create Android Keystore párbeszédablakban add meg a szükséges információkat az új aláírási identitás létrehozásához, majd kattints a Create gombra.
Alias: Adj egy azonosító nevet a kulcsnak.
Password: Hozz létre és erősíts meg egy biztonságos jelszót a kulcshoz.
Validity: Állítsd be a kulcs érvényességi idejét években.
Full name, organization unit, organization, city or locality, state or province, and country code: Add meg a szükséges információkat.
Miután létrehoztad az aláírási identitást, a Visual Studio létrehozza az aláírt APK fájlt, amelyet letölthetsz és telepíthetsz az Android eszközödre

[https://drive.google.com/file/d/1XTKDbmRlp2-rMhWejWcsMuzhkAnVo8Ke/view?usp=sharing](https://drive.google.com/file/d/1XTKDbmRlp2-rMhWejWcsMuzhkAnVo8Ke/view?usp=sharing)
