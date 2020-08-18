using CollaberaSampleApplicationWithTest;
using CollaberaSampleApplicationWithTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Scenario_A_Total100()
        {
            //Act
            Cart objCart = new Cart();

            //Arrange
            List<CartItem> items = new List<CartItem>() {
                new CartItem{SKU="A", Qty=1},
                new CartItem{SKU="B", Qty=1},
                new CartItem{SKU="C", Qty=1}
            };

            var result = objCart.getCartTotal(items);

            // Assert
            Assert.AreEqual(100, result, "Scenario_A_SKU A=1, B=1, C=1 Total_100");
        }

        [TestMethod]
        public void Scenario_B_Total370()
        {
            //Act
            Cart objCart = new Cart();

            //Arrange
            List<CartItem> items = new List<CartItem>() {
                new CartItem{SKU="A", Qty=2},
                new CartItem{SKU="A", Qty=3},
                new CartItem{SKU="B", Qty=5},
                new CartItem{SKU="C", Qty=1}
            };

            var result = objCart.getCartTotal(items);

            // Assert
            Assert.AreEqual(370, result, "Scenario_B_SKU A=5, B=5, C=1 Total_370");
        }

        [TestMethod]
        public void Scenario_C_Total280()
        {
            //Act
            Cart objCart = new Cart();

            //Arrange
            List<CartItem> items = new List<CartItem>() {
                new CartItem{SKU="A", Qty=3},
                new CartItem{SKU="B", Qty=5},
                new CartItem{SKU="C", Qty=1},
                new CartItem{SKU="D", Qty=1}
            };

            var result = objCart.getCartTotal(items);

            // Assert
            Assert.AreEqual(280, result, "Scenario_C_SKU A=3, B=5, C=1, D=1 Total_280");
        }

    }
}
