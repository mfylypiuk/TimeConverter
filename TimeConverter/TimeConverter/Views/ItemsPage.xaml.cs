using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TimeConverter.Views;
using TimeConverter.ViewModels;
using TimeConverter.Enums;

namespace TimeConverter.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void Convert_Clicked(object sender, EventArgs e)
        {
            if (ItemsCollectionView_From.SelectedItem == null || ItemsCollectionView_To.SelectedItem == null)
            {
                return;
            }

            TimeType from = (TimeType)Enum.Parse(typeof(TimeType), ItemsCollectionView_From.SelectedItem.ToString());
            TimeType to = (TimeType)Enum.Parse(typeof(TimeType), ItemsCollectionView_To.SelectedItem.ToString());
            await Navigation.PushModalAsync(new NavigationPage(new ConverterPage(from, to)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}