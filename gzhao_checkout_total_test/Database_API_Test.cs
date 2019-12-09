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
            Database_API.AddItem("Beef", 10);
            
            Assert.AreEqual(1,Database_API.Count());

            Database_API.Clean();
        }

        [TestMethod]
        public void Test_Roster_Add_Remove()
        {
            Database_API.AddItem("Beef", 10);

            Database_API.Remove("Beef");

            Assert.AreEqual(0,Database_API.Count());

            Database_API.Clean();
        }

        [TestMethod]
        public void Test_Roster_Add_Not_Duplicate()
        {
            Database_API.AddItem("Beef", 10);
            Database_API.AddItem("Beef", 10);

            Assert.AreEqual(1, Database_API.Count());

            Database_API.Clean();
        }

        [TestMethod]
        public void Test_Roster_Remove_One()
        {
            Database_API.AddItem("Beef", 10);
            Database_API.AddItem("Chicken", 10);
            Database_API.AddItem("Peas", 10);

            Database_API.Remove("Beef");

            Assert.AreEqual(2, Database_API.Count());

            Database_API.Clean();
        }
    }
}
