using System;

namespace ECS.WebAPI.Transformers.Interfaces
{
    /// <summary>
    /// Standard Content Transformer.
    /// </summary>
    public interface ITransformer
    {
        Object Fetch(Object context);
        Object Send(Object dto);
    }
}
