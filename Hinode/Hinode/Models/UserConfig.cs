using Hinode.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Hinode.Models
{
    public class UserConfig 
    {

        public int Id { get; set; }

        [Column(TypeName = "varchar(450)")]
        [Required]
        public string UserId { get; set; }

        public int UserCategoryId { get; set; }

        [DisplayName("ユーザー略名")]
        [MaxLength(20, ErrorMessage = "名前は10文字以内でお願いします")]
        public string NickName { get; set; }






    }
}
