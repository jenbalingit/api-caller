using System;

namespace Grabhut.Data.Interface
{
    public interface IAudit
    {
        DateTime CreatedDate { get; set; }
        DateTime? LastUpdatedDate { get; set; }
        long CreatedBy { get; set; }
        long? LastUpdatedBy { get; set; }
    }
}
