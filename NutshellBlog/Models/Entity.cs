using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutshellBlog.Models
{
    public abstract class Entity
    {
        public virtual int Id { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
