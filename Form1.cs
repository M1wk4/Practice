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
        public Form1() { InitializeComponent(); }
        private void Form1_Load(object sender, EventArgs e) { }

        //
        //ВЫЗОВ ОКНА АВТОРИЗАЦИИ
        //

        string TokenUser, TokenGroup, GroupId;
        private void button1_Click(object sender, EventArgs e)
        {
            AuthForm f1 = new AuthForm();
            f1.ShowDialog();
            TokenUser = "be66d05559f96dfb1c6f972b73d7797361c92956fcc6a2e4b06c23bcb28b4f1ab24aa37a87b7acee42a00";
            TokenGroup = "12684541386004b8b73f2c0a17d5f779ab8bde09c3e387895b8d438b0f020b090eaf4e63045bdd3ba9f98";
            GroupId = "205658019";
        }
        public void AuthData(string x, string y, string z)
		{
            TokenUser = x;
            TokenGroup = y;
            GroupId = z;
            //MessageBox.Show($"{TokenUser}");
            //button2.Enabled = true;
            //button3.Enabled = true;
            //label3.Text = "ddd";
        }

        //
        //ПОЛУЧЕНИЕ ТОКЕНА ГРУППЫ
        //

        public string getAuthForGroup()
        {
            string token = "";
            try
            {
                token = TokenGroup;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return token;
        }

        //
        //ПОЛУЧЕНИЕ ТОКЕНА ПОЛЬЗОВАТЕЛЯ
        //

        public string getAuthForUser()
        {
            string token = "";
            try
            {
                token = TokenUser;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return token;
        }

		//
		//СПИСОК УЧАСТНИКОВ СООБЩЕСТВА
		//

		private void GroupMemberList(object sender, EventArgs e)
        {
            MessageBox.Show($"{TokenUser}");
            textBox1.Text = "";
			var api_group = new VkApi();
            api_group.Authorize(new ApiAuthParams
            {
                AccessToken = getAuthForGroup()
            });
            var getFollowers = api_group.Groups.GetMembers(new GroupsGetMembersParams()
            {
				//GroupId = "205658019",
				GroupId = GroupId,
				Fields = VkNet.Enums.Filters.UsersFields.FirstNameAbl
            });
            foreach (User user in getFollowers)
                textBox1.Text += Encoding.UTF8.GetString(Encoding.Default.GetBytes(user.FirstName + " " + user.LastName)) + "\r\n";
        }

        //
        //СПИСОК ДРУЗЕЙ
        //

		private void FriendList(object sender, EventArgs e)
		{
            textBox2.Text = "";
            var api_p = new VkApi();
            api_p.Authorize(new ApiAuthParams
            {
                AccessToken = getAuthForUser()
            });
            var getFriends = api_p.Friends.Get(new FriendsGetParams
            {
                Fields = VkNet.Enums.Filters.ProfileFields.All
            });
            foreach (User user in getFriends)
                textBox2.Text += Encoding.UTF8.GetString(Encoding.Default.GetBytes(user.FirstName + " " + user.LastName)) + "\r\n";
        }


	}
}
//c481d9e12c2d0fbc1dff4ce14c339dfc2c2536952a7045bf8f09ce2b2e38b3f9729140d0a15ad9a3631a3 Коля
//be66d05559f96dfb1c6f972b73d7797361c92956fcc6a2e4b06c23bcb28b4f1ab24aa37a87b7acee42a00 Дмитрий
//12684541386004b8b73f2c0a17d5f779ab8bde09c3e387895b8d438b0f020b090eaf4e63045bdd3ba9f98 Группа