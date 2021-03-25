using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;
using Database;


namespace ClickerApp
{
    public partial class MainPage : ContentPage
    {
        private string username;
        double karma;
        double income;
        double clickPower;
        int totalClicks;


        public Building katana = new Building()
        {
            id = 1,
            name = "Katana",
            amount = 0,
            cost = 15,
            value = 0.05,
            upgrades = 1
        };
        public Building fedora = new Building()
        {
            id = 2,
            name = "Fedora",
            amount = 0,
            cost = 100,
            value = 0.5,
            upgrades = 1
        };

        public Building waifu = new Building()
        {
            id = 3,
            name = "Waifu",
            amount = 3,
            cost = 1100,
            value = 4,
            upgrades = 1
        };

        public Building bodypillow = new Building()
        {
            id = 4,
            name = "Bodypillow",
            amount = 0,
            cost = 12000,
            value = 24,
            upgrades = 1
        };
        public MainPage()
        {
            InitializeComponent();
            YourUser();
        }

        public bool Check(string username)
        {
            if(username == null || username == "")
            {
                YourUser();
                return false;                
            }
            else
            {
                return true;
            }  
        }

        async void YourUser()
        {

            string answer = await DisplayPromptAsync("Username", "What your username", placeholder: "Username", cancel: "");
             Debug.WriteLine("Answer: " + answer);
            YourUsername.Title = answer;
            username = answer;
            Check(answer);
        }

        public void Building(int upgrade)
            Timer timer = new Timer(Tick, null, 0, 1000);
        }
        public void Building(int upgrade)
        {
            
            switch (upgrade)
            {
                case 1:
                    double cost1 = 15 * Math.Pow(1.15, katana.amount);
                    if (karma >= cost1)
                    {
                        karma -= cost1;
                        katana.amount += 1;
                    }
                    break;

                case 2:
                    double cost2 = 100 * Math.Pow(1.15, fedora.amount);
                    if (karma >= cost2)
                    {
                        karma -= cost2;
                        fedora.amount += 1;
                    }
                    break;

                case 3:
                    double cost3 = 1100 * Math.Pow(1.15, waifu.amount);
                    if (karma >= cost3)
                    {
                        karma -= cost3;
                        waifu.amount += 1;
                    }
                    break;

                case 4:
                    double cost4 = 12000 * Math.Pow(1.15, bodypillow.amount);
                    if (karma >= cost4)
                    {
                        karma -= cost4;
                        bodypillow.amount += 1;
                    }
                    break;
            }
        }

        public void Upgrade(int upgrade)
        {
            switch (upgrade)
            {
                case 1:
                    if (karma > katana.cost * 10 * Math.Pow(10, katana.upgrades -1))
                    {
                        katana.upgrades += 1;
                    }
                    break;

                case 2:
                    if (karma > fedora.cost * 10 * Math.Pow(10, fedora.upgrades -1))
                    {
                        fedora.upgrades += 1;
                    }
                    break;

                case 3:
                    if (karma > waifu.cost * 10 * Math.Pow(10, waifu.upgrades -1))
                    {
                        waifu.upgrades += 1;
                    }
                    break;

                case 4:
                    if (karma > bodypillow.cost * 10 * Math.Pow(10, bodypillow.upgrades -1))
                    {
                        bodypillow.upgrades += 1;
                    }
                    break;
            }
        }

        void Tick(object o)
        {
            Console.WriteLine("Income attempt");
            income = (katana.amount * katana.value * katana.upgrades * 2)
                   + (fedora.amount * fedora.value * fedora.upgrades * 2)
                   + (waifu.amount * waifu.value * waifu.upgrades * 2)
                   + (bodypillow.amount * bodypillow.value * bodypillow.upgrades * 2);
            karma += income;

            Device.BeginInvokeOnMainThread(() => {
                int LL = (int)Math.Round(karma);
                int LL2 = (int)Math.Round(income);
                youPoints.Text = LL.ToString();
                youIncome.Text = LL2.ToString();

            });
            
        }
        void Click(object sender, EventArgs e)
        {
            clickPower = 1 + (income * 0.1 * katana.upgrades);

            karma += clickPower;
            totalClicks++;
            int LL = (int)Math.Round(karma);
            youPoints.Text = LL.ToString();
            youClicks.Text = totalClicks.ToString();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Shop());
        }

        private void Username(object sender, EventArgs e)
        {
            YourUser();
        }
    }
}
