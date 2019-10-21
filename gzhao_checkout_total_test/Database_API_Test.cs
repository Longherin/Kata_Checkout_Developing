using Microsoft.VisualStudio.TestTools.UnitTesting;
using gzhao_checkout_total;

namespace gzhao_checkout_total_test
{
    [TestClass]
    public class Database_API_Test
    {
        [TestMethod]
        public void Test_Add_One_To_Roster()
        {
            Database_API roster = new Database_API();

            roster.AddToList(new Item("Beef", 10, true));

            Assert.AreEqual(roster.ItemListCount(), 1);
        }

        [TestMethod]
        public void Test_Roster_Add_Remove()
        {
            Database_API roster = new Database_API();

            roster.AddToList(new Item("Beef", 10, true));

            roster.RemoveFromList("Beef");

            Assert.AreEqual(roster.ItemListCount(), 0);
        }

        [TestMethod]
        public void Test_Roster_Add_Remove_Case()
        {
            Database_API roster = new Database_API();

            roster.AddToList(new Item("Beef", 10, true));

            roster.RemoveFromList("beef");

            Assert.AreEqual(roster.ItemListCount(), 0);
        }
    }
}
