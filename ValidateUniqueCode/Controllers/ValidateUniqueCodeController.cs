using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidateUniqueCode.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace ValidateUniqueCode.Controllers
{
    [Route("api/ValidateUniqueCode")]
    public class ValidateUniqueCodeController : Controller
    {
        // GET api/ValidateUniqueCode
        [HttpGet]
        public string Get()
        {
            string strUniqueCode = "Validate a Unique Code and return the associated email."; // ValidateCode("8A4BB948");
            return strUniqueCode;
        }

        // POST api/ValidateUniqueCode
        [HttpPost]
        public string Post([FromBody]Applicant applicant)
        {
            string strUniqueCode = ValidateCode(applicant.appUniqueCode);

            return strUniqueCode;
        }

        private string ValidateCode(string strCodeToFind)
        {
            string strUniqueCode = string.Empty;
            using (var context = new DatabaseContext())
            {
                var code = context.UniqueCodes.FirstOrDefault(c => c.uniCode == strCodeToFind && c.uniAccepted == false);
                JsonSerializer serializer = new JsonSerializer();
                var json = JsonConvert.SerializeObject(code);
                strUniqueCode = json;
            }

            return strUniqueCode;
        }
    }

    public class Applicant
    {
        public string appId;
        public string appName;
        public string appUniqueCode;
        public string appStatus;
        public string appFilename;
        public string appEmail;
        public string appImage;
    }
}
