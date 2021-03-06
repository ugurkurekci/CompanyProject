﻿using Business.Concrete;
using DataAccess.Concrete.Entity_Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinForms.Forms.Product
{
    public partial class ProductDataForm : Form
    {
        public ProductDataForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        bool move;
        int mouse_x;
        int mouse_y;
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void refreshbtn_Click(object sender, EventArgs e)
        {
            bringdatatolist();
        }
        public void bringdatatolist()
        {
            ProductRegistrationManager manager = new ProductRegistrationManager(new EfProductRegistrationDAL());
            dataGridView1.DataSource = manager.GetAll().Data;
            countlbl.Text = dataGridView1.Rows.Count.ToString();
        }

        private void ProductDataForm_Load(object sender, EventArgs e)
        {
            bringdatatolist();
        }

        private void clickbtn_Click(object sender, EventArgs e)
        {
            ProductDeleteForm form = new ProductDeleteForm();
            form.no = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            form.name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            form.price = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            form.quantity = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            form.Image = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            form.Show();

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            ProductUpdateForm form = new ProductUpdateForm();
            form.no = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            form.name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            form.price = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            form.quantity = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            form.Image = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            form.Show();

        }
    }
}
