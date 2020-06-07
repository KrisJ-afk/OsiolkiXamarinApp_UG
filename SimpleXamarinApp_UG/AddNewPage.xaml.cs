using SimpleXamarinApp_UG.GetWebContent;
using SimpleXamarinApp_UG.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleXamarinApp_UG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewPage : ContentPage
    {
        public AddNewPage()
        {
            InitializeComponent();
        }

        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void AddOpisik_OnClicked(object sender, EventArgs e)
        {
            var eNazwa = entryNazwa.Text?.Trim();
            var eTresc = editorTresc.Text?.Trim();
            eNazwa = string.IsNullOrEmpty(eNazwa) ? "NowyNiepodanyZostal" : eNazwa;
            eTresc = string.IsNullOrEmpty(eTresc) ? "NowyNiepodanyZostal" : eTresc;
            var nOpis = new Opis { Name = eNazwa, Tresc = eTresc };
            var w = new WebRestultContent();
            w.DodawanieOpisiku(nOpis);
            await Navigation.PushAsync(new MainPage());
        }
    }
}