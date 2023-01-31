using Misyon.Core.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Misyon.Core.Common.Entities.Misyon
{
    /// <summary>
    /// FintechCustomerSdkPin
    /// </summary>
    [Table("FintechCustomerSdkPin", Schema = "Sdk")]
    public class FintechCustomerSdkPin : EntityBase
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// CustomerId
        /// </summary>
        public long CustomerId { get; set; }

        /// <summary>
        /// FintechId
        /// </summary>
        public long FintechId { get; set; }

        /// <summary>
        /// CustomerPin
        /// </summary>
        public string CustomerPin { get; set; }

        /// <summary>
        /// IsActive
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// CreateDate
        /// </summary>
        public DateTime CreateDate { get; set; } = DateTime.Now;

        /// <summary>
        /// ExpireDate
        /// </summary>
        public DateTime? ExpireDate { get; set; }
    }
}