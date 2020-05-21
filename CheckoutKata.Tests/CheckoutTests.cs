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

    [TestClass]
    public class GivenAnItemToAddWithASpecialOffer
    {
        private Checkout _checkout = new Checkout();

        [TestInitialize]
        public void WhenScanningAnItem()
        {
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "D20"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "D20"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "D20"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "D20"));
        }

        [TestMethod]
        public void ThenItemShouldBeAddedSuccessfully()
        {
            Assert.AreEqual(1.20m, _checkout.Total());
        }

    }

    [TestClass]
    public class GivenAnItemToAddWithASpecialOfferUsingScanWithQuantity
    {
        private Checkout _checkout = new Checkout();

        [TestInitialize]
        public void WhenScanningAnItem()
        {
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "D20"), 5);
        }

        [TestMethod]
        public void ThenItemShouldBeAddedSuccessfully()
        {
            Assert.AreEqual(1.60m, _checkout.Total());
        }

    } 
    
    [TestClass]
    public class GivenAnItemToAddWithASpecialOfferUsingScanWithQuantityAnItemWithAgeLimit
    {
        private Checkout _checkout = new Checkout();

        [TestInitialize]
        public void WhenScanningAnItem()
        {
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "D20"), 5, 12);
        }

        [TestMethod]
        public void ThenItemShouldBeAddedSuccessfully()
        {
            Assert.AreEqual(0m, _checkout.Total());
        }

    }

    [TestClass]
    public class GivenAnItemToAddWithASpecialOfferUsingScanWithQuantityAnItemWithAppropriateAge
    {
        private Checkout _checkout = new Checkout();

        [TestInitialize]
        public void WhenScanningAnItem()
        {
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "D20"), 5, 22);
        }

        [TestMethod]
        public void ThenItemShouldBeAddedSuccessfully()
        {
            Assert.AreEqual(1.60m, _checkout.Total());
        }

    }

    [TestClass]
    public class GivenItemsToScanWithSpecialOffer
    {
        readonly Checkout _checkout = new Checkout();

        [TestInitialize]
        public void WhenScanningItemsAtCheckout()
        {
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "A99"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "A99"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "A99"));
        }

        [TestMethod]
        public void ThenItemShouldBeScannedSuccessfully()
        {
            Assert.AreEqual(1.30m, _checkout.Total());
        }
    }
    
    [TestClass]
    public class GivenItemsToScanWithPartialSpecialOffer
    {
        readonly Checkout _checkout = new Checkout();

        [TestInitialize]
        public void WhenScanningItemsAtCheckout()
        {
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "A99"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "A99"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "A99"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "A99"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "B15"));

        }

        [TestMethod]
        public void ThenItemShouldBeScannedSuccessfully()
        {
            Assert.AreEqual(2.10m, _checkout.Total());
        }
    }

    [TestClass]
    public class GivenItemsToScanWithMultipleSpecialOffers
    {
        readonly Checkout _checkout = new Checkout();

        [TestInitialize]
        public void WhenScanningItemsAtCheckout()
        {
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "A99"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "A99"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "A99"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "A99"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "A99"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "A99"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "B15"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "B15"));
        }

        [TestMethod]
        public void ThenItemShouldBeScannedSuccessfully()
        {
            Assert.AreEqual(3.05m, _checkout.Total());
        }
    }

    [TestClass]
    public class GivenItemsToScanWithBuyTwoThirdOneHalfPriceSpecialOffer
    {
        readonly Checkout _checkout = new Checkout();

        [TestInitialize]
        public void WhenScanningItemsAtCheckout()
        {
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "C40"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "C40"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "C40"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "C40"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "C40"));
            _checkout.Scan(FakeDataStore.Items().FirstOrDefault(x=> x.SKU == "C40"));
        }

        [TestMethod]
        public void ThenItemShouldBeScannedSuccessfully()
        {
            Assert.AreEqual(3.0m, _checkout.Total());
        }
    }


}
