using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Hypermedia.Filters
{
    public class HypeMediaFilter : ResultFilterAttribute
    {


        private readonly HypeMediaFilterOptions _hypeMediaFilterOptions;



        public HypeMediaFilter (HypeMediaFilterOptions hypeMediaFilterOptions)
        {

            _hypeMediaFilterOptions = hypeMediaFilterOptions;

        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            TryEnrichResult(context);

            base.OnResultExecuting(context);
        }

        private void TryEnrichResult(ResultExecutingContext context)
        {
            if (context.Result is OkObjectResult objectResult)
            {
                var enricher = _hypeMediaFilterOptions.ResponseEnrichers.FirstOrDefault(x => x.CanEnrich(context));

                if (enricher != null) Task.FromResult(enricher.Enrich(context));


            };

        }
    }
}
