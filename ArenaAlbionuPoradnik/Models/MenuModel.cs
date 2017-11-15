using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArenaAlbionuPoradnik.Models
{
    public class MenuModel: DatabaseItem
    {
        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public bool Active { get; set; }
        public SiteState State { get; set; }
        public bool isLogged { get; set; }

    }

    public class MenuItem: DatabaseItem
    {
        public string Text { get; set; }
        public virtual ICollection<MenuSubItem> SubItems { get; set; }
    }

    public class MenuSubItem: DatabaseItem
    {
        public string Text { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int? Value { get; set; }
        public string ValueS { get; set; }
    }

    public enum SiteState
    {
        LogedOut,
        LogedIn
    }
}