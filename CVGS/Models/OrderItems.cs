﻿using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class OrderItems
    {
        public string OrderId { get; set; }
        public Guid GameId { get; set; }
        public int Quantity { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual Game Game { get; set; }
        public virtual Orders Order { get; set; }
    }
}
