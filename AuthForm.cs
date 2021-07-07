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
		public AuthForm() { InitializeComponent(); //this.ControlBox = false; 
		}
		private void AuthForm_Load(object sender, EventArgs e) { }

		//
		//ПОДТВЕРЖДЕНИЕ И ВЫХОД ИЗ ОКНА АВТОРИЗАЦИИ
		//
		public void AuthAccept(object sender, EventArgs e)
		{
			if ((textBox1.Text.Length == 0)|| (textBox2.Text.Length == 0) ||(textBox3.Text.Length == 0))
			{
				MessageBox.Show("Не все данные введены!");
				return;
			}
			Per.x = textBox1.Text;
			Per.y = textBox2.Text;
			Per.z = textBox3.Text;
			this.Close();
		}

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
