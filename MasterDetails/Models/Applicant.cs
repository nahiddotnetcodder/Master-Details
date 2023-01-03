using System.ComponentModel.DataAnnotations;

namespace MasterDetails.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = "";
        [Required]
        [StringLength(100)]
        public string Gender { get; set; } = "";
        [Required]
        [Range(20,55, ErrorMessage ="Currently,we have no positions vacant for your age")]
        [Display(Name ="Age of Years")]
        public int Age { get; set; }

        [Required]
        [StringLength(50)]
        public string Qualification { get; set; } = "";

        [Required]
        [Range(1, 25, ErrorMessage = "Currently,we have no positions vacant for your Experience")]
        [Display(Name = "Total Exp. in Years")]
        public int TotalExperience { get; set; }

        public virtual List<Experience>  Experiences { get; set; }=new List<Experience>();
    }
}
