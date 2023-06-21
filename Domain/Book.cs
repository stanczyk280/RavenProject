﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BookQuantity
    {
        public uint Quantity { get; set; }
        public uint Borrowed { get; set; }

        public uint Available { get => Quantity - Borrowed; }
    }

    public class Book
    {
        public BookQuantity BookQuantity { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateOnly? Published { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}