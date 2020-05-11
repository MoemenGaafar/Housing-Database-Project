﻿using DBapplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Housing_Database_Project.Employees_Functionalities
{
    public partial class EMP_ViewApps : Form
    {
        private Controller controllerObj;
        private int ID;
        private string Type;
        private DataTable dt;
        public EMP_ViewApps(int id, string type)
        {
            ID = id;
            Type = type;
            controllerObj = new Controller();
            InitializeComponent();
        }

        private void PEMP_ViewApps_Load(object sender, EventArgs e)
        {
            dt = controllerObj.SelectAppByEMPID(ID, "All", -1, Type); //A project ID of -1 refers to ALL IDs
            dataGridView_Apps.DataSource = dt;
            dataGridView_Apps.Refresh();
            comboBox_ProjectID.Items.Add("All");
            for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
            {
                var val = dt.Rows[intCount]["Project ID"].ToString();
                if (!comboBox_ProjectID.Items.Contains(val))
                {
                    comboBox_ProjectID.Items.Add(val);
                }
            }
            if (Type == "Housing")
            {
                label_Title.Text = "Citizen Applications";
                button_ViewCit.Visible = true;
            }
        }

        private void comboBox_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)comboBox_ProjectID.SelectedItem == "All")
            {
                dt = controllerObj.SelectAppByEMPID(ID, (string)comboBox_Status.SelectedItem, -1, Type);
            }
            else
            {
                dt = controllerObj.SelectAppByEMPID(ID, (string)comboBox_Status.SelectedItem, Convert.ToInt32(comboBox_ProjectID.SelectedItem), Type);
            }
            dataGridView_Apps.DataSource = dt;
            dataGridView_Apps.Refresh();
        }

        private void comboBox_ProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)comboBox_ProjectID.SelectedItem == "All")
            {
                dt = controllerObj.SelectAppByEMPID(ID, (string)comboBox_Status.SelectedItem, -1, Type);
            }
            else
            {
                dt = controllerObj.SelectAppByEMPID(ID, (string)comboBox_Status.SelectedItem, Convert.ToInt32(comboBox_ProjectID.SelectedItem), Type);
            }
            dataGridView_Apps.DataSource = dt;
            dataGridView_Apps.Refresh();
        }

        private void button_Accept_Click(object sender, EventArgs e)
        {
            if (dataGridView_Apps.SelectedRows.Count > 1) MessageBox.Show("Please select only one row at a time!");
            else if (Convert.ToChar(dataGridView_Apps.SelectedRows[0].Cells["Application Status"].Value) != 'W')
                MessageBox.Show("The selected transaction must be WAITING!");
            else
            {
                int r;
                if (Type == "Projects")
                   r = controllerObj.ChangeComApplicationStatus(Convert.ToInt32(dataGridView_Apps.SelectedRows[0].Cells["Project ID"].Value),
                    dataGridView_Apps.SelectedRows[0].Cells["Company"].Value.ToString(), 'A');
                else
                    r = controllerObj.ChangeCitApplicationStatus(Convert.ToInt32(dataGridView_Apps.SelectedRows[0].Cells["Project ID"].Value),
                       Convert.ToInt32(dataGridView_Apps.SelectedRows[0].Cells["Unit Number"].Value),
                      Convert.ToInt32(dataGridView_Apps.SelectedRows[0].Cells["Citizen ID"].Value), 'A');

                if (r > 0) MessageBox.Show("Application Accepted!");
                else MessageBox.Show("Error Accepting Application..");
                if ((string)comboBox_ProjectID.SelectedItem == "All")
                    dt = controllerObj.SelectAppByEMPID(ID, (string)comboBox_Status.SelectedItem, -1, Type);
                else
                    dt = controllerObj.SelectAppByEMPID(ID, (string)comboBox_Status.SelectedItem, Convert.ToInt32(comboBox_ProjectID.SelectedItem), Type);
                dataGridView_Apps.DataSource = dt;
                dataGridView_Apps.Refresh();
            }
        }

        private void button_Reject_Click(object sender, EventArgs e)
        {
            if (dataGridView_Apps.SelectedRows.Count > 1) MessageBox.Show("Please select only one row at a time!");
            else if (Convert.ToChar(dataGridView_Apps.SelectedRows[0].Cells["Application Status"].Value) != 'W')
                MessageBox.Show("The selected transaction must be WAITING!");
            else
            {
                int r;
                if (Type == "Projects")
                    r = controllerObj.ChangeComApplicationStatus(Convert.ToInt32(dataGridView_Apps.SelectedRows[0].Cells["Project ID"].Value),
                    dataGridView_Apps.SelectedRows[0].Cells["Company"].Value.ToString(), 'R');
                else
                    r = controllerObj.ChangeCitApplicationStatus(Convert.ToInt32(dataGridView_Apps.SelectedRows[0].Cells["Project ID"].Value),
                       Convert.ToInt32(dataGridView_Apps.SelectedRows[0].Cells["Unit Number"].Value),
                      Convert.ToInt32(dataGridView_Apps.SelectedRows[0].Cells["Citizen ID"].Value), 'R');

                if (r > 0) MessageBox.Show("Application Rejected!");
                else MessageBox.Show("Error Rejecting Application..");
                if ((string)comboBox_ProjectID.SelectedItem == "All")
                    dt = controllerObj.SelectAppByEMPID(ID, (string)comboBox_Status.SelectedItem, -1, Type);
                else
                    dt = controllerObj.SelectAppByEMPID(ID, (string)comboBox_Status.SelectedItem, Convert.ToInt32(comboBox_ProjectID.SelectedItem), Type);
                dataGridView_Apps.DataSource = dt;
                dataGridView_Apps.Refresh();
            }
        }

        private void PEMP_ViewApps_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                Owner.Show();
        }

        private void button_ViewCit_Click(object sender, EventArgs e)
        {
            if(dataGridView_Apps.SelectedRows.Count == 1)
            {
                new CitizenInfo(Convert.ToInt32(dataGridView_Apps.SelectedRows[0].Cells["Citizen ID"].Value)).Show(this);
            }
            else
            {
                MessageBox.Show("Please select ONE ENTIRE ROW!");
            }
        }
    }
}
