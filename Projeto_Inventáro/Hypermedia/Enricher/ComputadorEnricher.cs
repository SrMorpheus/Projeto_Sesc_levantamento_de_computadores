using Microsoft.AspNetCore.Mvc;
using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Hypermedia.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Hypermedia.Enricher
{
    public class ComputadorEnricher : ContentResponseEnricher<ComputadorVO>
    {

        private readonly object _lock = new object();

        protected override Task ErinchModel(ComputadorVO context, IUrlHelper urlHelper)
        {

            var path = "api/v1/Computador";

            string link = getLink(context.IdComputador, urlHelper, path);

            context.Links.Add(new HyperMediaLink()

            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet


            } );

            context.Links.Add(new HyperMediaLink()

            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost


            });
            context.Links.Add(new HyperMediaLink()

            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPut


            });

            context.Links.Add(new HyperMediaLink()

            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.self,
                Type = "int"


            });

            return null;



        }

        private string getLink(int idComputador, IUrlHelper urlHelper, string path)
        {

            lock (_lock)
            {
                var url = new { Controller = path, id = idComputador };

                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            };

        }
    }
}
