using Diff.WebUI.AppCode.Infrastructure;
using System;

namespace Diff.WebUI.Models.Entities
{
    public class Subscribe : BaseEntity
    {
        public string Email { get; set; }
        public bool EmailIsSent { get; set; } = false;
        public DateTime? AppliedDate { get; set; }
    }
}
