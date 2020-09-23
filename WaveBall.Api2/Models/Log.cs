using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaveBall.Api2.Models
{
    public class Log
    {
        public Guid AppGuid { get; set; }
        public string? Level { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
