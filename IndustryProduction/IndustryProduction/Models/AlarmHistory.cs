using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndustryProduction.Models
{
    public class AlarmHistory : DomainObject
    {
        public string AlarmNo { set; get; }
        public string AxisName { set; get; }
        public string AlarmDesc { set; get; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool ActiveFlag { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }

        public int MachineId { get; set; }
        public Machine Machine { get; set; }
        public double StartTimeStr
        {
            get { return Convert.ToDouble(StartTime.Hour.ToString() + "." + StartTime.Minute.ToString()); }
        }
        public double EndTimeStr
        {
            get { return Convert.ToDouble(EndTime.Hour.ToString() + "." + EndTime.Minute.ToString()); }
        }
    }
}
