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
		public AuthForm() { InitializeComponent(); }
		private void AuthForm_Load(object sender, EventArgs e) { }

		//
		//ПОДТВЕРЖДЕНИЕ И ВЫХОД ИЗ ОКНА АВТОРИЗАЦИИ
		//

		private void AuthAccept(object sender, EventArgs e)
		{
			Form1 f1 = new Form1();
			f1.TokenUser = textBox1.Text;
			f1.TokenGroup = textBox2.Text;
			f1.GroupId = textBox3.Text;
			//f1.AuthData(textBox1.Text, textBox2.Text, textBox3.Text);
			this.Close();
		}
	}
}
