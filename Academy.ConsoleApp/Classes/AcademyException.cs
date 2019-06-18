using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Classes
{
    public class AcademyException : ArgumentException
    {
        public AcademyException(string message) : base(message)
        {
            // Cannot be assigned to since it is read-only.
            //Message = message;
        }

        public virtual DateTime ErrorDate
        {
            get
            {
                return DateTime.Now;
            }
        }

        public override string Message
        {
            get
            {
                return $"ACADEMY: {base.Message}";
            }
        }
    }
}
