using Ex9Backend.Database;
using Ex9Backend.Logic;
using Ex9Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex9Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IUserLogic userLogic;
        private readonly IImageLogic imageLogic;
        private readonly ICommentLogic commentLogic;

        public CommentController(IUserLogic userLogic, IImageLogic imageLogic, ICommentLogic commentLogic)
        {
            this.userLogic = userLogic;
            this.imageLogic = imageLogic;
            this.commentLogic = commentLogic;
        }

        [HttpGet("GetUser")]
        public async Task<List<UserGetResModel>> GetUser() {
            List<User> users = await userLogic.GetUser();
            List<UserGetResModel> userGetRes = users.Select(x => new UserGetResModel
            {
                Id = x.UserId,
                Username = x.Username
            }).ToList();

            return userGetRes;
        }

        [HttpPost("UploadComment")]
        public async Task<ActionResult> UploadComment([FromBody] CommentUploadModel commentUploadModel)
        {
            Comment comment = new Comment
            {
                Content = commentUploadModel.Content,
                UserId = commentUploadModel.UserId
            };

            await commentLogic.AddComment(comment);

            return Ok();
        }

        [HttpGet("GetComment")]
        public async Task<List<CommentGetResModel>> GetComment()
        {
            List<CommentGetResModel> commentGetList = await commentLogic.getComment();

            return commentGetList;
        }

        [HttpGet("ClearComment")]
        public async Task<ActionResult> ClearComment()
        {
            await commentLogic.ClearComment();

            return Ok();
        }


        [HttpPost("UploadImage")]
        public async Task<ImageUploadResModel> UploadImage([FromForm] ImageUploadModel imageUploadModel)
        {
            string imageUrl = await imageLogic.SaveImage(imageUploadModel.Image);

            return new ImageUploadResModel { ImageUrl = imageUrl };
        }
    }
}
