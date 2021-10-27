using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using Projeto_Inventáro.Hypermedia.Abstract;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Hypermedia
{
    public abstract class ContentResponseEnricher<T> : IResponseEnricher where T : ISupportHyperMedia
    {
        public bool CanEnrich(Type type)
        {

            return type == typeof(T) || type == typeof(List<T>);

        }

        protected abstract Task ErinchModel(T context, IUrlHelper urlHelper);

        bool IResponseEnricher.CanEnrich(ResultExecutingContext response)
        {
            if (response.Result is OkObjectResult objectResult)
            {
                return CanEnrich(objectResult.Value.GetType());
            }
            return false;
        }


        public async Task Enrich(ResultExecutingContext response)
        {

            var urlHelper = new UrlHelperFactory().GetUrlHelper(response);


            if (response.Result is OkObjectResult objectResult)
            {

                if (objectResult.Value is T model)
                {

                    await ErinchModel(model, urlHelper);
                
                }else if (objectResult.Value is List<T> collection)
                {


                    ConcurrentBag<T> bag = new ConcurrentBag<T>(collection);

                    Parallel.ForEach(bag, (element) =>
                    {

                        ErinchModel(element, urlHelper);

                     });

                }

            }
            await Task.FromResult<object>(null);
        }
    }
}
