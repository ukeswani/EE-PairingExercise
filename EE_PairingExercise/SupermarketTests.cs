using System;
using System.Collections.Generic;
using EE_SuperMarket;
using NUnit.Framework;

namespace EE_PairingExercise
{
    [TestFixture]
    public class SupermarketTests
    {
        [Test]
        public void GivenAnIdentifierNumberOfItemsAndCostPerItem_WhenCalculateTotalCostCalled_ThenReturnsExpectedTotalCost()
        {
            // Arrange
            var itemIdentifier = "Dove Soap";
            var numberOfItems = 10;
            var costPerItem = 5;

            // Act
            var totalCost = SuperMarket.CalculateTotalCost(numberOfItems, costPerItem);

            // Assert
            Assert.That(totalCost, Is.EqualTo(50));
        }

        [Test]
        public void GivenNoObject_WhenTwoItemHolderConstructedWithSameArguments_ReturnsObjectsAsEqual()
        {
            // Arrange
            var itemIdentifier = "Dove Soap";
            var numberOfItems = 10;
            var costPerItem = 5;

            // Act
            var itemOne = new ItemHolder(itemIdentifier, numberOfItems, costPerItem);
            var itemTwo = new ItemHolder(itemIdentifier, numberOfItems, costPerItem);

            // Assert
            Assert.AreEqual(itemOne, itemTwo);
        }

        [Test]
        public void GivenNoObject_WhenTwoItemHolderConstructedWithDifferentArguments_ReturnsOjectsAsNotEqual()
        {
            // Arrange
            var itemIdentifier = "Dove Soap";
            var numberOfItems = 10;
            var costPerItem = 5;

            // Act
            var itemOne = new ItemHolder(itemIdentifier, numberOfItems, costPerItem);
            var itemTwo = new ItemHolder("Dove Shampoo", 2, 10);

            // Assert
            Assert.AreNotEqual(itemOne, itemTwo);
        }


        [Test]
        public void GivenALisOfItemHolds_WhenCalculateTotalCostCalled_ThenReturnsExpectedTotalCost()
        {
           // Arrange
           var items = new List<ItemHolder>()
           {
               new ItemHolder("1", 10, 50),
               new ItemHolder("2", 1, 500),
               new ItemHolder("3", 5, 100)
           };

           // Act
           var totalCost = SuperMarket.CalculateTotalCost(items);

           // Assert
           Assert.That(totalCost, Is.EqualTo(1500));

        }

        [Test]
        public void GivenALisOfItemHolds_WhenCalculateTotalCostCalled_ThenReturnsTotalCostWithSeviceTaxApplied()
        {
            // Arrange
            var items = new List<ItemHolder>()
            {
                new ItemHolder("1", 10, 50),
                new ItemHolder("2", 1, 500),
                new ItemHolder("3", 5, 100)
            };

            Func<List<ItemHolder>, double> totalCalculator = SuperMarket.CalculateTotalCost;
            var costCalculator = totalCalculator.AndThen(SuperMarket.CalculateServiceTax(12.5));

            // Act
            var totalCost = costCalculator(items);

            // Assert
            Assert.That(totalCost, Is.EqualTo(1687.5));
        }

        [Test]
        public void ServiceTaxTest()
        {
            var serviceTax = 12.5;
            Func<double, double> lambda = SuperMarket.CalculateServiceTax(serviceTax);

            var totalWithServiceTax = lambda(1500);

            Assert.That(totalWithServiceTax, Is.EqualTo(1687.5));
        }
    }
}
