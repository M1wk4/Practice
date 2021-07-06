using System;
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
		public AuthForm() 
		{ 
			InitializeComponent(); 
		}
		private void AuthForm_Load(object sender, EventArgs e) { }

		//
		//ПОДТВЕРЖДЕНИЕ И ВЫХОД ИЗ ОКНА АВТОРИЗАЦИИ
		//
		
		public void AuthAccept(object sender, EventArgs e)
		{
			textBox1.Text = "acb47053aafd4368e034580c21a3dc7673bc965ad4424d98f73f8742a6d29df16d74a4357927e21366bd7";



			Per.x = textBox1.Text;
			Per.y = textBox2.Text;
			Per.z = textBox3.Text;
			this.Hide();
		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
		
        }
    }
}
