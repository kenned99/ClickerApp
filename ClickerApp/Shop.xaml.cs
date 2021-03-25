using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Model;

namespace ClickerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Shop : ContentPage
    {
        MainPage main = new MainPage();
        public Shop()
        {
            InitializeComponent();
            ScrollView scrollView = new ScrollView();
            scrollView.Scrolled += ScrollView_Scrolled;
            ShopListView.ItemsSource = BuildingList();
        }
        


        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            Console.WriteLine($"ScrollX: {e.ScrollX}, ScrollY: {e.ScrollY}");
        }

        private void Add(object sender, EventArgs e)
        {
            
        }

        void JustBuyAHouse(object sender, EventArgs e)
        {
            int tempID = 0;
            foreach (var item in bList)
            {
                if (Int32.Parse(sender.ToString()) == item.id)
                {
                    tempID = item.id;
                    break;
                }
            }
            main.Building(tempID);
        }

         List<Building> bList = new List<Building>();
        private List<Building> BuildingList()
        {
            bList.Add(main.katana);
            bList.Add(main.fedora);
            bList.Add(main.waifu);
            bList.Add(main.bodypillow);
            return bList;
        }
         
    }

    /*
    public static class itemlist
        {
            public static IList<item> Items { get; set; }
            static itemlist()
            {
                MainPage page = new MainPage();
                Items = new ObservableCollection<item>()
            {
                new item{
                    name = "Katana",
                    cost = page.katana.cost,
                    amount = page.katana.amount
                },
                new item{
                    name = "Katana Upgrade",
                    cost = page.katana.cost * 10 * Math.Pow(10, page.katana.upgrades),
                    amount = page.katana.upgrades
                },
                new item{
                    name = "Fedora",
                    cost = page.fedora.cost,
                    amount = page.fedora.amount
                },
                new item{
                    name = "Fedora Upgrade",
                    cost = page.fedora.cost,
                    amount = page.fedora.upgrades
                },
                new item{
                    name = "Waifu",
                    cost = page.waifu.cost,
                    amount = page.waifu.amount
                },
                new item{
                    name = "Waifu Upgrade",
                    cost = page.waifu.cost,
                    amount = page.waifu.upgrades
                },
                new item{
                    name = "Bodypillow",
                    cost = page.bodypillow.cost,
                    amount = page.bodypillow.amount
                },
                new item{
                    name = "Bodypillow Upgrade",
                    cost = page.waifu.cost,
                    amount = page.waifu.upgrades
                },
            };

            }
        }

        public class item
        {
            public string name { get; set; }
            public double cost { get; set; }
            public double amount { get; set; }
    }
    */
}
   