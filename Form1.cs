using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;
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
			if ((Per.x != null) && (Per.y != null) && (Per.z != null))
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
			button6.Enabled = true;
			button7.Enabled = true;
			checkBox1.Enabled = true;
			checkBox2.Enabled = true;
			checkBox3.Enabled = true;
			checkBox4.Enabled = true;
			checkBox5.Enabled = true;
			textBox2.ReadOnly = false;
			textBox4.ReadOnly = false;
			textBox5.ReadOnly = false;
			textBox6.ReadOnly = false;
			var api = new VkApi();
			api.Authorize(new ApiAuthParams
			{
				AccessToken = getAuthForUser()
			});

			//var UserName = api.Users.Get(new long[] { api.UserId.Value }).FirstOrDefault();
			//label3.Text = $"Здравствуйте, {Encoding.UTF8.GetString(Encoding.Default.GetBytes(UserName.FirstName))}!";

			label3.Text = $"Здравствуйте!";
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
		//ВЫВОД ИНФОРМАЦИИ О ТЕКУЩЕМ ПОЛЬЗОВАТЕЛЕ
		//
		private void getUserInfo(object sender, EventArgs e)
		{
			var api_p = new VkApi();
			api_p.Authorize(new ApiAuthParams
			{
				AccessToken = getAuthForUser()
			});
			if (comboBox1.Text.Length == 0)
				return;
			var p = api_p.Users.Get(new long[] { Convert.ToInt64(sub[comboBox1.SelectedIndex]) }).FirstOrDefault();
			textBox3.Text = "";
			textBox3.Text += $"ID: {p.Id.ToString()}\r\n";
			textBox3.Text += $"Имя: {Encoding.UTF8.GetString(Encoding.Default.GetBytes(p.FirstName))}\r\n";
			textBox3.Text += $"Фамилия: {Encoding.UTF8.GetString(Encoding.Default.GetBytes(p.LastName))}\r\n";
		}

		//
		//СПИСОК УЧАСТНИКОВ СООБЩЕСТВА
		//
		private void GroupMemberList(object sender, EventArgs e)
		{
			textBox1.Text = "";
			if (comboBox1.Items.Count > 0)
				comboBox1.Items.Clear();
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

		private void checkBox4_CheckedChanged(object sender, EventArgs e)
		{
			groupBox1.Visible = checkBox4.Checked;
		}
		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			label7.Text = trackBar1.Value.ToString();
		}
		private void trackBar2_Scroll(object sender, EventArgs e)
		{
			label8.Text = trackBar2.Value.ToString();
		}

		//
		//СПИСОК ДРУЗЕЙ
		//
		private void FriendList(object sender, EventArgs e)
		{
			textBox1.Text = "";
			if (comboBox1.Items.Count >= 0)
				comboBox1.Items.Clear();
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
			{
				textBox1.Text += Encoding.UTF8.GetString(Encoding.Default.GetBytes(user.FirstName + " " + user.LastName)) + "\r\n";
				sub.Add(Convert.ToString(user.Id));
				comboBox1.Items.Add(Encoding.UTF8.GetString(Encoding.Default.GetBytes(user.FirstName + " " + user.LastName)) + "\r\n");
			}
		}

		//
		//ДОБАВЛЕНИЕ ПУБЛИКАЦИИ НА СТЕНУ СООБЩЕСТВА
		//
		public void GroupPost(object sender, EventArgs e)
		{
			var api = new VkApi();
			DateTime d = monthCalendar1.SelectionRange.Start;
			DateTime f = new DateTime(d.Year, d.Month, d.Day, trackBar1.Value, trackBar2.Value, 0);
			api.Authorize(new ApiAuthParams
			{
				AccessToken = getAuthForUser()
			});
			if (textBox4.Text.Length == 0)
				return;
			if (checkBox4.Checked)
			{
				var post = api.Wall.Post(new WallPostParams
				{
					OwnerId = -205658019,
					FriendsOnly = checkBox2.Checked,
					FromGroup = checkBox3.Checked,
					Message = textBox4.Text,
					Signed = checkBox1.Checked,
					PublishDate = f
				});
			}
			else
			{
				var post = api.Wall.Post(new WallPostParams
				{
					OwnerId = -205658019,
					FriendsOnly = checkBox2.Checked,
					FromGroup = checkBox3.Checked,
					Message = textBox4.Text,
					Signed = checkBox1.Checked,
				});
			}
		}

		//
		//РЕПОСТ В ГРУППУ
		//
		private void GroupRepost(object sender, EventArgs e)
		{
			var api = new VkApi();
			api.Authorize(new ApiAuthParams
			{
				AccessToken = getAuthForUser()
			});
			if (textBox2.Text.Length == 0)
				return;
			var repost = api.Wall.Repost(@object: $"wall{textBox2.Text}", message: $"{textBox5.Text}", groupId: Convert.ToInt64(GroupId), markAsAds: checkBox5.Checked);
		}
	}
}