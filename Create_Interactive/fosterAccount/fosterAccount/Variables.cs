using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fosterAccount
{
    public static class Variables
    {
        public static Random random = new Random();


        public static Bitmap // NewsFeed
                             BMP_NextNewsFeed = (Bitmap)Bitmap.FromFile("Data/NewsFeed/button_nextNewsFeed.png"),
                             BMP_LikeNewsFeed = (Bitmap)Bitmap.FromFile("Data/NewsFeed/button_likeNewsFeed.png"),
                             BMP_CheckNewsFeed = (Bitmap)Bitmap.FromFile("Data/NewsFeed/button_checkNewsFeed.png"),
                             // AddFriendSuggestions
                             BMP_AddFriendSuggrestions = (Bitmap)Bitmap.FromFile("Data/AddFriendSuggestions/button_addFriend.png"),
                             // AddFriendRequest
                             BMP_AddFriendRequest = (Bitmap)Bitmap.FromFile("Data/AddFriendRequest/button_confirmFriend.png"),
                             // outGoringFriend
                             BMP_OutGoringFriend = (Bitmap)Bitmap.FromFile("Data/OutGoingFriend/button_outGoingFriend.png"),
                             // checkGroup
                             BMP_JoinGroup = (Bitmap)Bitmap.FromFile("Data/CheckGroup/button_joinGroup.png"),

                             BMP_CancelRequestJoinGroup = (Bitmap)Bitmap.FromFile("Data/CheckGroup/button_cancelRequestJoinGroup.png"),
                             // shareGroup 
                             BMP_ShareGroup = (Bitmap)Bitmap.FromFile("Data/ShareGroup/button_shareGroup.png"),
                             // deleteSharePost
                             BMP_DeleteSharePost = (Bitmap)Bitmap.FromFile("Data/DeleteSharePost/button_deleteSharePost.png"),
                             BMP_ConfirmDeleteSharePost = (Bitmap)Bitmap.FromFile("Data/DeleteSharePost/button_confirmDeleteSharePost.png"),
                             // LikeComment
                             BMP_LikeFanpage = (Bitmap)Bitmap.FromFile("Data/LikeComment/button_likeFanpage.png"),
                             BMP_ReactionsPost = (Bitmap)Bitmap.FromFile("Data/LikeComment/button_reactionsPost.png"),
                             BMP_EditComment = (Bitmap)Bitmap.FromFile("Data/LikeComment/button_editComment.png"),
                             BMP_Comment = (Bitmap) Bitmap.FromFile("Data/LikeComment/button_comment.png");
    }
}
