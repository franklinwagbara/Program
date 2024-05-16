using Microsoft.Extensions.Caching.Memory;
using ProgramApp.Domain.Entities;
using ProgramApp.Domain.Interfaces;

namespace ProgramApp.Persistence.Repositories.CachedRepositories
{
    public class CachedApplicationFormRespository : IApplicationFormRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IApplicationFormRepository _repo;

        private const string AllFormsCacheKey = "AllApplicationForms";
        private const string FormCacheKeyPrefix = "ApplicationForm_";

        public CachedApplicationFormRespository(IApplicationFormRepository repo, IMemoryCache cache)
        {
            _memoryCache = cache;
            _repo = repo;
        }

        public async Task<ApplicationForm> Create(ApplicationForm entity)
        {
            var res = await _repo.Create(entity);
            _memoryCache.Remove(AllFormsCacheKey);
            return res;
        }

        public async Task<ApplicationForm> Update(Guid Id, ApplicationForm entity)
        {
            var res = await _repo.Update(Id, entity);
            _memoryCache.Remove(AllFormsCacheKey);
            return res;
        }

        public async Task<bool> Delete(Guid Id)
        {
            return await _repo.Delete(Id);
        }

        public async Task<ApplicationForm?> GetById(Guid Id)
        {
            string cacheKey = $"{FormCacheKeyPrefix}{Id}";

            return await _memoryCache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                return await _repo.GetById(Id);
            });
        }

        public async Task<IEnumerable<ApplicationForm>?> GetAll()
        {
            return await _memoryCache.GetOrCreateAsync(AllFormsCacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                return await _repo.GetAll();
            });
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _repo.SaveChangesAsync();
        }
    }
}
