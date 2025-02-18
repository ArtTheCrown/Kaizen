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

        // Foreign key for User
        public int UserId { get; set; }
        public User User { get; set; }
    }


    public class TaskTimeStamp
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public int TaskId { get; set; }
        public Tasks Task { get; set; }
    }

    public class Configurations
    {
        // Define configuration properties here
    }
}
