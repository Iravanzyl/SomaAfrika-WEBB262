using SomaAfrica.Data.Interfaces;
using SomaAfrica.Models;

namespace SomaAfrica.Data.Services
{
    public class WantedAdService
    {
        private readonly IWantedadRespository _wantedAdRepository;

        public WantedAdService(IWantedadRespository wantedAdRepository)
        {
            _wantedAdRepository = wantedAdRepository;
        }

        public async Task<WantedAd> AddWantedAdAsync(WantedAd wantedAd)
        {
            return await _wantedAdRepository.AddWantedAdAsync(wantedAd);
        }

        public async Task<bool> DeleteWantedAdAsync(int id)
        {
            return await _wantedAdRepository.DeleteWantedAdAsync(id);
        }

        public async Task<WantedAd> GetWantedAdByIdAsync(int id)
        {
            return await _wantedAdRepository.GetWantedAdByIdAsync(id);
        }

        public async Task<WantedAd> UpdateWantedAdAsync(WantedAd wantedAd)
        {
            return await _wantedAdRepository.UpdateWantedAdAsync(wantedAd);
        }
    }
}