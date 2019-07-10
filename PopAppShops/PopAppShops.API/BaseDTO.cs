using Grabhut.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grabhut.Data.EFBase
{
    public abstract class BaseDTO : IAudit
    {
        public long CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public long ID { get; set; }

        public long? LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedDate { get; set; }


    }
}
