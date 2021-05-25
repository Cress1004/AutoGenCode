using AutoGenCode.Data;
using AutoGenCode.Models;
using AutoGenCode.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGenCode.Repository
{
    public class GenUIRepository
    {
        private readonly TagContext _context = null;
        public GenUIRepository(TagContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewUI(GenUIModel model)
        {
            var newUI = new GenUI()
            {
                Width = model.Width,
                Height = model.Height,
                CreatedAt = DateTime.UtcNow,
                Tags = model.Tags,
                Regions = model.Regions,
            };

            await _context.GenUIs.AddAsync(newUI);
            await _context.SaveChangesAsync();

            return newUI.GenUIId;
        }

        public async Task<GenUIModel> GetUIById(int id)
        {
            return await _context.GenUIs.Where(x => x.GenUIId == id).Select(genUI => new GenUIModel()
            {
                Width = genUI.Width,
                Height = genUI.Height,
                Tags = genUI.Tags.ToList(),
                Regions = genUI.Regions.ToList(),
            }).FirstOrDefaultAsync();
        }

        public async Task<List<GenUIModel>> GetUIs()
        {
            return await _context.GenUIs.Select(x => new GenUIModel()
            {
                 Id = x.GenUIId,
                 Width = x.Width,
                 Regions = x.Regions.ToList(),
                 Tags = x.Tags.ToList(),
                 CreatedAt = x.CreatedAt,
            }).ToListAsync();
        }
    }
}
