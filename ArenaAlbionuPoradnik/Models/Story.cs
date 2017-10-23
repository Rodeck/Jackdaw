using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArenaAlbionuPoradnik.Models
{
    public class Story
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime Regdate { get; set; }

        public virtual User User { get; set; }
    }
}