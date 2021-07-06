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
			//textBox1.Text = "a63681bbd9958a69dfa657420be5cd2214f5545d88a0e6e15308db11f8e101c8305f75a35a1be4c08b585";
			Per.x = textBox1.Text;
			Per.y = textBox2.Text;
			Per.z = textBox3.Text;
			this.Hide();
		}
    }
}
