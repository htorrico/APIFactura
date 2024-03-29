﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    /// Catch NotFound Exception into WebServices
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class WSNotFoundException : Exception
    {
        public WSNotFoundException()
        {
        }

        public WSNotFoundException(string message)
            : base(message)
        {
        }

        public WSNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
