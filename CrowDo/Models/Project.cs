using CrowDo.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowDo.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string VatNumber { get; set; }
        public decimal Budget { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public DateTime CreationDate { get; set; }
        public StatusProject StatusProject { get; set; }
        public List<FundingPackage> Fundings { get; set; }
        public Project()
        {
            CreationDate = DateTime.Now;
        }
    }
}
