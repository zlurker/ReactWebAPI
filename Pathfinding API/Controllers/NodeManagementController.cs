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
            System.Data.Entity.EntityState state;
            Models.NodeData data = db.NodeData.Where(x => x.NODE_ID == nodeId).FirstOrDefault();

            if (data == null)
            {
                data = new Models.NodeData();
                state = System.Data.Entity.EntityState.Added;
            }
            else
            {
                state = System.Data.Entity.EntityState.Modified;
            }

            data.NODE_ID = nodeId;
            data.NODE_TYPE = nodeState;

            db.Entry(data).State =state;
            db.SaveChanges();

            return Ok($"{nodeId} set as {nodeState}");
        }

        [Route("RemoveNode")]
        public IHttpActionResult RemoveNode(int nodeId)
        {
            Models.NodeData data = db.NodeData.Where(x => x.NODE_ID == nodeId).FirstOrDefault();

            if (data != null)
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return Ok($"deleted {nodeId}");
            }

            return Ok($"{nodeId} does not exist");
        }
        
        [Route("RemoveAllNodes")]
        public IHttpActionResult RemoveAllNodes()
        {
            db.NodeData.RemoveRange(db.NodeData);
            db.SaveChanges();

            return Ok("All data deleted.");
        }


        [Route("Testnode")]
        public IHttpActionResult Test()
        {
            return Ok("What the fuck");
        }
    }
}