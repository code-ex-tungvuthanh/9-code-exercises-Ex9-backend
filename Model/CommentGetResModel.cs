using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex9Backend.Model
{
    public class CommentGetResModel
    {
        public string Content { get; set; }
        public string Username { get; set; }
    }
}
