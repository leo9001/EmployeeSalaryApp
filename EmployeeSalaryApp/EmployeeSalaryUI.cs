using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeSalaryApp
{
    public partial class employeeSalaryUI : Form
    {
        public employeeSalaryUI()
        {
            InitializeComponent();
        }

        private string fileLocation = @"employee.txt";

        private void saveButton_Click(object sender, EventArgs e)

        {
            string name = nameTextBox.Text;
            string id = idTextBox.Text;
            string amount = amountTextBox.Text;

            FileStream aFileStream = new FileStream(fileLocation, FileMode.Append);

            StreamWriter aStreamWriter = new StreamWriter(aFileStream);

            aStreamWriter.WriteLine(name + ", " + id + ", " + amount);

            aStreamWriter.Close();

            nameTextBox.Text = "";
            idTextBox.Text = "";
            amountTextBox.Text = "";

            nameTextBox.Focus();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            resultListView.Columns.Add("Name", 100);
            resultListView.Columns.Add("Id", 100);
            resultListView.Columns.Add("Salary", 100);

            int totalSalary = 0;

            FileStream aFileStream = new FileStream(fileLocation, FileMode.Open);

            StreamReader aStreamReader = new StreamReader(aFileStream);

            employeeListBox.Items.Clear();

            while (!aStreamReader.EndOfStream)
            {
                string employeeInfo = aStreamReader.ReadLine();

                employeeListBox.Items.Add(employeeInfo);

                

                string[] employeeDetails = employeeInfo.Split(',');

                int salary = Convert.ToInt32(employeeDetails[2]);

                // resultListView

                string[] employeeData = {employeeDetails[0], employeeDetails[1], employeeDetails[2]};
                ListViewItem lvi = new ListViewItem(employeeData);
                resultListView.Items.Add(lvi);

                totalSalary += salary;
            }

            aStreamReader.Close();

            totalTextBox.Text = totalSalary.ToString();
        }

    }
}
