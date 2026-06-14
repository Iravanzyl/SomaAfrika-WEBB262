using Microsoft.EntityFrameworkCore;
using SomaAfrica.Data.Interfaces;
using SomaAfrica.Models;

namespace SomaAfrica.Data.Repositories
{
    public class WantedadRepository : IWantedadRespository
    {
        private readonly ApplicationDbContext _context;

        public WantedadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WantedAd> GetWantedAdByIdAsync(int id)
        {
            return await _context.WantedAds.FindAsync(id);
        }

        public async Task<WantedAd> AddWantedAdAsync(WantedAd wantedAd)
        {
            _context.WantedAds.Add(wantedAd);
            await _context.SaveChangesAsync();
            return wantedAd;
        }

        public async Task<WantedAd> UpdateWantedAdAsync(WantedAd wantedAd)
        {
            _context.WantedAds.Update(wantedAd);
            await _context.SaveChangesAsync();
            return wantedAd;
        }

        public async Task<bool> DeleteWantedAdAsync(int id)
        {
            var wantedAd = await _context.WantedAds.FindAsync(id);
            if (wantedAd == null)
            {
                return false;
            }

            _context.WantedAds.Remove(wantedAd);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}