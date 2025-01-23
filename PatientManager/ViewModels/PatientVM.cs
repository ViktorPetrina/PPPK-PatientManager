using DataLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace PatientManager.ViewModels
{
    public class PatientVM
    {
        public long Id { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessage = "Patient must have a first name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Patient must have a last name")]
        public string? LastName { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public long SexId { get; set; }

        public Gender? Sex { get; set; }

        [Display(Name = "Date of birth")]
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "OIB is required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "OIB must be exactly 11 characters long.")]
        public string? Oib { get; set; }

        public IEnumerable<Examination>? Examinations { get; set; }

        public IEnumerable<Diagnosis>? MedicalHistory { get; set; }
    }
}
