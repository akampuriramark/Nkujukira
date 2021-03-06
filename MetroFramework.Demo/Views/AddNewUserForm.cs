﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Diagnostics;
using Nkujukira.Demo.Managers;
using Nkujukira.Demo.Entitities;
using Nkujukira.Demo.Factories;
using MetroFramework;

namespace Nkujukira.Demo
{
    public partial class AddNewUserForm : MetroForm
    {

        public AddNewUserForm()
        {
            InitializeComponent();
            this.Style = MetroColorStyle.Red;
        }

        private void AddNewUser_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void changeloginCredentials_Click(object sender, EventArgs e)
        {

            try
            {
                String username     = user_name.Text;
                String password     = pass_word.Text;
                String type         = role.Text;
                String email        = email_textbox.Text;
                String phone_number = phone_textbox.Text;
                if (username.Length<=0)
                {
                    MessageBox.Show(this, "Please Enter your Name", "ERROR");
                }
                else if (password.Length<= 0)
                {
                    MessageBox.Show(this, "Please Enter Your Password", "ERROR");
                }
                else
                {
                    if (pass_word.Text.Equals(confirm_password.Text))
                    {

                        if (AdminManager.Exists(username))
                        {
                            MessageBox.Show(this, "User Name already Exists. Please try again", "ERROR");

                        }
                        else
                        {
                            Admin new_admin = new Admin(username, password,email,phone_number, type);
                            if (AdminManager.Save(new_admin))
                            {
                                MessageBox.Show(this, "New User Created Successfully", "CONGRATULATIONS");
                            }
                            else
                            {
                                MessageBox.Show(this, "Unexpected error occured. Please try again", "ERROR");
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Please try to confirm your Password\n Passwords dont Match", "ERROR");
                    }
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void user_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
