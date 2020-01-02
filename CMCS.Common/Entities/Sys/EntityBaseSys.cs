using CMCS.DapperDber.Attrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Common.Entities.Sys
{
    [Serializable]
    public class EntityBaseSys
    {
        public EntityBaseSys()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreationTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            this.CreatorUserId = 1;
            this.LastModifiCationTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            this.LastModifierUserId = 1;
        }

        [DapperPrimaryKey]
        public string Id { get; set; }
        public DateTime CreationTime { get; set; }
        public int CreatorUserId { get; set; }
        public DateTime LastModifiCationTime { get; set; }
        public int LastModifierUserId { get; set; }
    }
}
