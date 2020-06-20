using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Daroya.MoneymeAPI.Models.Models.Entity
{
    public partial class Quote : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public int Term { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public decimal Amount { get; set; }

        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Guid LastUpdatedBy { get; set; }
        public string LastUpdatedByName { get; set; }
    }
}
