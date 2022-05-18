﻿namespace TheGoodOldLibrary.Data.Models
{
    using System;
    using TheGoodOldLibrary.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = new Guid().ToString();
        }

        public int BookId { get; set; }

        public Book Books { get; set; }

        public int PeriodicalId { get; set; }

        public Periodical Periodical { get; set; }

        public string Extension { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

    }
}