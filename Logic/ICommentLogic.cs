using Ex9Backend.Database;
using Ex9Backend.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ex9Backend.Logic
{
    public interface ICommentLogic
    {
        Task<bool> AddComment(Comment comment);
        Task<bool> ClearComment();
        Task<List<CommentGetResModel>> getComment();
    }
}