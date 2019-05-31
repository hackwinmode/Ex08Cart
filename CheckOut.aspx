<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="CheckOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chapter 8: Shopping Cart</title>
    <link href="Styles/Main.css" rel="stylesheet" />
    <link href="Styles/CheckOut.css" rel="stylesheet" /> 
</head>
<body>
    <header>
        <img src="Images/banner.jpg" alt="Halloween Store" />
    </header>
    <section>
        <h1>Check Out Page 1</h1>
        <h2>Please login...</h2>
        <form id="form1" runat="server">
            <label>First Name</label>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="entry"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                    ErrorMessage="First name is required" ControlToValidate="txtFirstName" 
                    CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator><br />          
            <label>Last Name</label>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="entry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" 
                    ErrorMessage="Last name is required" ControlToValidate="txtLastName" 
                    CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator><br />                        
            <asp:Button ID="btnContinue" runat="server" Text="Continue" CssClass="button" OnClick="btnContinue_Click" />
        </form>
    </section>
    <footer>

    </footer>        
</body>
</html>
