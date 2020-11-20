using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pathfinding_API.Controllers
{
    public class NodeManagementController : ApiController
    {
        private Pathfinding_API.Models.AStarPathfinder db = new Models.AStarPathfinder();

        [Route("SetNode")]
        [HttpPost]
        public IHttpActionResult SetNode(int nodeId, string nodeState)
        {
            Models.NodeData data = db.NodeData.Find(nodeId);

            if (data == null)
                data = new Models.NodeData();

            data.NODE_ID = nodeId;
            data.NODE_TYPE = nodeState;

            db.Entry(data).State = System.Data.Entity.EntityState.Modified;
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