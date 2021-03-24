using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClickerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Shop : ContentPage
    {
        public Shop()
        {
            InitializeComponent();
            ShopListView.ItemsSource = itemlist.Items;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
    public static class itemlist{
        public static IList<Item> Items { get; set; }
    static itemlist()
        {
            Items = new ObservableCollection<Item>()
            {
                new Item
                {
                    name = "Katana",
                    price = 10
                },
                new Item
                {
                    name = "fedora",
                    price = 100
                },
                new Item
                {
                    name = "waifu",
                    price = 1000
                },
                new Item
                {
                    name = "bodypillow",
                    price = 5000
                },
            };
        }
    }
    public class Item
    {
        public string name { get; set; }
        public int price { get; set; }
    }
}