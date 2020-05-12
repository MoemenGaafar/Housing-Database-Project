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

namespace Housing_Database_Project.Sign_Up_Forms
{
   
    public partial class SignUpBank : Form
    {
        private Controller controllerObj;
        public SignUpBank()
        {
            controllerObj = new Controller();
            InitializeComponent();
            foreach (Control c in Controls)
                c.Hide();
            title.Show();
            L1.Show();
            button_Back.Show();
            Verify.Show();
            Access.Show(); 
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SignUpBank_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                Owner.Show();
        }

        private void checkBox_Devil_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Devil.Checked) Btn_SignUp.Enabled = true;
            else Btn_SignUp.Enabled = false;
        }

        private void Btn_SignUp_Click(object sender, EventArgs e)
        {
            if (textBox_Name.Text == "" || textBox_Pass.Text == "" || textBox_TransFees.Text == "")
                MessageBox.Show("Please fill all the required fields!");
            else if (textBox_Pass.Text != textBox_PassAgain.Text)
                MessageBox.Show("Passwords must match!");
            else if (Convert.ToInt32(textBox_TransFees.Text) > 256 || Convert.ToInt32(textBox_TransFees.Text) < 0)
                MessageBox.Show("Transaction Fees cannot be negative or more than 256 EGP!");
            else
            {
                int r = controllerObj.SignUpBank(textBox_Name.Text, textBox_Pass.Text, Convert.ToInt32(textBox_TransFees.Text));
                if (r > 0)
                    MessageBox.Show("Bank Signed Up Successfully!");
                else
                    MessageBox.Show("Error Encoutered While Signing up...");
            }
        }

        private void Verify_Click(object sender, EventArgs e)
        {
            string Pass = Convert.ToString(controllerObj.GetAccess("Bank").Rows[0][0]);
            if (Access.Text != Pass)
                MessageBox.Show("Incorrect Pass code.");
            else
            {
                foreach (Control c in Controls)
                    c.Show();
                L1.Hide();
                button_Back.Hide();
                Verify.Hide();
                Access.Hide();
            }
        }
    }
}
