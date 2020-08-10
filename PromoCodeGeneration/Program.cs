using System;
using System.Collections.Generic;

namespace PromoCodeGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    // All items in SKU.
    public class Items
    {
        public Dictionary<string, int> dictSKU = new Dictionary<string, int>();
        public Items()
        {
            dictSKU.Add("A", 50);
            dictSKU.Add("B", 30);
            dictSKU.Add("C", 20);
            dictSKU.Add("D", 15);
            dictSKU.Add("CD", 30);
        }
    }
}
