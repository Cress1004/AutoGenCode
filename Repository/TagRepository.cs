using AutoGenCode.Data;
using AutoGenCode.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGenCode.Repository
{
    public class TagRepository
    {
        private readonly TagContext _context = null;
        public TagRepository(TagContext context)
        {
            _context = context;
        }

        public async Task<List<TagModel>> GetTags()
        {
            return await _context.Tags.Select(x => new TagModel()
            {
                TagId = x.TagId,
                TagName = x.TagName,
                HasEndTag = x.HasEndTag,
            }).ToListAsync();
        }

        public async Task<int> AddNewTag(TagModel model)
        {
            var newTag = new Tag()
            {
                TagName = model.TagName,
                HasEndTag = model.HasEndTag,
                CreatedAt = DateTime.UtcNow,
            };

            await _context.Tags.AddAsync(newTag);
            await _context.SaveChangesAsync();
           
            return newTag.TagId;
        }

        public async Task<TagModel> GetTagById(int id)
        {
            return await _context.Tags.Where(x => x.TagId == id).Select(tag => new TagModel()
            {
                TagName = tag.TagName,
                HasEndTag = tag.HasEndTag,
            }).FirstOrDefaultAsync();
        }

    }
}
