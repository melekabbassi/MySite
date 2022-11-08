﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySiteBL.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string? url { get; set; }
        public virtual List<Post>? Posts { get; set; }
    }
}
