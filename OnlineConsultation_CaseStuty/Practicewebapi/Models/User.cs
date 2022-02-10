using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Practicewebapi.Models
{
    public partial class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PhNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
