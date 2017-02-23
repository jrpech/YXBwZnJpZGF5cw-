using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class Person
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
    }
}