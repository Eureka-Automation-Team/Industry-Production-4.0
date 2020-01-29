using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustryProduction.Models
{
    public class JobEntityModel
    {
        [Key]
        [Column(TypeName = "int")]
        public int JobEntityId { get; set; }
        [Column(TypeName = "int")]
        public int OrganizationId { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime LastUpdateDate { get; set; }
        [Column(TypeName = "int")]
        public int LastUpdatedBy { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "int")]
        public int CreatedBy { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string JobEntityName { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime JobEntiryDate { get; set; }
        [Column(TypeName = "int")]
        public int EntityType { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "int")]
        public int PrimaryItemId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string PrimaryItemCode { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string PrimaryItemModel { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public double PrimaryQuantity { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Segment1 { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Segment2 { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Segment3 { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Segment4 { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Segment5 { get; set; }
        [Column(TypeName = "bit")]
        public bool OpenStatus { get; set; }
        [Column(TypeName = "bit")]
        public bool ProcessFlag { get; set; }
        [Column(TypeName = "bit")]
        public bool CompletedFlag { get; set; }
        [Column(TypeName = "bit")]
        public bool CancelFlag { get; set; }
        [Column(TypeName = "int")]
        public int PoLineId { get; set; }
        [Column(TypeName = "int")]
        public int PoHeaderId { get; set; }

        public IList<JobEntityTaskModel> JobTasks { get; set; }
    }
}
