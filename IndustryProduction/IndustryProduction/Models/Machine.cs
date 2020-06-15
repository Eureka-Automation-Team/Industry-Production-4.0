using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IndustryProduction.Models
{
    public class Machine : DomainObject
    {
        [Display(Name = "Machine")]
        [Column(TypeName = "nvarchar(50)")]
        public string MachineCode { get; set; }

        [Display(Name = "Address")]
        [Column(TypeName = "nvarchar(50)")]
        public string IpAddress { get; set; }

        [Display(Name = "Port")]
        [Column(TypeName = "int")]
        public int PortNumber { get; set; }

        [Column(TypeName = "datetime2(7)")]
        public DateTime LastUpdateDate { get; set; }

        [Column(TypeName = "int")]
        public int LastUpdatedBy { get; set; }

        [Column(TypeName = "datetime2(7)")]
        public DateTime CreationDate { get; set; }

        [Column(TypeName = "int")]
        public int CreatedBy { get; set; }

        [Display(Name = "Enable")]
        [Column(TypeName = "bit")]
        public bool EnableFlag { get; set; }

        [Display(Name = "Active")]
        [Column(TypeName = "bit")]
        public bool ActiveFlag { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MacType { get; set; }

        [Display(Name = "Group")]
        [Column(TypeName = "nvarchar(50)")]
        public string MacGroup { get; set; }

        [Display(Name = "PROD Line")]
        [Column(TypeName = "nvarchar(50)")]
        public string ProductionLine { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string PlantId { get; set; }

        [Display(Name = "Model")]
        [Column(TypeName = "nvarchar(50)")]
        public string MachineModel { get; set; }

        public int CalendarId { get; set; }

        public List<MachineWorking> WorkingTime { get; set; }
    }
}
