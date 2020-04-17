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

namespace Housing_Database_Project
{
    public partial class Login : Form
    {
        private Controller controllerObj;
        public Login()
        {
            InitializeComponent();
            controllerObj = new Controller();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            bool found = false;

            if (!(radioButton_Bank.Checked || radioButton_Citizen.Checked || radioButton_Company.Checked || radioButton_Employee.Checked || radioButton_Admin.Checked)
                 || TxtBx_username.Text == "" || TxtBx_pass.Text == "")
            {
                MessageBox.Show("Please Enter All Required Data and Pick an Account Type");
                return;
            }

            try
            {
                if (radioButton_Citizen.Checked)
                {
                    found = controllerObj.CheckPassword_Citizen(Convert.ToInt32(TxtBx_username.Text), TxtBx_pass.Text);
                    if (found)
                    {
                        CitizenFunctionalities CF = new CitizenFunctionalities();
                        CF.Show(this);
                        this.Hide();
                    }
                }
                else if (radioButton_Employee.Checked)
                {
                    found = controllerObj.CheckPassword_Employee(Convert.ToInt32(TxtBx_username.Text), TxtBx_pass.Text);
                    if (found)
                    {
                        EmployeeFunctionalities EF = new EmployeeFunctionalities();
                        EF.Show(this);
                        this.Hide();
                    }
                }
                else if (radioButton_Company.Checked)
                {
                    found = controllerObj.CheckPassword_Company(Convert.ToInt32(TxtBx_username.Text), TxtBx_pass.Text);
                    if (found)
                    {
                        CompanyFunctionalities CF2 = new CompanyFunctionalities();
                        CF2.Show(this);
                        this.Hide();
                    }
                }
                else if (radioButton_Bank.Checked)
                {
                    found = controllerObj.CheckPassword_Bank(TxtBx_username.Text, TxtBx_pass.Text);
                    if (found)
                    {
                        BankFunctionalities BF = new BankFunctionalities();
                        BF.Show(this);
                        this.Hide();
                    }
                }
                else if (radioButton_Admin.Checked)
                {
                    found = controllerObj.CheckPassword_Admin(TxtBx_username.Text, TxtBx_pass.Text);
                    if (found)
                    {
                        AdminFunctionalities AF = new AdminFunctionalities();
                        AF.Show(this);
                        this.Hide();
                    }
                }

                if(!found) MessageBox.Show("WRONG USERNAME OR PASSWORD!!!");
                
            }
            catch
            {
                MessageBox.Show("WRONG USERNAME OR PASSWORD!!!");
            }
            TxtBx_pass.Clear();
            TxtBx_username.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}