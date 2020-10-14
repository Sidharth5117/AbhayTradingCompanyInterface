using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbhayTradingCompanyInterface.Models
{
    public class Order
    {
        [DisplayName("ID")]
        public string id { get; set; }


        [DisplayName("Date & Time")]
        public DateTime timestamp { get; set; }

        [Required]
        [DisplayName("Customer")]
        
        public string customer { get; set; }

        [DisplayName("Ship To")]
        public string shipto { get; set; }

        [DisplayName("Broker")]
        public string broker { get; set; }

        [Required]
        [DisplayName("Mill Name")]
        public string millname { get; set; }

        [Required]
        [DisplayName("Material")]
        public string material { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int quantity { get; set; }

        [Required]
        [DisplayName("Sauda Rate")]
        public int saudarate { get; set; }

        [Required]
        [DisplayName("Bill Rate")]
        public int billrate { get; set; }

        [Required]
        [DisplayName("Entry By")]
        public string entryby { get; set; }

        [DisplayName("Remarks")]
        public string remarks { get; set; }




    }
}
