using System;
using System.Collections.Generic;
using System.Linq;

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
    public class ActivePromotions
    {
        public List<PromotionItems> lstPromotionItems = new List<PromotionItems>();
        public ActivePromotions()
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

    public class BL
    {
        // Get the Promotion Offer Price.
        public int GetPromotionOfferPrice(Dictionary<string, int> dictOrder)
        {
            Items items = new Items();
            ActivePromotions promotions = new ActivePromotions();
            int totalPrice = 0;
            int promotionOfferPrice = 0;

            foreach (var promotion in promotions.lstPromotionItems)
            {
                int offerPrice = 0;

                var key = promotion.dictPromotionItems.First().Key;
                if (dictOrder.ContainsKey(key))
                {
                    int orderQty = dictOrder[key];
                    int offerQty = promotion.dictPromotionItems[key];
                    int offerCount = orderQty / offerQty;
                    int remainingQty = orderQty % offerQty;
                    dictOrder[key] = remainingQty;
                    offerPrice = offerCount * promotion.Price;
                }

                promotionOfferPrice = promotionOfferPrice + offerPrice;
            }

            var orderList = new List<string>(dictOrder.Keys);
            foreach (var order in orderList)
            {
                var price = items.dictSKU[order] * dictOrder[order];
                totalPrice = totalPrice + price;
            }
            return promotionOfferPrice + totalPrice;
        }
    }
}
