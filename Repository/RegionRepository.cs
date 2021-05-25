using AutoGenCode.Data;
using AutoGenCode.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGenCode.Repository
{
    public class RegionRepository
    {
        private readonly TagContext _context = null;
        private readonly TagRepository _tagRepository = null;
        public RegionRepository(TagContext context, TagRepository tagRepository)
        {
            _context = context;
            _tagRepository = tagRepository;
        }

        public async Task<int> AddNewRegion(RegionModel model)
        {
            var newRegion = new Region()
            {
                Width = model.Width,
                Height = model.Height,
                LeftPos = model.LeftPos,
                RightPos = model.RightPos,
                CreatedAt = DateTime.UtcNow,
                TagId = model.TagId,
                GenUI = model.GenUI,
            };
            await _context.Regions.AddAsync(newRegion);
            await _context.SaveChangesAsync();
            return newRegion.RegionId;
        }

        public async Task<RegionModel> GetRegionById(int id)
        {
            return await _context.Regions.Where(x => x.RegionId == id).Select(region => new RegionModel()
            {
                Width = region.Width,
                Height = region.Height,
                LeftPos = region.LeftPos,
                RightPos = region.RightPos,
                CreatedAt = DateTime.UtcNow,
                Tag = region.Tag,
                GenUI = region.GenUI,
            }).FirstOrDefaultAsync();
        }
    }
}
