using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using LocationKnowledgeBase.Models;

namespace LocationKnowledgeBase.Controllers
{
    [RoutePrefix("api/knowledge")]
    public class KnowledgeBaseController : ApiController
    {
        [HttpGet]
        [Route("item/{id}")]
        public KnowledgeModel GetItem(String id)
        {
            var entities = new LocationKnowledgeBaseEntities();
            var intId = Convert.ToInt32(id);

            return entities.contents
                .Where(content => content.id == intId || content.mac == id)
                .Select(content => new KnowledgeModel
                {
                    Id = content.id,
                    Title = content.title,
                    Body = content.body,
                    MacAddress = content.mac
                })
                .FirstOrDefault();
        }
    }
}
