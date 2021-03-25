using System;

namespace Model
{
    public class Save
    {
        public string Username { get; set; }
        public double Karma { get; set; }
        public Building katana { get; set; }
        public Building fedora { get; set; }
        public Building waifu { get; set; }
        public Building bodypillow { get; set; }
    }
    public class Building
    {
        public int id { get; set; }
        public string name { get; set; }
        public double amount { get; set; }
        public double cost { get; set; }
        public double value { get; set; }
        public double upgrades { get; set; }
    }
}
