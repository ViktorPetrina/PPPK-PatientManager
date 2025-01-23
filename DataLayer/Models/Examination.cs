﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DataLayer.Models
{
    public class Examination
    {
        [Column("id_examination")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("patient_id")]
        public Patient? Patient { get; set; }

        [Column("date")]
        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("ExaminationType")]
        [Column("type_id")]
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
