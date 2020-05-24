using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hinode.Models
{
    public class UserDiv
    {
        [Key]
        public int Id { get; set; }

        public int UserConfigId { get; set; }

        [DisplayName("区分名")]
        [MaxLength(40, ErrorMessage = "区分名は20文字以内でお願いします")]
        public string Name { get; set; }


    }
}
