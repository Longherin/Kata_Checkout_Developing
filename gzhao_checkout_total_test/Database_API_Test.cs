using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gzhao_checkout_total;

namespace Gzhao_checkout_total_test
{
    [TestClass]
    public class Database_API_Test
    {
        [TestMethod]
        public void Test_Add_One_To_Roster()
        {
            Database_API roster = new Database_API();

            roster.AddToList("Beef", 10);

            Assert.AreEqual(1,roster.ItemListCount());
        }

        [TestMethod]
        public void Test_Roster_Add_Remove()
        {
            Database_API roster = new Database_API();

            roster.AddToList("Beef", 10);

            roster.RemoveSpecific("Beef");

            Assert.AreEqual(0,roster.ItemListCount());
        }

        [TestMethod]
        public void Test_Roster_Add_Remove_Case()
        {
            Database_API roster = new Database_API();

            roster.AddToList("Beef", 10);

            roster.RemoveSpecific("beef");

            Assert.AreEqual(0, roster.ItemListCount());
        }

        [TestMethod]
        public void Test_Roster_Add_Remove_Last()
        {
            Database_API roster = new Database_API();

            roster.AddToList("Beef", 10);
            roster.AddToList("Chicken", 10);
            roster.AddToList("Peas", 10);

            roster.RemoveLast();

            Assert.AreEqual(2, roster.ItemListCount());
        }
    }
}
