using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClickerApp
{
    public partial class MainPage : ContentPage
    {
        double karma;
        double income;
        double clickPower;

        Building katana = new Building() {
            amount = 0,
            cost = 15,
            value = 0.1,
            upgrades = 0
        };
        Building fedora = new Building()
        {
            amount = 0,
            cost = 100,
            value = 1,
            upgrades = 0
        };

        Building waifu = new Building()
        {
            amount = 0,
            cost = 1100,
            value = 8,
            upgrades = 0
        };

        Building bodypillow = new Building()
        {
            amount = 0,
            cost = 12000,
            value = 47,
            upgrades = 0
        };
        public MainPage()
        {
            InitializeComponent();
        }

        void Building(int upgrade)
        {
            switch (upgrade)
            {
                case 1:
                    double cost1 = 15 * Math.Pow(1.15, katana.amount);
                    if ( karma >= cost1)
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

        void Upgrade(int upgrade)
        {
            switch (upgrade)
            {
                case 1:
                    if (karma > katana.cost * 10 * Math.Pow(10, katana.upgrades))
                    {
                        katana.upgrades += 1;
                    }
                    break;

                case 2:
                    if (karma > fedora.cost * 10 * Math.Pow(10, fedora.upgrades))
                    {
                        fedora.upgrades += 1;
                    }
                    break;

                case 3:
                    if (karma > waifu.cost * 10 * Math.Pow(10, waifu.upgrades))
                    {
                        waifu.upgrades += 1;
                    }
                    break;

                case 4:
                    if (karma > bodypillow.cost * 10 * Math.Pow(10, bodypillow.upgrades))
                    {
                        bodypillow.upgrades += 1;
                    }
                    break;
            }
        }

        void Tick()
        {
            income = (katana.amount * katana.value * katana.upgrades * 2)
                   + (fedora.amount * fedora.value * fedora.upgrades * 2)
                   + (waifu.amount * waifu.value * waifu.upgrades * 2)
                   + (bodypillow.amount * bodypillow.value * bodypillow.upgrades * 2);
            karma += income;
        }

        void Click()
        {
            clickPower = 1 + (income * 0.1 * katana.upgrades);

            karma += clickPower;
        }
    }
}
