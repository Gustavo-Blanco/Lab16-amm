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
    public partial class SchoolPage : ContentPage
    {
        private bool _isNew;

        public SchoolPage(bool isNew = false)
        {
            InitializeComponent();
            _isNew = isNew;
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var school = (School)BindingContext;
            await App.SchoolManager.SaveTaskAsync(school, _isNew);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var todoItem = (School)BindingContext;
            await App.SchoolManager.DeleteTaskAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}