using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECS.DTO
{
    public class AccountQuestionsDTO
    {
        public List<string> SecurityQuestions { get; set; }

        public List<string> SecurityAnswers { get; set; }
    }
}