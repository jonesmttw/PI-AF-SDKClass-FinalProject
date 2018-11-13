using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReportGenerator
{
    public class ReportCellValue
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("time")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }
}
