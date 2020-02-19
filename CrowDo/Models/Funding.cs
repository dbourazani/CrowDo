using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowDo.Models
{
    public class Funding
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
        public decimal Deposit { get; set; }
        public DateTime DepositDate { get; set; }
    }
}
