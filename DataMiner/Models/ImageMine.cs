using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataMiner.Models
{
    public class ImageMine
    {
        public string Message { get; set; }
        public MessageType MessageType { get; set; }
    }

    public enum MessageType
    {
        Success,
        Error
    }

} 