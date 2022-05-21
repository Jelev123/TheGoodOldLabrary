﻿namespace TheGoodOldLibrary.Data.Models.ViewModel.Periodical
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreatePeridiocalViewModel
    {
        public string Name { get; set; }

        [Display(Name = "Type")]

        public int TypeId { get; set; }

        public string Image { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TypeItems { get; set; }
    }
}