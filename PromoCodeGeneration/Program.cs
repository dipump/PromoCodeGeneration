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
        //public Dictionary<string, int> dictPromotionItems { get; set; }
        //public int Price { get; set; }

        public Dictionary<string, int> dictPromotionItems = new Dictionary<string, int>();
        public int Price;

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
                var offer = GeneratePromotion(promotion, dictOrder);
                promotionOfferPrice = promotionOfferPrice + offer;
            }


            var lstOrder = new List<string>(dictOrder.Keys);
            foreach (var order in lstOrder)
            {
                var price = items.dictSKU[order] * dictOrder[order];
                totalPrice = totalPrice + price;
                Console.WriteLine("Offer:{0} => {1}", price, totalPrice);
            }
            Console.WriteLine("Offer:{0}", totalPrice);
            return promotionOfferPrice + totalPrice;
        }

        // Generate promotions.
        int GeneratePromotion(PromotionItems promotionItems, Dictionary<string, int> dictOrder)
        {

            if (promotionItems.dictPromotionItems.Count == 1)
            {
                // Single item
                var key = promotionItems.dictPromotionItems.ElementAt(0).Key;
                if (dictOrder.ContainsKey(key))
                {
                    int orderQty = dictOrder[key];
                    int offerQty = promotionItems.dictPromotionItems[key];
                    int offersCount = orderQty / offerQty;
                    int remainingQty = orderQty % offerQty;
                    dictOrder[key] = remainingQty;
                    return offersCount * promotionItems.Price;
                }
            }
            else
            {
                // Multiple items
                var key1 = promotionItems.dictPromotionItems.ElementAt(0).Key;
                var key2 = promotionItems.dictPromotionItems.ElementAt(1).Key; ;
                if (dictOrder.ContainsKey(key1) && dictOrder.ContainsKey(key2))
                {
                    int orderQty1 = dictOrder[key1];
                    int offerQty1 = promotionItems.dictPromotionItems[key1];
                    int offersCount1 = orderQty1 / offerQty1;
                    int remainingQty1 = orderQty1 % offerQty1;

                    int orderQty2 = dictOrder[key2];
                    int offerQty2 = promotionItems.dictPromotionItems[key2];
                    int offersCount2 = orderQty2 / offerQty2;
                    int remainingQty2 = orderQty2 % offerQty2;

                    if (offersCount1 <= offersCount2)
                    {
                        dictOrder[key1] = remainingQty1;
                        dictOrder[key2] = remainingQty2 + (offerQty2 * (offersCount2 - offersCount1));
                        return offersCount1 * promotionItems.Price;
                    }
                    else
                    {
                        dictOrder[key1] = remainingQty1 + (offerQty1 * (offersCount1 - offersCount2));
                        dictOrder[key2] = remainingQty2;
                        return offersCount2 * promotionItems.Price;
                    }
                }
            }
            return 0;
        }
    }
}
