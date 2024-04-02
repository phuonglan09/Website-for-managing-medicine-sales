using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doctors.Base.Models
{
    public partial class BlogDetail
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Shortcontent { get; set; }
        public string? Cardimg { get; set; }
        public bool Hideblog { get; set; }
        public int BlogTypeId { get; set; }
        public DateTime? DateUp { get; set; }
        public string? Contentblog { get; set; }
        [NotMapped]
        public string Namebt { get; set; }
        [NotMapped]
        public int TotalRow { get; set; }
    }
}
