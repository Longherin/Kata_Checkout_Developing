using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gzhao_checkout_total;

namespace Gzhao_checkout_total_test
{
    [TestClass]
    public class PurchaseItemManager_Test
    {
        public void BuildItems()
        {
            //Items that sell by weight
            Database_API.AddItem("Beef", 10, true);
            Database_API.AddItem("Chicken", 10, true);
            Database_API.AddItem("Peas", 10, true);

            //Items that sell by unit
            Database_API.AddItem("Soup", 5);
            Database_API.AddItem("Pencils", 6);
            Database_API.AddItem("Carpet", 100);
        }


        [TestMethod]
        public void Test_Buy_Item()
        {
            BuildItems();

            PurchaseItemManager pim = new PurchaseItemManager();

            pim.Add("Beef", 1);
            pim.Add("Chicken", 1);

            Assert.AreEqual(2, pim.TotalPurchasedEntries());
           // Assert.AreEqual(20, pim.TotalPurchase());
        }
    }
}
