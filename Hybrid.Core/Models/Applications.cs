﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Hybrid.Core.Models;

public partial class Applications
{
    public int ApplicationId { get; set; }

    /// <summary>
    /// Application identifier
    /// </summary>
    public string ApplicationName { get; set; }

    /// <summary>
    /// Contact name
    /// </summary>
    public string ContactName { get; set; }

    /// <summary>
    /// For sending email messages
    /// </summary>
    public MailSettings MailSettings { get; set; }
    public GeneralSettings GeneralSettings { get; set; }
}