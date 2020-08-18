using CollaberaSampleApplicationWithTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollaberaSampleApplicationWithTest
{
    public class Cart
    {
        //public int Total { get; set; }
        Products objProducts = new Products();
        public int getCartTotal(List<CartItem> cartItems)
        {
            int cartTotal = 0;            
            cartTotal += applyOfferAB(cartItems, "A");
            cartTotal += applyOfferAB(cartItems, "B");
            cartTotal += applyOfferCD(cartItems);            

            return cartTotal;
        }

        // For SKU A, B
        private int applyOfferAB(List<CartItem> cartItems, string SKU)
        {
            int OfferUnit = 0;
            int OfferRate = 0;
            if (SKU == "A") 
            {
                OfferUnit = 3;
                OfferRate = 130;
            }
            if (SKU == "B")
            {
                OfferUnit = 2;
                OfferRate = 45;
            }
            
            List<CartItem> items = cartItems.FindAll(prd => prd.SKU == SKU);
            int itemQty = items.Sum(x => x.Qty);
            int unitsToApplyDiscountRate = (itemQty / OfferUnit);
            int unitsToApplyFlatRate = (itemQty % OfferUnit);
            int intUnitPrice = objProducts.ProductList.FirstOrDefault(x => x.SKUId == SKU).Price;
            return (unitsToApplyDiscountRate * OfferRate) + (unitsToApplyFlatRate * intUnitPrice); ;
        }

        // For SKU C, D
        private int applyOfferCD(List<CartItem> cartItems)
        {
            int offerPrice = 0;
            List<CartItem> itemsC = cartItems.FindAll(prd => prd.SKU == "C");
            List<CartItem> itemsD = cartItems.FindAll(prd => prd.SKU == "D");
            int itemQtyC = itemsC.Sum(x => x.Qty);
            int itemQtyD = itemsD.Sum(x => x.Qty);
            int intUnitPriceC = objProducts.ProductList.FirstOrDefault(x => x.SKUId == "C").Price;
            int intUnitPriceD = objProducts.ProductList.FirstOrDefault(x => x.SKUId == "D").Price;

            if (itemQtyC > itemQtyD)
            {                   
                offerPrice = ((itemQtyC - itemQtyD) * intUnitPriceC) +  (itemQtyD * 30);
            }
            else if (itemQtyC < itemQtyD)
            {
                offerPrice = ((itemQtyD - itemQtyC) * intUnitPriceD) + (itemQtyC * 30);
            }
            else if(itemQtyC == itemQtyD)
            {
                offerPrice = itemQtyC * 30;
            }
            return offerPrice;
        }
    }
}
