using Microsoft.Extensions.Caching.Memory;
using ProgramApp.Domain.Entities;
using ProgramApp.Domain.Interfaces;

namespace ProgramApp.Persistence.Repositories.CachedRepositories
{
    public class CachedApplicationResponseRespository : IApplicationResponseRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IApplicationResponseRepository _repo;

        private const string AllResponseCacheKey = "AllApplicationResponses";
        private const string ResponseCacheKeyPrefix = "ApplicationResponse_";

        public CachedApplicationResponseRespository(IApplicationResponseRepository repo, IMemoryCache cache)
        {
            _memoryCache = cache;
            _repo = repo;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _repo.SaveChangesAsync();
        }

        public async Task<ApplicationResponse> Create(ApplicationResponse entity)
        {
            var res = await _repo.Create(entity);
            _memoryCache.Remove(AllResponseCacheKey);
            return res;
        }

        public async Task<ApplicationResponse> Update(Guid Id, ApplicationResponse entity)
        {
            var res = await _repo.Update(Id, entity);
            _memoryCache.Remove(AllResponseCacheKey);
            return res;
        }
        public async Task<bool> Delete(Guid Id)
        {
            return await _repo.Delete(Id);
        }

        public async Task<ApplicationResponse?> GetById(Guid Id)
        {
            string cacheKey = $"{ResponseCacheKeyPrefix}{Id}";

            return await _memoryCache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                return await _repo.GetById(Id);
            });
        }

        public async Task<IEnumerable<ApplicationResponse>?> GetAll()
        {
            return await _memoryCache.GetOrCreateAsync(AllResponseCacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                return await _repo.GetAll();
            });
        }
    }
}
