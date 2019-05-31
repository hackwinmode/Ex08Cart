using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Phone { get; set; }
    public string StreetAddress { get; set; }
    public string StreetCity { get; set; }
    public string StreetState { get; set; }
    public string StreetZip { get; set; }
    public bool IsSameBilling { get; set; }
    public string BillingAddress { get; set; }
    public string BillingCity { get; set; }
    public string BillingState { get; set; }
    public string BillingZip { get; set; }   
    public bool Newsletter { get; set; }
    public bool Sales { get; set; }
    public bool NewItems { get; set; }
    public CustomerOrder Order { get; set; }

    public Customer()
    {
        this.Order = new CustomerOrder();
    }
    
    
}