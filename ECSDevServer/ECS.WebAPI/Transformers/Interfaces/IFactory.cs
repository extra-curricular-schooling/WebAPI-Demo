using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.WebAPI.Transformers.Interfaces
{
    interface IFactory
    {
        Object Create(string roleType);
    }
}
