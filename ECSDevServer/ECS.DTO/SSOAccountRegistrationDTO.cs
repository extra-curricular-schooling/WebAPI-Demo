using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECS.DTO
{
    public class SSOAccountRegistrationDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool FirstTimeUser { get; set; }

        public List<AccountQuestionDTO> SecurityQuestions { get; set; }
    }
}