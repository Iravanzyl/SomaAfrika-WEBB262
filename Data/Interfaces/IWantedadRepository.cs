using SomaAfrica.Models;

namespace SomaAfrica.Data.Interfaces
{
    public interface IWantedadRespository
    {
        Task<WantedAd> GetWantedAdByIdAsync(int id);
        Task<WantedAd> AddWantedAdAsync(WantedAd wantedAd);
        Task<WantedAd> UpdateWantedAdAsync(WantedAd wantedAd);
        Task<bool> DeleteWantedAdAsync(int id);
    }
}
