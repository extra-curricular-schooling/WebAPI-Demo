using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.WebAPI.Transformers.Interfaces
{
    /// <summary>
    /// Standard Factory Interface
    /// </summary>
    public interface IFactory
    {
        object Create(object type);
    }
}
