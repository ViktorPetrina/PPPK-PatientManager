using System.Text;
using System;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PatientManager.Utilities
{
    public static class ExportUtils
    {
        public static string PatientToCsv(Patient patient)
        {
            var csv = new StringBuilder();

            csv.AppendLine("Patient Details");
            csv.AppendLine("Id,FirstName,LastName,Sex,DateOfBirth,Oib");
            csv.AppendLine($"{patient.Id},{patient.FirstName},{patient.LastName},{patient.Sex?.Sex}," +
                $"{patient.DateOfBirth.ToShortDateString()},{patient.Oib}");
            csv.AppendLine();

            csv.AppendLine("Examinations");
            csv.AppendLine("Id,Date,Type");
            foreach (var exam in patient.Examinations ?? Enumerable.Empty<Examination>())
            {
                csv.AppendLine($"{exam.Id},{exam.Date},{exam.Type?.Name}");
            }
            csv.AppendLine();

            csv.AppendLine("Medical History");
            csv.AppendLine("Id,Name,Start,End");
            foreach (var diagnosis in patient.MedicalHistory ?? Enumerable.Empty<Diagnosis>())
            {
                csv.AppendLine($"{diagnosis.Id},{diagnosis.Name},{diagnosis.Start},{diagnosis.End}");
            }

            return csv.ToString();
        }
    }
}
