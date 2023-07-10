﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
namespace ConnectionStringApplication.Models;

public partial class Customers
{
    /// <summary>
    /// Primary key
    /// </summary>
    public int CustomerIdentifier { get; set; }

    public string CompanyName { get; set; }

    public int? ContactId { get; set; }

    public string Street { get; set; }

    public string City { get; set; }

    public string Region { get; set; }

    public string PostalCode { get; set; }

    public int? CountryIdentifier { get; set; }

    public string Phone { get; set; }

    public string Fax { get; set; }

    public int? ContactTypeIdentifier { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Contacts Contact { get; set; }

    public virtual ContactType ContactTypeIdentifierNavigation { get; set; }

    public virtual Countries CountryIdentifierNavigation { get; set; }

    public virtual ICollection<Orders> Orders { get; } = new List<Orders>();
}