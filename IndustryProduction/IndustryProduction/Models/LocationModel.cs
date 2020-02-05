using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IndustryProduction.Models
{
    public class LocationModel
    {
        [Key]
        [Column(TypeName = "int")]
        public int LocationId { get; set; }
        [Column(TypeName = "int")]
        public int LevelNo { get; set; }
        [Column(TypeName = "int")]
        public int ColumnNo { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string CombindLocation { get; set; }
        [Column(TypeName = "int")]
        public int ItemId { get; set; }
        [Column(TypeName = "int")]
        public int TaskId { get; set; }
        [Column(TypeName = "bit")]
        public bool ReserveFlag { get; set; }
        [Column(TypeName = "bit")]
        public bool FillFlag { get; set; }
        [Column(TypeName = "bit")]
        public bool AvailableFlag { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime LastUpdateDate { get; set; }
        [Column(TypeName = "int")]
        public int LastUpdatedBy { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "int")]
        public int CreatedBy { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Attribute1 { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Attribute2 { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Attribute3 { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Attribute4 { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Attribute5 { get; set; }
        [Column(TypeName = "int")]
        public int Priority { get; set; }

        public JobEntityTaskModel TaskEntity { get; set; }
    }
}
