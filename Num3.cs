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
	class Num3
	{
        Object FollowerList;
        public void GroupMemberList()
        {
            var api_group = new VkApi();
            api_group.Authorize(new ApiAuthParams
            {
                AccessToken = Form1.getAuthForGroup()
            });
            var getFollowers = api_group.Groups.GetMembers(new GroupsGetMembersParams()
            {
                GroupId = "205658019",
                Fields = VkNet.Enums.Filters.UsersFields.FirstNameAbl
            });
            FollowerList = getFollowers;
        }
        public void MemberPostList()
		{
            var _api = new VkApi();
		}
        public void MemberRepost()
		{

		}
    }
}
