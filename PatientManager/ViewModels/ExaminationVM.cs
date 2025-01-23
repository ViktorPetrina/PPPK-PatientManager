using DataLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PatientManager.ViewModels
{
    public class ExaminationVM
    {        
        public long Id { get; set; }

        public long PatientId { get; set; }

        public Patient? Patient { get; set; }

        public DateTime Date { get; set; }

        public ExaminationType? Type { get; set; }

        public byte[]? Image { get; set; }
    }
}
