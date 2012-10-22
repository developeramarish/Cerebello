﻿using System.Net.Mail;

namespace CerebelloWebRole.Models
{
    public class EmailViewModel
    {
        public string PersonName { get; set; }

        public string UserName { get; set; }

        public string Token { get; set; }

        public string PracticeUrlIdentifier { get; set; }

        public bool IsBodyHtml { get; set; }
    }
}