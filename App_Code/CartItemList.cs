using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;

public class CartItemList
{
    //internal list of items and constructor which instantiates it
    private List<CartItem> cartItems;
    public CartItemList() {
        cartItems = new List<CartItem>();
    }

    //readonly property that returns the number of items in internal list
    public int Count {
        get { return cartItems.Count; }
    }

    //indexers - locate items in internal list by index or product id
    public CartItem this[int index] {
        get { return cartItems[index]; }
        set { cartItems[index] = value; }
    }
    public CartItem this[string id] {
        get {
            foreach (CartItem c in cartItems)
                if (c.Product.ProductID == id) return c;
            return null;
        }
    }

    //static method to get cart object from session
    public static CartItemList GetCart() {
        CartItemList cart = (CartItemList)HttpContext.Current.Session["Cart"];
        if (cart == null)
            HttpContext.Current.Session["Cart"] = new CartItemList();
        return (CartItemList)HttpContext.Current.Session["Cart"];
    }

    //add, remove and clear internal list item(s)
    public void AddItem(Product product, int quantity) {
        CartItem c = new CartItem(product, quantity);
        cartItems.Add(c);
    }
    public void RemoveAt(int index) {
        cartItems.RemoveAt(index);
    }
    public void Clear() {
        cartItems.Clear();
    }
}

