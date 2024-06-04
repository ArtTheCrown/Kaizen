using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Kaizen.Models
{
    public class User
    {
        public string Username { get; set; } = "Hyacinth";
        public int Streak { get; set; }
        public List<Tasks> HabitsInculcated { get; set; } = new List<Tasks>();
        public int FailedAttempts { get; set; }
        public List<Tasks> ActiveTasks { get; set; } = new List<Tasks>();

        public void UpdateTask(int ID, string newStatus, DateTime newDeadLine)
        {
            var task = ActiveTasks.FirstOrDefault(t => t.ID == ID);
            if (task != null)
            {
                task.Completed = newStatus;
                task.DeadLine = newDeadLine;
            }
        }
    }
}
