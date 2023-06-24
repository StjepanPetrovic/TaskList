using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskList
{
    public partial class Form1 : Form
    {
        TaskModule taskModule = new TaskModule();

        public Form1()
        {
            InitializeComponent();

            dgvTaskList.DataSource = taskModule.TaskList;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string taskName = txtTaskName.Text;
            DateTime deadline = dtpDeadline.Value;

            taskModule.AddTask(taskName, deadline);

            dgvTaskList.DataSource = taskModule.TaskList.OrderBy(task => task.Deadline).ToList();

            taskModule.ChangeTaskColor(dgvTaskList);
        }
    }
}
