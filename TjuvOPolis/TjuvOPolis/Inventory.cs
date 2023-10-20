using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOPolis
{
    public class Inventory
    {
        public string Wallet { get; set; }
        public string Phone { get; set; }
        public string Keys { get; set; }
        public string Watch { get; set; }

        public Inventory(string wallet, string phone, string keys, string watch)
        {
            Wallet = "wallet";
            Phone = "phone";
            Keys = "keys";
            Watch = "watch";
        }

        public static string[] Backpack()
        {
            string[] backpack = new string[]{"wallet", "phone", "keys", "watch"};
            return backpack;
        }
    }
}
