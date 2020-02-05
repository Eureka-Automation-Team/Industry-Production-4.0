using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IndustryProduction.Models
{
    public class TaskLogsModel
    {
        [Key]
        [Column(TypeName = "int")]
        public int LogId { get; set; }
        [Column(TypeName = "int")]
        public int JobEntityId { get; set; }
        [Column(TypeName = "int")]
        public int TaskId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ActionName { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime ActionTimeStamp { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string LogMessages { get; set; }

        public JobEntityTaskModel TaskEntity { get; set; }
        public JobEntityModel JobEntity { get; set; }
    }
}
