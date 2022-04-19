using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void ShopCtorTest()
        {
            Shop shop = new Shop(100);
            Assert.AreEqual(0, shop.Count);
            Assert.AreEqual(100, shop.Capacity);
            Assert.Throws<ArgumentException>(() => shop = new Shop(-1));
        }
        [Test]
        public void AddInShopTests()
        {
            Shop shop = new Shop(100);
            Smartphone phone = new Smartphone("gekon", 100);
            shop.Add(phone);
            Assert.AreEqual(1, shop.Count);
            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("gekon", 5)));
            shop = new Shop(1);
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("SmithsPhone", 7)));
        }
        [Test]
        public void RemoveFromShopTests()
        {
            Shop shop = new Shop(100);
            Smartphone phone = new Smartphone("gekon", 100);
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => shop.Remove("SmithPhone"));
            Assert.DoesNotThrow(() => shop.Remove("gekon"));
        }
        [Test]
        public void TestTestPhoneUse()
        {
            Shop shop = new Shop(100);
            Smartphone phone = new Smartphone("gekon", 100);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("GEKON", 99));
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("gekon", 150));
            shop.Add(new Smartphone("smithie", 100));
            Assert.DoesNotThrow(() => shop.TestPhone("smithie", 20));
        }
        [Test]
        public void TestPhoneCharger()
        {
            Shop shop = new Shop(100);
            Smartphone phone = new Smartphone("gekon", 100);
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("GekoN"));
            shop.Add(phone);
            shop.TestPhone("gekon", 20);
            Assert.AreEqual(80, phone.CurrentBateryCharge);
            shop.ChargePhone("gekon");
            Assert.AreEqual(100, phone.CurrentBateryCharge);
        }
    }

}