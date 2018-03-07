using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECS.DTO
{
    public class SsoRegistrationDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool FirstTimeUser { get; set; }

        public List<SecurityQuestionDTO> SecurityQuestions { get; set; }
    }
}