using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArenaAlbionuPoradnik.Models
{
    public class User
    {
        public int Id { get; set; }
        public DateTime Regdate { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
    }
}