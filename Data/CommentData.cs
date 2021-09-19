using Ex9Backend.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex9Backend.Data
{
    public class CommentData : ICommentData
    {
        private readonly CommentContext dbContext;
        public CommentData()
        {
            dbContext = new CommentContext();
        }

        public async Task<List<Comment>> GetComment()
        {
            return await dbContext.Comments.ToListAsync();
        }

        public async Task<Comment> AddComment(Comment comment)
        {
            dbContext.Comments.Add(comment);
            await dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<bool> ClearComment()
        {
            await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM Comments");
            await dbContext.Database.ExecuteSqlRawAsync("VACUUM");
            return true;
        }
    }
}
