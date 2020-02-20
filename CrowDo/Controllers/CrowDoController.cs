using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowDo.Core.Data;
using CrowDo.Models;
using CrowDo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CrowDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrowDoController : ControllerBase
    {
        private IExcelIO _excelIO;
        private readonly ILogger<CrowDoController> _logger;
        public CrowDoController(ILogger<CrowDoController> logger,
            IExcelIO excelIO)
        {
            _logger = logger;
            _excelIO = excelIO;
        }
        [HttpGet("users / excel /{filename}")]
        public List<User> GetCustomersFromExcel([FromRoute] string fileName)
        {
            var excelIO = new ExcelIO(new CrowDoDbContext());
            return excelIO.ReadExcel(fileName);
        }
    }
}
    
