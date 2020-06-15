using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndustryProduction.Models
{
    public class CameraSettingModel : DomainObject
    {
        public string CameraCode { get; set; }
        public string CameraUrl { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
