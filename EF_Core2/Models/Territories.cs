﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EF_Core2.Models;

public partial class Territories
{
    public string TerritoryID { get; set; }

    public string TerritoryDescription { get; set; }

    public int RegionID { get; set; }

    public virtual Region Region { get; set; }

    public virtual ICollection<Employees> Employee { get; } = new List<Employees>();
}