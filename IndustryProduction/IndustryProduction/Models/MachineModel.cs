using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustryProduction.Models
{
    public class MachineModel
    {
        [Key]
        [Column(TypeName = "int")]
        public int MachineId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string MachineCode { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string IpAddress { get; set; }
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
        [Column(TypeName = "char(1)")]
        public bool EnableFlag { get; set; }
        [Column(TypeName = "char(1)")]
        public bool ActiveFlag { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string MacType { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string MacGroup { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ProductionLine { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string PlantId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string MacModel { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Shift1 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Shift2 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ShiftOT { get; set; }
        [Column(TypeName = "int")]
        public int CalendarId { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime MacStartTime { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime MacEndTime { get; set; }
        [Column(TypeName = "int")]
        public int WorkingHr { get; set; }
        [Column(TypeName = "int")]
        public int Mon { get; set; }
        [Column(TypeName = "int")]
        public int Tue { get; set; }
        [Column(TypeName = "int")]
        public int Wed { get; set; }
        [Column(TypeName = "int")]
        public int Thu { get; set; }
        [Column(TypeName = "int")]
        public int Fri { get; set; }
        [Column(TypeName = "int")]
        public int Sat { get; set; }
        [Column(TypeName = "int")]
        public int Sun { get; set; }
        [Column(TypeName = "int")]
        public int LunchHr { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string STimeLunchHr { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ETimeLunchHr { get; set; }
        [Column(TypeName = "int")]
        public int MaintenaneTime { get; set; }
    }
}
