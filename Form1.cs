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
			textBox7.ReadOnly = false;
			textBox8.ReadOnly = false;
			var api = new VkApi();
			api.Authorize(new ApiAuthParams
			{
				AccessToken = getAuthForUser()
			});
			var UserName = api.Account.GetProfileInfo();
			label3.Text = $"Здравствуйте, {Encoding.UTF8.GetString(Encoding.Default.GetBytes(UserName.FirstName))}!";
			pictureBox1.Visible = true;
			pictureBox2.Visible = false;
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
			var p = api_p.Users.Get(new long[] { Convert.ToInt64(sub[comboBox1.SelectedIndex]) }, VkNet.Enums.Filters.ProfileFields.Counters).FirstOrDefault();
			textBox3.Text = "";
			textBox3.Text += $"ID: {p.Id.ToString()}\r\n";
			textBox3.Text += $"Имя: {Encoding.UTF8.GetString(Encoding.Default.GetBytes(p.FirstName))}\r\n";
			textBox3.Text += $"Фамилия: {Encoding.UTF8.GetString(Encoding.Default.GetBytes(p.LastName))}\r\n";
			if (Convert.ToInt32(p.Sex) == 2)
				textBox3.Text += $"Пол: мужской\r\n";
			else if (Convert.ToInt32(p.Sex) == 1)
				textBox3.Text += $"Пол: женский\r\n";
			else
				textBox3.Text += $"Пол: не указан\r\n";

			if (p.Counters.Friends > 0)
				textBox3.Text += $"Кол-во друзей: {p.Counters.Friends} \r\n";
			else
				textBox3.Text += $"Кол-во друзей: скрыты \r\n";

			if (p.Counters.Followers > 0)
				textBox3.Text += $"Кол-во подписчиков: {p.Counters.Followers} \r\n";
			else
				textBox3.Text += $"Кол-во подписчиков: скрыты \r\n";

			if (p.Counters.Groups > 0)
				textBox3.Text += $"Кол-во сообществ: {p.Counters.Groups} \r\n";
			else
				textBox3.Text += $"Кол-во сообществ: скрыты \r\n";
		}

		//
		//СПИСОК УЧАСТНИКОВ СООБЩЕСТВА
		//
		private void GroupMemberList(object sender, EventArgs e)
		{
			textBox1.Text = "";
			if (comboBox1.Items.Count > 0)
			{
				comboBox1.Items.Clear();
				sub.Clear();
			}
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
			if (comboBox1.Items.Count > 0)
			{
				comboBox1.Items.Clear();
				sub.Clear();
			}
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
					OwnerId = -(Convert.ToInt64(GroupId)),
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
					OwnerId = -(Convert.ToInt64(GroupId)),
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
		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			//if (Char.IsDigit(e.KeyChar)) return;
			//else
			//	e.Handled = true;
		}

		private void ClockTick(object sender, EventArgs e)
		{
			label17.Text = DateTime.Now.AddSeconds(1).ToString();
		}

		//
		//ВЫВОД ТЕКСТОВ ПОСЛЕДНИХ ТРЁХ ПОСТОВ ПОЛЬЗОВАТЕЛЯ
		//
		private void TextUserPosts(object sender, EventArgs e)
		{
			textBox9.Text = "";
			int k = 1;
			var api = new VkApi();
			api.Authorize(new ApiAuthParams
			{
				AccessToken = Per.x
			});
			var get = api.Wall.Get(new WallGetParams
			{
				OwnerId = int.Parse(textBox8.Text),
				Count = 3,
				Filter = VkNet.Enums.SafetyEnums.WallFilter.Owner
			});
			if (get.WallPosts.Count==0)
			{
				textBox9.Text = "Постов нет!";
				return;
			}
			foreach (var wallPost in get.WallPosts)
			{
				if (Encoding.UTF8.GetString(Encoding.Default.GetBytes(wallPost.Text)).Length == 0)
					textBox9.Text += $"{k}-й пост:\r\nТекст отсутствует!\r\n";
				else
					textBox9.Text += $"{k}-й пост:\r\n{Encoding.UTF8.GetString(Encoding.Default.GetBytes(wallPost.Text))}\r\n";
				k++;
			}
		}

		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			checkBox1.Visible = checkBox3.Checked;
		}

		//
		//ВЫЧИСЛЕНИЕ ПРИБЛИЗИТЕЛЬНОГО ВОЗРАСТА
		//
		List<string> birth = new List<string>();
		private void AgeOutput(object sender, EventArgs e)
		{
			if (textBox7.TextLength == 0)
				return;
			textBox6.Text = "";
			var api_p = new VkApi();
			api_p.Authorize(new ApiAuthParams
			{
				AccessToken = Per.x
			});

			var getFriends = api_p.Friends.Get(new FriendsGetParams
			{
				UserId = int.Parse(textBox7.Text),
				Fields = VkNet.Enums.Filters.ProfileFields.All
			}) ;
			foreach (User user in getFriends)
				birth.Add(user.BirthDate);
			int cout;
			string year;
			int year_n, year_cout;
			year_cout = 0;
			year_n = 0;
			foreach (string us in birth)
			{
				if (us != null)
				{
					year = "";
					cout = 0;
					for (int i = 0; i < us.Length; i++)
					{
						if (us[i] == '.')
							cout++;
						if (cout == 2 && us[i] != '.')
							year += us[i];
					}
					if (cout == 2 && int.Parse(year) > 1930)
					{
						year_n += int.Parse(year);
						year_cout++;
						textBox6.Text += $"{year_cout}-й пользователь, {year} год\r\n";
					}
				}
			}
			double answ = 2021 - (year_n / year_cout);
			textBox6.Text += $"==========\r\nПриблизительный возраст пользователя равен {answ}";
		}
	}
}