using DataLayer.Models;
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

        public static IEnumerable<SelectListItem> GetExaminationTypeListItems() 
        {
            throw new NotImplementedException();
        }
    }
}
