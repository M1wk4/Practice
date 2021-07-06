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

    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }
        private void Form1_Load(object sender, EventArgs e) { }

        //
        //ВЫЗОВ ОКНА АВТОРИЗАЦИИ
        //

        List<string> sub = new List<string>();
        string TokenUser, TokenGroup, GroupId;
        public void AuthEnter(object sender, EventArgs e)
        {
            AuthForm f1 = new AuthForm();
            f1.ShowDialog();
            AuthData();
        }
        public void AuthData()
        {
            TokenUser = Per.x;
            TokenGroup = Per.y;
            GroupId = Per.z;
			button2.Enabled = true;
			button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            textBox4.ReadOnly = false;
			//var api = new VkApi();
			//api.Authorize(new ApiAuthParams
			//{
			//AccessToken = getAuthForGroup()
			//});
			//var UserName = api.Users.Get(new long[] {302292451}, fields: ProfileFields.Photo100).FirstOrDefault();
			//label3.Text = $"Здравствуйте, {Encoding.UTF8.GetString(Encoding.Default.GetBytes(UserName.FirstName))}!";
            label3.Text = $"Здравствуйте!";
            //var UserPic = api.Photo.Get(new PhotoGetParams
            //{
            //    OwnerId = 302292451,
            //    AlbumId = VkNet.Enums.SafetyEnums.PhotoAlbumType.Profile
            //});
            //pictureBox1.Image = new Image(UserPic.);
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
        //ВЫВОД ИНФОРМАЦИИ О ТЕКУЩЕМ ПОЛЬЗОВАТЕЛЕ (опять сломалось)
        //
        private void getUserInfo(object sender, EventArgs e)
        {
			var api_p = new VkApi();
			api_p.Authorize(new ApiAuthParams
			{
				AccessToken = getAuthForUser()
			});
			var p = api_p.Users.Get(new long[] { Convert.ToInt64(sub[comboBox1.SelectedIndex]) }).FirstOrDefault();
			textBox3.Text = "";
			textBox3.Text += Convert.ToString(p.Id) + "\r\n";
			textBox3.Text += Encoding.UTF8.GetString(Encoding.Default.GetBytes(p.FirstName)) + "\r\n";
			textBox3.Text += Encoding.UTF8.GetString(Encoding.Default.GetBytes(p.LastName)) + "\r\n";

			//textBox3.Text += Encoding.UTF8.GetString(Encoding.Default.GetBytes(p.About));
			//textBox3.Text += Encoding.UTF8.GetString(Encoding.Default.GetBytes(p.City.Title)) + "\r\n";
			//UserPost f = new UserPost();
			//f.Show();
        }

        //
        //СПИСОК УЧАСТНИКОВ СООБЩЕСТВА
        //
        private void GroupMemberList(object sender, EventArgs e)
        {
            textBox1.Text = "";
			var api_group = new VkApi();
            api_group.Authorize(new ApiAuthParams
            {
                AccessToken = getAuthForGroup()
            });
            var getFollowers = api_group.Groups.GetMembers(new GroupsGetMembersParams()
            {
				GroupId = GroupId,
				Fields = VkNet.Enums.Filters.UsersFields.FirstNameAbl
            });
            foreach (User user in getFollowers)
            {
                textBox1.Text += Encoding.UTF8.GetString(Encoding.Default.GetBytes(user.FirstName + " " + user.LastName)) + "\r\n";
                sub.Add(Convert.ToString(user.Id));    
                comboBox1.Items.Add(Encoding.UTF8.GetString(Encoding.Default.GetBytes(user.FirstName + " " + user.LastName)) + "\r\n");
            }
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

        //
        //ДОБАВЛЕНИЕ ПУБЛИКАЦИИ НА СТЕНУ СООБЩЕСТВА
        //

        public void GroupPost(object sender, EventArgs e)
        {
            var api = new VkApi();
            api.Authorize(new ApiAuthParams
            {
                AccessToken = getAuthForUser()
            });
            var post = api.Wall.Post(new WallPostParams
            {
                OwnerId = -205658019,
                FriendsOnly = false,
                FromGroup = true,
                Message = textBox4.Text,
                Signed = true,
            });


            //РЕПОСТ!!


            //var post2 = api.Wall.Repost(@object: "wall302292451_919", message: "ku", groupId: 205658019, markAsAds: false);


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
    }
}
//c481d9e12c2d0fbc1dff4ce14c339dfc2c2536952a7045bf8f09ce2b2e38b3f9729140d0a15ad9a3631a3 Коля
//be66d05559f96dfb1c6f972b73d7797361c92956fcc6a2e4b06c23bcb28b4f1ab24aa37a87b7acee42a00 Дмитрий
//b2f32b361f740ad7111a5dab37948aa90a7c190fcc3313d5858bc3813c980d5fc93c7ee1688f0d1c48fea Новый Дмитрий
//12684541386004b8b73f2c0a17d5f779ab8bde09c3e387895b8d438b0f020b090eaf4e63045bdd3ba9f98 Группа

//var post2 = api.Wall.Repost(@object: "wall302292451_919", message: "ku", groupId: 205658019, markAsAds: false);
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