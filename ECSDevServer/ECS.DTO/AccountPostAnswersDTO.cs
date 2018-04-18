using System.Collections.Generic;

namespace ECS.DTO
{
    public class AccountPostAnswersDTO
    {
        public string Username { get; set; }

        public List<SecurityQuestionDTO> SecurityQuestions { get; set; }
    }
}
