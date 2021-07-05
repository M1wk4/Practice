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
            int i = 1;
            foreach (User user in getFollowers)
            {
                textBox1.Text += i.ToString();
                i++;
            }
				//textBox1.Text = user.FirstName;
        }
	}
}
