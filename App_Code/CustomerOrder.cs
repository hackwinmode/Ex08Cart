using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security;

public class CustomerOrder
{
    public string PaymentType { get; set; }
    public string CreditCardType { get; set; }
    public string CreditCardNum { get; set; }
    public string CreditCardExpiry { get; set; }
    public string CheckRoutingNum { get; set; }
    public string CheckAccountNum { get; set; }
    public string PayPalUserName { get; set; }
    public string PayPalPwd { get; set; }
    public string OrderAmount { get; set; }
}