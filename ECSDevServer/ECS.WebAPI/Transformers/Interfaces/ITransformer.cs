using System;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace ECS.WebAPI.Transformers.Interfaces
{
    interface ITransformer
    {
        Object Fetch(HttpRequestContext context);
        HttpResponseMessage Send(Object dto);
    }
}
