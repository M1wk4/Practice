﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;
using System.IO;
namespace WindowsFormsApp2
{
	
	public partial class AuthForm : Form
	{
		public AuthForm() { InitializeComponent(); }
		private void AuthForm_Load(object sender, EventArgs e) { }

		//
		//ПОДТВЕРЖДЕНИЕ И ВЫХОД ИЗ ОКНА АВТОРИЗАЦИИ
		//
		
		public void AuthAccept(object sender, EventArgs e)
		{
			Per.x = textBox1.Text;
			Per.y = textBox2.Text;
			Per.z = textBox3.Text;
			this.Close();
		}

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
