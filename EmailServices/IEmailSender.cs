﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServices
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
