namespace TheGoodOldLibrary.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using TheGoodOldLibrary.Data.Common.Repositories;
    using TheGoodOldLibrary.Data.Models;

    public class SettingsService
    {
        private readonly IDeletableEntityRepository<Setting> settingsRepository;

        public SettingsService(IDeletableEntityRepository<Setting> settingsRepository)
        {
            this.settingsRepository = settingsRepository;
        }

        public int GetCount()
        {
            return this.settingsRepository.AllAsNoTracking().Count();
        }
    }
}
