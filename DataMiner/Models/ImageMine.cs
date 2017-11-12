using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataMiner.Models
{
    public class ImageMine
    {
        public string Message { get; set; }
        public MessageType MessageType { get; set; }

        public static List<SelectListItem> GetSelection()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem() {Text="Item", Value="1"},
                new SelectListItem() { Text="Map", Value="2"},

            };
        }
    }

    public enum MessageType
    {
        Success,
        Error
    }

    

} 