using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PatientManager.Utilities
{
    public static class ViewUtils
    {
        public static IEnumerable<SelectListItem> GetGenderListItems()
        {
            return new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Male",
                    Value = Gender.Male.Id.ToString()
                },
                new SelectListItem
                {
                    Text = "Female",
                    Value = Gender.Female.Id.ToString()
                }
            };
        }

        public static IEnumerable<SelectListItem> GetPatientListItems(IRepository<Patient> repo)
        {
            return repo.GetAll().ToList().Select(p => new SelectListItem 
            {
                Text = p.FirstName + " " + p.LastName,
                Value = p.Id.ToString()
            });
        }

        public static IEnumerable<SelectListItem> GetExaminationTypeListItems() 
        {
            IEnumerable<ExaminationType> types = ExaminationType.GetAll();

            return types.ToList().Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.Id.ToString()
            });
        }
    }
}
