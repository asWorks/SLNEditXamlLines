﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditXamlLines.EventMessages
{
    public class EventMessage
    {
        /// <summary>
        /// Test
        /// </summary>
        public string Message { get; set; }
        public EventMessage(string message)
        {
            Message = message;
        }
    }
}
