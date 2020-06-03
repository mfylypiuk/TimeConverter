using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using TimeConverter.Views;

namespace TimeConverter.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<string> Items { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Converter";
            Items = new ObservableCollection<string>()
            {
                "Nanoseconds", "Microsecond", "Second", "Minute", "Hour", "Day", "Week", "Year"
            };
        }
    }
}