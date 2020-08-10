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

    // Promotions with the offer price.
    public class PromotionItems
    {
        public Dictionary<string, int> dictPromotionItems { get; set; }
        public int Price { get; set; }
    }

    // Active items having promotions.
    public class Promotions
    {
        public List<PromotionItems> lstPromotionItems = new List<PromotionItems>();
        public Promotions()
        {
            PromotionItems A = new PromotionItems();
            A.dictPromotionItems.Add("A", 3);
            A.Price = 130;
            lstPromotionItems.Add(A);

            PromotionItems B = new PromotionItems();
            B.dictPromotionItems.Add("B", 2);
            B.Price = 45;
            lstPromotionItems.Add(B);

            PromotionItems CD = new PromotionItems();
            CD.dictPromotionItems.Add("C", 1);
            CD.dictPromotionItems.Add("D", 1);
            CD.Price = 30;
            lstPromotionItems.Add(CD);
        }
    }


}
