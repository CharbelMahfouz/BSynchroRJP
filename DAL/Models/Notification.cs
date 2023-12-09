using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    [Table("Notification")]
    public partial class Notification
    {
        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }
        [StringLength(450)]
        public string InitiatorId { get; set; }
        public int? EventId { get; set; }
        public int? BusinessId { get; set; }
        public int? PostId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int? ReviewId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [InverseProperty("NotificationUsers")]
        public virtual AspNetUser User { get; set; }
    }
}
