using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3WebAPI.Models;
using Assignment3WebAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Assignment3WebAPI.Data
{
    public class SqliteAdultsService : IAdultService
    {

        private AdultDbContext ctx;

        public SqliteAdultsService(AdultDbContext ctx) {
            this.ctx = ctx;
        }

        public async Task<IList<Adult>> GetAdultsAsync() {
            return await ctx.Adults.ToListAsync();
        }

        public async Task<Adult> AddAdultAsync(Adult adult) {
            EntityEntry<Adult> newlyAdded = await ctx.Adults.AddAsync(adult);
            await ctx.SaveChangesAsync();
            
            return newlyAdded.Entity;
        } 

        public async Task RemoveAdultAsync(int adultId) {
            Adult toDelete = ctx.Adults.FirstOrDefault(t => t.Id == adultId);

            if (toDelete != null) {
                ctx.Adults.Remove(toDelete);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task<Adult> UpdateAdultAsync(Adult adult) {
            try {
                Adult toUpdate = await ctx.Adults.FirstAsync(t => t.Id == adult.Id);
                ctx.Update(toUpdate);
                await ctx.SaveChangesAsync();

                return toUpdate;
            }
            catch (Exception e) {
                throw new Exception($"Did not find adult with given id: {adult.Id}");
            }
        }
    }
}