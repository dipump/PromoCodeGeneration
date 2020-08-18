using NUnit.Framework;
using PromoCodeGeneration;
using System.Collections.Generic;

namespace PromotionTest
{
    public class PromotionUnitTests
    {
        BL objPromotion = new BL();

        [Test, TestCaseSource("OrderScenarioA")]
        public void ScenarioA(Dictionary<string, int> dictOrder, int expectedTotal)
        {
            int total = objPromotion.GetPromotionOfferPrice(dictOrder);
            Assert.AreEqual(total, expectedTotal);
        }

        [Test, TestCaseSource("OrderScenarioB")]
        public void ScenarioB(Dictionary<string, int> dictOrder, int expectedTotal)
        {
            int total = objPromotion.GetPromotionOfferPrice(dictOrder);
            Assert.AreEqual(total, expectedTotal);
        }

        [Test, TestCaseSource("OrderScenarioC")]
        public void ScenarioC(Dictionary<string, int> dictOrder, int expectedTotal)
        {
            int total = objPromotion.GetPromotionOfferPrice(dictOrder);
            Assert.AreEqual(total, expectedTotal);
        }

        [Test, TestCaseSource("OrderAllTogether")]
        public void AllTogether(Dictionary<string, int> dictOrder, int expectedTotal)
        {
            int total = objPromotion.GetPromotionOfferPrice(dictOrder);
            Assert.AreEqual(total, expectedTotal);
        }

        static object[] OrderScenarioA =
        {
            new object[]{new Dictionary<string, int>(){{"A",1},{"B",1},{"C",1}},100 }
        };

        static object[] OrderScenarioB =
        {
            new object[]{new Dictionary<string, int>(){{"A",5},{"B",5},{"C",1}},370 }
        };

        static object[] OrderScenarioC =
        {
            new object[]{new Dictionary<string, int>(){{"A",3},{"B",5},{"C",1},{"D",1}},280 }
        };

        static object[] OrderAllTogether =
        {
            new object[]{new Dictionary<string, int>(){{"A",1},{"B",1},{"C",1}},100 },
            new object[]{new Dictionary<string, int>(){{"A",5},{"B",5},{"C",1}},370 },
            new object[]{new Dictionary<string, int>(){{"A",3},{"B",5},{"C",1},{"D",1}},280 }
        };

    }
}
