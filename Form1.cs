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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        public static string getAuthForGroup()
        {
            string fileName = @"auth_vk.txt";
            string token = "";
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    
                    token = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return token;
        }
        public static string getAuthForUser()
        {
            string fileName = @"auth_vk.txt";
            string token = "";
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    sr.ReadLine();
                    token = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return token;
        }
        private void button1_Click(object sender, EventArgs e)
        {   
            label1.Text = getAuthForGroup();
            var api_group = new VkApi();
            api_group.Authorize(new ApiAuthParams
            {
                AccessToken = getAuthForGroup()
            });
        }
        private void button2_Click(object sender, EventArgs e)
		{
            var api_group = new VkApi();
            api_group.Authorize(new ApiAuthParams
            {
                AccessToken = getAuthForGroup()
            });
			var api_user = new VkApi();
			//api_user.Authorize(new ApiAuthParams
			//{
			//	AccessToken = getAuthForUser()
			//});
            var getFollowers = api_group.Groups.GetMembers(new GroupsGetMembersParams()
            {
                GroupId = "205658019",
				Fields = VkNet.Enums.Filters.UsersFields.FirstNameAbl
			});
            foreach (User user in getFollowers)
                textBox1.Text += Encoding.UTF8.GetString(Encoding.Default.GetBytes(user.FirstName)) + "\r\n";
        }
        private void button3_Click(object sender, EventArgs e)
        {
			var api_p = new VkApi();
			api_p.Authorize(new ApiAuthParams
			{
				//AccessToken = "c481d9e12c2d0fbc1dff4ce14c339dfc2c2536952a7045bf8f09ce2b2e38b3f9729140d0a15ad9a3631a3" //Коли?
				AccessToken = "be66d05559f96dfb1c6f972b73d7797361c92956fcc6a2e4b06c23bcb28b4f1ab24aa37a87b7acee42a00"   //Дмитрия
			});

			var getFriends = api_p.Friends.Get(new FriendsGetParams
			{
				Fields = VkNet.Enums.Filters.ProfileFields.All
			});
			foreach (User user in getFriends)
                textBox2.Text += Encoding.UTF8.GetString(Encoding.Default.GetBytes(user.FirstName)) + "\r\n";
        }

		private void button4_Click(object sender, EventArgs e)
		{
            var api_p = new VkApi();
            api_p.Authorize(new ApiAuthParams
            {
                AccessToken = "be66d05559f96dfb1c6f972b73d7797361c92956fcc6a2e4b06c23bcb28b4f1ab24aa37a87b7acee42a00"   //Дмитрия
            });
            //var k = api_p.Wall.Get(new WallGetParams
            //{
            //    Fields = VkNet.Enums.Filters.NewsTypes.Post
            //});
			textBox3.Text= api_p.Wall.Get(new WallGetParams
            {
                Fields = VkNet.Enums.Filters.NewsTypes.Post
            }).ToString();
            //foreach (User user in k)
            //	//textBox3.Text += k.ToString();
            //             textBox3.Text += Encoding.UTF8.GetString(Encoding.Default.GetBytes(user.k)) + "\r\n";
        }
	}
}
