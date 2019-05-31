<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chapter 8: Shopping Cart</title>
    <link href="Styles/Main.css" rel="stylesheet" />
    <link href="Styles/Order.css" rel="stylesheet" />
</head>
<body>
    <header>
        <img src="Images/banner.jpg" alt="Halloween Store" /><br />
    </header>
    <section>
    <asp:Label ID="lblWelcome" runat="server"></asp:Label>
    <form id="form1" runat="server">
        <label>Please select a product&nbsp;</label>
        <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ProductID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HalloweenConnectionString %>" SelectCommand="SELECT [ProductID], [Name], [CategoryID], [ImageFile], [UnitPrice], [OnHand], [ShortDescription], [LongDescription] FROM [Products]"></asp:SqlDataSource>
        <div id="productData">   
            <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lblShortDescription" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lblLongDescription" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lblUnitPrice" runat="server" Text="Label"></asp:Label>
            <label id="lblQuantity">Quantity&nbsp;</label>
            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="Quantity is required" ControlToValidate="txtQuantity" CssClass="validator">
            </asp:RequiredFieldValidator>  
            <br />
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add to Cart" CssClass="button" />
            <asp:Button ID="btnCart" runat="server" CausesValidation="False" PostBackUrl="~/Cart.aspx" Text="Go to Cart" CssClass="button" />
        </div>
        <asp:Image ID="imgProduct" runat="server" />              
    </form>
    </section>  
    <footer>
        Last Updated <asp:Label ID="lblUpdateTime" runat="server"></asp:Label><br />
        Number of Page Hits: <asp:Label ID="lblPageHits" runat="server"></asp:Label>
    </footer>      
</body>
</html>
