﻿using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.Entity_Framework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinForms.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        bool move;
        int mouse_x;
        int mouse_y;
        private void Headerpnl_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Headerpnl_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Headerpnl_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void exitpng_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void SignInbtn_Click(object sender, EventArgs e)
        {
            string username = usernametxb.Text;
            string password = passwordtxb.Text;

            AdminManager manager = new AdminManager(new EfAdminDAL());
            var login = manager.GetAdminLogin(username, password).Data;
            if (login != null)
            {
                MessageBox.Show(Messages.Succes);
                Panel panel = new Panel();
                panel.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show(Messages.ErrorAdded);

            }

        }

        private void Headerpnl_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
