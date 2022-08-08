using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diff.WebUI.AppCode.Infrastructure
{
    public class BaseEntity : HistoryEntity
    {
        public int Id { get; set; }
    }

    public class HistoryEntity
    {
        public int? CreatedById { get; set; }

        //[Column(TypeName= "smalldatetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(4);
        public int? DeletedById { get; set; }
        public DateTime? DeletedDate { get; set; }
    }

}
