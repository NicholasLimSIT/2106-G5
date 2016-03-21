
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

namespace ParkWhere.Models
{
    public partial class Bookmark
    {
        [Display(Name = "Bookmark ID")]
        public int BookmarkId { get; set; }

        [Display(Name = "Carpark ID")]
        public Nullable<int> carparkId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Bookmark Date")]
        public DateTime date { get; set; }

        [Display(Name = "Username")]
        public string username { get; set; }
    
        public virtual Carpark Carpark { get; set; }
    }
}
