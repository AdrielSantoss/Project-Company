using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class UserDto
    {
        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
