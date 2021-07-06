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
			textBox1.Text = "c481d9e12c2d0fbc1dff4ce14c339dfc2c2536952a7045bf8f09ce2b2e38b3f9729140d0a15ad9a3631a3";



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
