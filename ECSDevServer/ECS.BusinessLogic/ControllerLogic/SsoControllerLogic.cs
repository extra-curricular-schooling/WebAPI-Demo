using System;
using System.Collections.Generic;
using System.Text;
using ECS.BusinessLogic.ModelLogic.Contracts;
using ECS.BusinessLogic.ModelLogic.Implementations;

namespace ECS.BusinessLogic.ControllerLogic
{
    public class SsoControllerLogic
    {
        private AccountLogic _accountLogic;
        private PartialAccountLogic _partialAccountLogic;
        public SsoControllerLogic()
        {
            _accountLogic = new AccountLogic();
            _partialAccountLogic = new PartialAccountLogic();
        }
    }
}
