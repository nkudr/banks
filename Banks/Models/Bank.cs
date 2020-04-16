using System;
using System.ComponentModel.DataAnnotations;

namespace Banks.Models
{
    public class Bank
    {
		[Key]
		public String IFSC { get; set; }

		public String ADDRESS { get; set; }
		public String CITY { get; set; }
		public String BANK { get; set; }
		public String BANKCODE { get; set; }
    }
}
