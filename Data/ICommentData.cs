using Ex9Backend.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ex9Backend.Data
{
    public interface ICommentData
    {
        Task<Comment> AddComment(Comment comment);
        Task<bool> ClearComment();
        Task<List<Comment>> GetComment();
    }
}