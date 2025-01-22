using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace DataLayer.Models
{
    public class Patient
    {
        [Column("id_patient")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("first_name")]
        public string? FirstName { get; set; }

        [Column("last_name")]
        public string? LastName { get; set; }

        [ForeignKey("sex_id")]
        public long SexId { get; set; }

        public Gender? Sex { get; set; }

        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [Column("oib")]
        [StringLength(11)]
        public string? Oib { get; set; }

        public IEnumerable<Examination>? Examinations { get; set; }

        public IEnumerable<Diagnosis>? MedicalHistory { get; set; }
    }

    public class Gender
    {
        [Column("id")]
        [Key]
        public long Id { get; set; }

        [Column("sex")]
        public char Sex { get; private set; }

        private Gender(long id, char sex)
        {
            Id = id;
            Sex = sex;
        }

        public Gender() { }

        public static readonly Gender Male = new Gender(1, 'M');
        public static readonly Gender Female = new Gender(2, 'F');
    }
}
