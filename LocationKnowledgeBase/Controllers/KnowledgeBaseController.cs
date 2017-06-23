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
        /// <summary>
        /// Retrieve a content item from the knowledge database.
        /// </summary>
        /// <param name="requestData">Data to filter the request by.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("item")]
        public KnowledgeModel GetItem([FromUri]KnowledgeItemRequestDataModel requestData)
        {
            var entities = new LocationKnowledgeBaseEntities();
            var intId = 0;
            var rssi = requestData.RSSI;

            try
            {
                intId = Convert.ToInt32(requestData.Id);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.InnerException);
            }

            return entities.contents
                .Where(content => (content.id == intId || content.mac == requestData.Id) && rssi >= content.rssi)
                .Select(content => new KnowledgeModel
                {
                    Id = content.id,
                    Title = content.title,
                    Body = content.body,
                    MacAddress = content.mac,
                    RSSI = content.rssi,
                    URL = content.url
                })
                .FirstOrDefault();
        }

        /// <summary>
        /// Retrieve the list of valid MAC addresses.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("addresses")]
        public List<string> GetValidAddresses()
        {
            var entities = new LocationKnowledgeBaseEntities();

            return entities.contents
                .Where(content => content.mac != null)
                .Select(content => content.mac)
                .ToList();
        }
    }
}
