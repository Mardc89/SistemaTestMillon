﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistTestMillon.Models
{
    public class Response2
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
        public int Id { get; set; }
    }
}