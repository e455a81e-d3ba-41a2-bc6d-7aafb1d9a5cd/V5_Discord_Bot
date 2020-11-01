using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V5_Discord_Bot.Exceptions
{
    public class BotTokenException : Exception
    {
        public BotTokenException() : base()
        {
        }

        public BotTokenException(string? message) : base(message)
        {
        }

        public BotTokenException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
