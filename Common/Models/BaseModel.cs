using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Primary : Attribute {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : Attribute
    {

    }
    public class BaseModel
    {
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
