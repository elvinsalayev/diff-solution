using Diff.WebUI.AppCode.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace Diff.WebUI.Models.Entities
{
    public class ContactPost : BaseEntity
    {
        [Required(ErrorMessage = "Boş buraxmaq olmaz")]
        public string Message { get; set; }


        [Required(ErrorMessage = "Boş buraxmaq olmaz")]
        public string FullName { get; set; }


        [EmailAddress(ErrorMessage = "E-mail düzgün daxil edilməyib")]
        [Required(ErrorMessage = "Boş buraxmaq olmaz")]
        public string Email { get; set; }

        public DateTime? AnswerDate { get; set; }
        public string Answer { get; set; }
        public int? AnsweredById { get; set; }
    }
}
