using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Caching;

public partial class Order : System.Web.UI.Page
{
    private Product selectedProduct;

    protected void Page_Load(object sender, EventArgs e)
    {
        //bind dropdown and update page hit count on first load;                 
        if (!IsPostBack) {
            ddlProducts.DataBind();
            // get hit count from application state or set to 1
            Application.Lock();
                int hitCount = Convert.ToInt32(Application["HitCount"]);
                hitCount++;
                Application["HitCount"] = hitCount;
            Application.UnLock();
            lblPageHits.Text = hitCount.ToString();

        }
        //get and show product data on every load
        selectedProduct = this.GetSelectedProduct();
        lblName.Text = selectedProduct.Name;
        lblShortDescription.Text = selectedProduct.ShortDescription;
        lblLongDescription.Text = selectedProduct.LongDescription;
        lblUnitPrice.Text = selectedProduct.UnitPrice.ToString("c") + " each";
        imgProduct.ImageUrl = "Images/Products/" + selectedProduct.ImageFile;

        //get firstname from cookie and set welcome message if it exists
        //if (Request.Cookies["FirstName"] != null)
        //    lblWelcome.Text = "Welcome back, " + Request.Cookies["FirstName"].Value + "!";

        //get firstname from session and set welcome message if it exists
        string firstName = (string)Session["FirstName"];
        if (firstName != null)
        {
            lblWelcome.Text = "Welcome back, " + (string)Session["FirstName"] + "!";
        }

        //get last update time from cache, then display it
        //or set last update time in cache to now plus 10, then display it
        object lastUpdateTime = Cache.Get("LastUpdateTime");
        if (lastUpdateTime == null)
        {
            lastUpdateTime = DateTime.Now;
            Cache.Insert("LastUpdateTime", lastUpdateTime, null, DateTime.Now.AddMinutes(10), Cache.NoSlidingExpiration);
        }
        lblUpdateTime.Text = lastUpdateTime.ToString();
    }

    private Product GetSelectedProduct()
    {
        //get row from SqlDataSource based on value in dropdownlist
        DataView productsTable = (DataView)
            SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        productsTable.RowFilter = string.Format("ProductID = '{0}'",
            ddlProducts.SelectedValue);
        DataRowView row = (DataRowView)productsTable[0];

        //create a new product object and load with data from row
        Product p = new Product();
        p.ProductID = row["ProductID"].ToString();
        p.Name = row["Name"].ToString();
        p.ShortDescription = row["ShortDescription"].ToString();
        p.LongDescription = row["LongDescription"].ToString();
        p.UnitPrice = (decimal)row["UnitPrice"];
        p.ImageFile = row["ImageFile"].ToString();
        return p;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //get cart from session and selected item from cart
            CartItemList cart = CartItemList.GetCart();
            CartItem cartItem = cart[selectedProduct.ProductID];

            //if item isn’t in cart, add it; otherwise, increase its quantity
            if (cartItem == null)
            {
                cart.AddItem(selectedProduct,
                             Convert.ToInt32(txtQuantity.Text));
            }
            else
            {
                cartItem.AddQuantity(Convert.ToInt32(txtQuantity.Text));
            }
            Response.Redirect("Cart.aspx");
        }

    }
}