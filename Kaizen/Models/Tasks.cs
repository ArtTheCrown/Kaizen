using System;
using System.Collections.Generic;

namespace Kaizen.Models
{
    public class Tasks
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Progress { get; set; }
        public int FailedAttempts { get; set; }
        public String Completed { get; set; }
        public DateTime DeadLine { get; set; }
        public List<DateTime> TimeStamps { get; set; }
        public Configurations Configuration { get; set; }
    }
}
