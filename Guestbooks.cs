using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Guestbooks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public string Reply { get; set; }
        public DateTime? ReplyTime { get; set; }
    }
}