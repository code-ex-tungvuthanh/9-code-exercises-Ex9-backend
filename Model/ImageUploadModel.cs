using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ex9Backend.Model
{
    public class ImageUploadModel
    {
        [Required]
        public IFormFile Image { get; set; }
    }
}
