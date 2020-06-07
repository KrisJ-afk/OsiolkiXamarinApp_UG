using SimpleXamarinApp_UG.GetWebContent;
using SimpleXamarinApp_UG.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace SimpleXamarinApp_UG
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private static List<Opis> opisyPszepienkne = new List<Opis>();

        public MainPage()
        {
            InitializeComponent();
            opisyPszepienkne = !opisyPszepienkne.Any() ? 
                new WebRestultContent().ReadSwienteOpisy().Result : opisyPszepienkne;
        }

        private async void NavigateButton_OnClicked2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecondPage(opisyPszepienkne.
                FirstOrDefault(x => x.Name.Equals("Lukownictwo")).Tresc));
        }

        private async void NavigateButton_OnClicked3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ThirdPage(opisyPszepienkne.
                FirstOrDefault(x => x.Name.Equals("Bejtownictwo")).Tresc));
        }

        private async void NavigateButton_OnClicked4(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FourthPage(opisyPszepienkne.
                FirstOrDefault(x => x.Name.Equals("Przykucnictwo")).Tresc));
        }

        private async void NavigateButton_OnClicked5(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FifthPage(opisyPszepienkne.
                FirstOrDefault(x => x.Name.Equals("Mimikownictwo")).Tresc));
        }

        private async void NavigateButton_OnClicked6(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewPage());
        }
    }
}
