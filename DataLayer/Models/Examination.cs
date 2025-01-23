using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Reflection;

namespace DataLayer.Models
{
    public class Examination
    {
        [Column("id_examination")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("Patient")]
        [Column("patient_id")]
        [Display(Name = "Patient")]
        public long PatientId { get; set; }

        public Patient? Patient { get; set; }

        [Column("date")]
        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("ExaminationType")]
        [Column("type_id")]
        public long TypeId { get; set; }

        public ExaminationType? Type { get; set; }

        public byte[]? Image { get; set; }
    }

    public class ExaminationType
    {
        [Column("id_examination_type")]
        [Key]
        public long? Id { get; set; }

        [Column("name")]
        public string? Name { get; private set; }

        [Column("code")]
        public string? Code { get; private set; }

        private ExaminationType(long id, string? name, string? code)
        {
            Id = id;
            Name = name;
            Code = code;
        }

        public ExaminationType() { }

        public static IEnumerable<ExaminationType> GetAll()
        {
#pragma warning disable CS8619
#pragma warning disable CS8600 
            return typeof(ExaminationType)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(ExaminationType))
                .Select(f => (ExaminationType)f.GetValue(null));
#pragma warning restore CS8600 
#pragma warning restore CS8619
        }

        public static readonly ExaminationType GP = new ExaminationType(1, "General physical exam", "GP");
        public static readonly ExaminationType KRV = new ExaminationType(2, "Blood test", "KRV");
        public static readonly ExaminationType XRAY = new ExaminationType(3, "X-ray scan", "X-RAY");
        public static readonly ExaminationType CT = new ExaminationType(4, "CT scan", "CT");
        public static readonly ExaminationType MR = new ExaminationType(5, "MRI scan", "MR");
        public static readonly ExaminationType ULTRA = new ExaminationType(6, "Ultrasound", "ULTRA");
        public static readonly ExaminationType ECG = new ExaminationType(7, "Electrocardiogram", "EKG");
        public static readonly ExaminationType ECHO = new ExaminationType(8, "Echocardiogram", "ECHO");
        public static readonly ExaminationType EYE = new ExaminationType(9, "Eye exam", "EYE");
        public static readonly ExaminationType DERM = new ExaminationType(10, "Dermatology exam", "DERM");
        public static readonly ExaminationType DENTA = new ExaminationType(11, "Dental exam", "DENTA");
        public static readonly ExaminationType MAMMO = new ExaminationType(12, "Mammogram", "MAMMO");
        public static readonly ExaminationType NEURO = new ExaminationType(13, "Neurology exam", "NEURO");
    }
}
