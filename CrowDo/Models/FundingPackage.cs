using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowDo.Models
{
    public class FundingPackage
    {
        public int Id { get; set; }
        public User User { get; set; }//baker
        public Project Project { get; set; }//o creator
        public decimal Deposit { get; set; }
        public string DescriptionGift { get; set; }
        public DateTime DepositDate { get; set; }
        public FundingPackage()
        {
            DepositDate = DateTime.Now; 
        }
    }
}
