<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Chapter 8: Shopping Cart</title>
    <link href="Styles/Main.css" rel="stylesheet" />
    <link href="Styles/Cart.css" rel="stylesheet" />
</head>
<body>
    <header>
        <img src="Images/banner.jpg" alt="Halloween Store" />
    </header>
    <section>
    <form id="form1" runat="server">
        <h1>Your shopping Cart</h1>
        <asp:ListBox ID="lstCart" runat="server"></asp:ListBox>
        <div id="cartbuttons">               
            <asp:Button ID="btnRemove" runat="server" CssClass="button" Text="Remove Item" OnClick="btnRemove_Click" />
            <br />
            <asp:Button ID="btnEmpty" runat="server" CssClass="button" Text="Empty Cart" OnClick="btnEmpty_Click" />               
        </div>
        <div id="shopbuttons">              
            <asp:Button ID="btnContinue" runat="server" CssClass="button" PostBackUrl="~/Order.aspx" Text="Continue Shopping" />
            <asp:Button ID="btnCheckOut" runat="server" CssClass="button" Text="Check Out" OnClick="btnCheckOut_Click" />              
        </div>
        <p id="message">        
            <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>        
        </p>
    </form>
    </section>
</body>
</html>

