using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QAFoodBank.MobileAPI.Models
{
    public class QAFoodBankItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool Urgent { get; set; }
        public List<Vendor> SourceUrls { get; set; }
    }
}