using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pathfinding_API.Controllers
{
    public class NodeManagementController : ApiController
    {
        private Pathfinding_API.Models.AStarPathfinderContext db = new Models.AStarPathfinderContext();

        [Route("SetNode")]
        [HttpPost]
        public IHttpActionResult SetNode(int nodeId, string nodeState)
        {
            Models.NodeData[] dbData = db.NodeData.Where(x => x.NODE_ID == nodeId).ToArray();

            System.Data.Entity.EntityState state;
            Models.NodeData data;

            if (dbData.Length == 0)
            {
                data = new Models.NodeData();
                state = System.Data.Entity.EntityState.Added;
            }
            else
            {
                data = dbData[0];
                state = System.Data.Entity.EntityState.Modified;
            }

            data.NODE_ID = nodeId;
            data.NODE_TYPE = nodeState;

            db.Entry(data).State =state;
            db.SaveChanges();

            return Ok($"{nodeId} set as {nodeState}");
        }

        [Route("Testnode")]
        public IHttpActionResult Test()
        {
            return Ok("What the fuck");
        }
    }
}