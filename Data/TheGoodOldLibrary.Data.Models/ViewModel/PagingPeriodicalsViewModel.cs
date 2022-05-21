﻿namespace TheGoodOldLibrary.Data.Models.ViewModel
{
    using System;

    public class PagingPeriodicalsViewModel
    {
        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public int PreviousPageNumber => this.PageNumber - 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int NextPageNumber => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.PeriodicalsCount / this.ItemsPerPage);

        public int PeriodicalsCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}
