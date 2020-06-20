using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Daroya.MoneymeAPI.Models.Models.Entity
{
    public interface IEntityBase
    {
        DateTime CreatedDate { get; set; } 
        Guid CreatedBy { get; set; }
        string CreatedByName { get; set; } 
        DateTime LastUpdatedDate { get; set; }
        Guid LastUpdatedBy { get; set; }
        string LastUpdatedByName { get; set; }
    }
}
