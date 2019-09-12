using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBSP.Models
{
    
    public class RightNodeModel
    {
        public int id { get; set; }
        public int pId { get; set; }
        public string iconOpen { get; set; }
        public string iconClose { get; set; }
        /// <summary>
        /// 展开
        /// </summary>
        public bool open { get; set; }
        /// <summary>
        /// 没有子节点
        /// </summary>
        public bool isParent { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string name { get; set; }

        public string icon { get; set; }

        public string menuUrl { get; set; }
        public string menuIcon { get; set; }
}
        

}