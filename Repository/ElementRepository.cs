using AutoGenCode.Data;
using AutoGenCode.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGenCode.Repository
{
    public class ElementRepository
    {
        private readonly TagContext _context = null;
        public ElementRepository(TagContext context)
        {
            _context = context;
        }

        public async Task<List<ElementModel>> GetElements()
        {
            return await _context.Tags.Select(x => new ElementModel()
            {
                Id = x.Id,
                TagName = x.TagName,
              /*  IsContent = x.IsContent,
                Content = x.Content,*/
            }).ToListAsync();
        }

        public async Task<int> AddNewElement(ElementModel model)
        {
            var newElement = new Tags()
            {
                TagName = model.TagName,
               /* IsContent = model.IsContent,
                Content = model.Content,*/
            };

            await _context.Tags.AddAsync(newElement);
            await _context.SaveChangesAsync();
           
            return newElement.Id;
        }

        public async Task<ElementModel> GetElementById(int id)
        {
            return await _context.Tags.Where(x => x.Id == id).Select(element => new ElementModel()
            {
                TagName = element.TagName,
              /*  IsContent = element.IsContent,
                Content = element.Content,*/
            }).FirstOrDefaultAsync();
        }

    }
}
