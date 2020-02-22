﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CrowDo.Models
{
    public class ProjectFundingPackage
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int FundingPackageId { get; set; }
        //public int UserId { get; set; }
        //public User User { get; set; }
        public Project Project { get; set; }
        public FundingPackage FundingPackage { get; set; }
        public  DateTime DepositDate { get; set; }
    }
}