using System;
using System.Collections.Generic;
using System.Text;

namespace Daroya.MoneymeAPI.Models.Models.DTO
{
    public class QuoteDTO
    {
        public Guid Id { get; set; }
        public int Term { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public decimal Amount { get; set; }
    }
}
