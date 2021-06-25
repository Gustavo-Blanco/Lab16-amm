using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab16.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab16.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchoolsPage : ContentPage
    {
        public SchoolsPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ListView.ItemsSource = await App.SchoolManager.GetTasksAsync();

        }
        async void OnAddItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SchoolPage(true)
            {
                BindingContext = new School()
                
            });
        }
        
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new SchoolPage()
            {
                BindingContext = e.SelectedItem as School
            });
        }
    }
}