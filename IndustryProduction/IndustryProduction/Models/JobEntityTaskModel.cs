using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustryProduction.Models
{
    public class JobEntityTaskModel
    {
        [Key]
        [Column(TypeName = "int")]
        public int TaskId { get; set; }
        [Column(TypeName = "int")]
        public int TaskSeq { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string TaskNumber { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string JobNumber { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Manager { get; set; }
        [Column(TypeName = "datetime2(7)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime2(7)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime EndDate { get; set; }
        [Column(TypeName = "bit")]
        public bool CancelFlag { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime LastUpdateDate { get; set; }
        [Column(TypeName = "int")]
        public int LastUpdatedBy { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "int")]
        public int CreatedBy { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string ErrorText { get; set; }
        [Column(TypeName = "bit")]
        public bool ReadyFlag { get; set; }
        [Column(TypeName = "bit")]
        public bool ReleaseFlag { get; set; }
        [Column(TypeName = "bit")]
        public bool UploadNcfileFlag { get; set; }
        [Column(TypeName = "bit")]
        public bool TransferNCFileToMachineFlag { get; set; }
        public string TransferMessage { get; set; }
        public string Source { get; set; }
        public string ShelfNumber { get; set; }
        [Column(TypeName = "bit")]
        public bool ReserveShelfFlag { get; set; }
        [Column(TypeName = "bit")]
        public bool OnShelfFlag { get; set; }
        [Column(TypeName = "bit")]
        public bool McProcessFlag { get; set; }
        [Column(TypeName = "bit")]
        public bool McPickFlag { get; set; }
        [Column(TypeName = "bit")]
        public bool McLoadFlag { get; set; }
        [Column(TypeName = "bit")]
        public bool McFinishFlag { get; set; }
        [Column(TypeName = "bit")]
        public bool McUnloadFlag { get; set; }
        [Column(TypeName = "bit")]
        public bool McPushFlag { get; set; }
        [Column(TypeName = "bit")]
        public bool OutboundFlag { get; set; }
        [Column(TypeName = "bit")]
        public bool OutboundFinishFlag { get; set; }   
        [Column(TypeName = "nvarchar(50)")]
        public string QCStatus { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string MaterialCode { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string TableNumber { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string NcFile { get; set; }
        [Column(TypeName = "datetime2(7)")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string MachineNo { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string MachineNoReady { get; set; }
        [Column(TypeName = "int")]
        public int Priority { get; set; }
        [Column(TypeName = "int")]
        public int StandardTime { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string PrimaryItemCode { get; set; } 
        [Column(TypeName = "nvarchar(50)")]
        public string PrimaryItemModel { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public double PrimaryQuantity { get; set; } 
        [Column(TypeName = "bit")]
        public bool StartFlag { get; set; }


        [Column(TypeName = "int")]
        public int JobEntityId { get; set; }
        public JobEntityModel JobEntity { get; set; }

        [Column(TypeName = "int")]
        public int MachineId { get; set; }
        public MachineModel Machine { get; set; }
    }
}
