using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pathfinding_API.Models
{

    [Table("NodeData")]
    public class NodeData
    {

        [Key]
        public int KEY_ID { get; set; }
        public int NODE_ID { get; set; }
        public string NODE_TYPE { get; set; }
    }
}