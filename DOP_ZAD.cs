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

namespace WindowsFormsApp2
{
    public partial class DOP_ZAD : Form
    {
        public DOP_ZAD()
        {
            InitializeComponent();
        }


        private void DOP_ZAD_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        string TokenGroup, TokenUser, GroupId;

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

            
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(trackBar1.Value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = Convert.ToString(trackBar2.Value);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //
        //ПОЛУЧЕНИЕ ТОКЕНА ПОЛЬЗОВАТЕЛЯ
        //
        public void AuthData()
        {
            TokenUser = Per.x;
            TokenGroup = Per.y;
            GroupId = Per.z;      
        }

        List<string> birth = new List<string>();
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            var api_p = new VkApi();
            api_p.Authorize(new ApiAuthParams
            {
                AccessToken = Per.x
            });
            var getFriends = api_p.Friends.Get(new FriendsGetParams
            {
                Fields = VkNet.Enums.Filters.ProfileFields.All
            });
            foreach (User user in getFriends) 
                birth.Add(user.BirthDate);
            //textBox1.Text += user.BirthDate + "\r\n";
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
                        {
                            cout++;
                        }
                        if (cout == 2 && us[i] != '.')
                        {
                            year += us[i];
                        }
                    }
                    if (cout == 2 && int.Parse(year) > 1950)
                    {
                        year_n += int.Parse(year);
                        year_cout++;
                        textBox2.Text += year + " " + year_cout + "\r\n";
                    }
                }
            }
            double answ = 2021 - (year_n / year_cout);
            textBox2.Text += "Приблизительный возраст пользователя равен" + answ;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d = monthCalendar1.SelectionRange.Start;
            DateTime f = new DateTime(d.Year, d.Month, d.Day, trackBar1.Value, trackBar2.Value, 0);
            AuthData();
            var api_p = new VkApi();
            api_p.Authorize(new ApiAuthParams
            {
                AccessToken = TokenUser
            }) ;
            var api = new VkApi();
            api.Authorize(new ApiAuthParams
            {
                AccessToken = Per.x
            }) ;
            var post = api.Wall.Post(new WallPostParams
            {
                OwnerId = -205658019,
                FriendsOnly = false,
                FromGroup = false,
                Message = textBox1.Text,
                Signed = true,
                PublishDate = f,
            });
           

        }
        
    }
}
