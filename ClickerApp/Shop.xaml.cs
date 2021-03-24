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
            ScrollView scrollView = new ScrollView();
            scrollView.Scrolled += ScrollView_Scrolled;
            ShopListView.ItemsSource = itemlist.Items;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            
        }

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            Console.WriteLine($"ScrollX: {e.ScrollX}, ScrollY: {e.ScrollY}");
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
                    price = 10,
                    amount = 0
                },
                new Item
                {
                    name = "Fedora",
                    price = 100,
                    amount = 0
                },
                new Item
                {
                    name = "Waifu",
                    price = 1000,
                    amount = 0
                },
                new Item
                {
                    name = "Bodypillow",
                    price = 5000,
                    amount = 0
                },
            };
        }
    }
    public class Item
    {
        public string name { get; set; }
        public int price { get; set; }
        public int amount { get; set; }
    }
}