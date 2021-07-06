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
        //
        //ПОЛУЧЕНИЕ ТОКЕНА ПОЛЬЗОВАТЕЛЯ
        //
        public void AuthData()
        {
            TokenUser = Per.x;
            TokenGroup = Per.y;
            GroupId = Per.z;      
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            AuthData();
            var api_p = new VkApi();
            api_p.Authorize(new ApiAuthParams
            {
                AccessToken = TokenUser
            }) ;
            var api = new VkApi();
            api.Authorize(new ApiAuthParams
            {
                AccessToken = "e240830f3e8e8eae25787506858a898893308c0c36a3a57c4ced7fe36432940522ca8e1483cc5fa633bd3"
            });
            int unixTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            textBox1.Text = Convert.ToString(unixTime);
            var post = api.Wall.Post(new WallPostParams
            {
                OwnerId = -205658019,
                FriendsOnly = false,
                FromGroup = false,
                Message = "ЛОЛ",
                Signed = true,
                PublishDate = new DateTime(,
            }); 
            

        }
    }
}
