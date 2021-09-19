using Ex9Backend.Data;
using Ex9Backend.Database;
using Ex9Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex9Backend.Logic
{
    public class CommentLogic : ICommentLogic
    {
        private readonly ICommentData commentData;
        private readonly IUserData userData;
        public CommentLogic(ICommentData commentData, IUserData userData)
        {
            this.commentData = commentData;
            this.userData = userData;
        }

        public async Task<List<CommentGetResModel>> getComment()
        {
            List<Comment> commentList = await commentData.GetComment();
            List<CommentGetResModel> commentResModelList = new List<CommentGetResModel>();

            foreach (Comment comment  in commentList) {
                User user = await userData.GetUserById(comment.UserId);
                commentResModelList.Add(new CommentGetResModel {
                    Content = comment.Content,
                    Username = user.Username
                });
            }

            return commentResModelList;
        }

        public async Task<bool> ClearComment()
        {
            await commentData.ClearComment();
            return true;
        }

        public async Task<bool> AddComment(Comment comment)
        {
            await commentData.AddComment(comment);

            return true;
        }
    }
}
