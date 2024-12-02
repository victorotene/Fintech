using System.ComponentModel.DataAnnotations;

namespace Fintech.Domain.Entities;


    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
