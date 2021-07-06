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
using VkNet.Enums.Filters;
using System.IO;
namespace WindowsFormsApp2
{
	public partial class UserPost : Form
	{
		public UserPost() { InitializeComponent(); }
		private void UserPost_Load(object sender, EventArgs e) { }

		//
		//ВЫВОД ПУБЛИКАЦИЙ ПОЛЬЗОВАТЕЛЯ
		//

		public void k()
		{
			Form1 f1 = new Form1();

			var api = new VkApi();
			api.Authorize(new ApiAuthParams
			{
				AccessToken = "e240830f3e8e8eae25787506858a898893308c0c36a3a57c4ced7fe36432940522ca8e1483cc5fa633bd3"
			});
			//var p = api.Users.Get(new long[] { 1 }).FirstOrDefault();
			//MessageBox.Show(Encoding.UTF8.GetString(Encoding.Default.GetBytes(p.FirstName)));


			var post = api.Wall.Post(new WallPostParams
			{
				OwnerId = -205658019,
				FriendsOnly = false,
				FromGroup = false,
				Message = "ЛОЛ",
				Signed = true,
				
			});
			MessageBox.Show(Encoding.UTF8.GetString(Encoding.Default.GetBytes(post.ToString())));

			

			
			//wall302292451_919
			//- 205658019)

			//var post = api.Wall.Post(new WallPostParams
			//{
			//	OwnerId = 302292451,
			//	Message = "k",
			//});
			//MessageBox.Show(Encoding.UTF8.GetString(Encoding.Default.GetBytes(post.ToString())));

			//var post2 = api.Wall.Post(new WallPostParams
			//{

			//	OwnerId = -205658019,
			//	PostId = 2,
			//	Message = "Хыыыы"
			//});
			//var post2 = api.Wall.GetById(posts: -205658019_2,-205658019_1);
			//MessageBox.Show(Encoding.UTF8.GetString(Encoding.Default.GetBytes(post2.WallPosts[0].Text)));
			//MessageBox.Show(Encoding.UTF8.GetString(Encoding.Default.GetBytes(post2.ToString())));
		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
			
        }

        private void button1_Click(object sender, EventArgs e)
        {
		

        }
    }
}
