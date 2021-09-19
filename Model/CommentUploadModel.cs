using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ex9Backend.Model
{
    public class CommentUploadModel
    {
        public string Content { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
