using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.WebAPI.Services.Transformers.Interfaces
{
    interface ITransformer<T> where T : class
    {
        T Fetch(T content);
        T Send(T content);
    }
}
