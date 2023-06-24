using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskList
{
    internal class TaskModule
    {
        public List<Task> TaskList { get; set; } = new List<Task>();

        public void AddTask(string taskName, DateTime deadline)
        {
            Task task = new Task
            {
                Name = taskName,
                Deadline = deadline,
            };

            TaskList.Add(task);
        }

        public void ChangeTaskColor(DataGridView gridView)
        {
            DateTime now = DateTime.Now;
            List<Task> tasks = TaskList.OrderBy(task => task.Deadline).ToList();
            int counter = 0;

            if (tasks.Count > 0)
            {
                foreach (var task in tasks)
                {
                    TimeSpan timeLeft = task.Deadline - now;

                    if (timeLeft.Days < 1)
                    {
                        gridView.Rows[counter].DefaultCellStyle.ForeColor = Color.Red;
                    }

                    counter++;
                }
            }
        }
    }
}
