using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Diagnosis
    {
        [Column("id_diagnosis")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("start")]
        [Display(Name = "Beggining")]
        public DateOnly Start { get; set; }

        [Column("end")]
        public DateOnly? End { get; set; }

        [ForeignKey("Patient")]
        [Column("patient_id")]
        public long PatientId { get; set; }

        public Patient? Patient { get; set; }
    }
}
