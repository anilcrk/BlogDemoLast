using DemoFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.Entities.Concrete
{
    public class Blog:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }
        public int UserId { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime EditDate { get; set; }
    }
}
