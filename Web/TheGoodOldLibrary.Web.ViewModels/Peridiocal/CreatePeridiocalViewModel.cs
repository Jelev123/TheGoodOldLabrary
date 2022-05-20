namespace TheGoodOldLibrary.Web.ViewModels.Peridiocal
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    public class CreatePeridiocalViewModel
    {
        public string Name { get; set; }

        [Display(Name = "Type")]

        public int TypeId { get; set; }

        public IEnumerable<IFormFile> Image { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GenreItems { get; set; }


    }
}
