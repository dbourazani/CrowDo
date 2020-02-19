using CrowDo.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowDo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Project> Projects { get; set; }
        public List<Funding> Fundings { get; set; }
        public string Email { get; set; }
        public StatusUser Status { get; set; }
    }
}
