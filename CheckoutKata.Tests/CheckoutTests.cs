using System;
using System.Linq;
using CheckoutKata.Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class GivenNoItemToScan
    {
        private readonly Checkout _checkout = new Checkout();

        [TestInitialize]
        public void WhenScanningAtCheckout()
        {
            _checkout.Scan(null);
        }

        [TestMethod]
        public void ThenItemShouldBeScannedSuccessfully()
        {
            Assert.AreEqual(0m, _checkout.Total());
        }
    }
    
    [TestClass]
    public class GivenAnItemToScan
    {
        private readonly Checkout _checkout = new Checkout();

        [TestInitialize]
        public void WhenScanningAtCheckout()
        {
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "A99"));
        }

        [TestMethod]
        public void ThenItemShouldBeScannedSuccessfully()
        {
            Assert.AreEqual(.50m, _checkout.Total());
        }
    }
}
