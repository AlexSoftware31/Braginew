using System;
using System.ComponentModel.DataAnnotations;

namespace Bragi.DataLayer.Models.Core
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        [StringLength(100)]
        public string ModificatedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsDeleted { get; set; }

        public BaseModel()
        {
            CreationDate = DateTime.Now;
            IsDeleted = false;
        }
    }
}
