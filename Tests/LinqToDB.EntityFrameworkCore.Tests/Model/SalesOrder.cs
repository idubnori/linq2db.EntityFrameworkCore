// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microsoft.EntityFrameworkCore.SqlAzure.Model
{
    [Table("SalesOrderHeader", Schema = "SalesLT")]
    public class SalesOrder
    {
        public SalesOrder()
        {
            Details = new HashSet<SalesOrderDetail>();
        }

        public int SalesOrderID { get; set; }
        public string AccountNumber { get; set; }
        public int? BillToAddressID { get; set; }
        public string Comment { get; set; }

        [MaxLength(15)]
        public string CreditCardApprovalCode { get; set; }

        public int CustomerID { get; set; }

        public DateTime DueDate { get; set; }
        public decimal Freight { get; set; }
        public DateTime ModifiedDate { get; set; }

        [Column("OnlineOrderFlag")]
        public bool IsOnlineOrder { get; set; }

        public DateTime OrderDate { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public byte RevisionNumber { get; set; }

        [Required]
        [MaxLength(25)]
        public string SalesOrderNumber { get; set; }

        public DateTime? ShipDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string ShipMethod { get; set; }

        public int? ShipToAddressID { get; set; }
        public byte Status { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal TotalDue { get; set; }
#pragma warning disable IDE1006 // Naming Styles
		public Guid rowguid { get; set; }
#pragma warning restore IDE1006 // Naming Styles

        [InverseProperty("SalesOrder")]
        public virtual ICollection<SalesOrderDetail> Details { get; set; }

        [ForeignKey("CustomerID")]
        [InverseProperty("Orders")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("BillToAddressID")]
        public virtual Address BillToAddress { get; set; }

        [ForeignKey("ShipToAddressID")]
        public virtual Address ShipToAddress { get; set; }
    }
}
