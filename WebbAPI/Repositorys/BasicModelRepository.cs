using Microsoft.EntityFrameworkCore;
using WebbAPI.Data;
using WebbAPI.DTOs;
using WebbAPI.Models;
using WebbAPI.Repositorys.Contracts;

namespace WebbAPI.Repositorys
{
    public class BasicModelRepository : IBasicModel
    {
        private readonly DataContext _context;

        public BasicModelRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BasicModelDTO>> GetAllBasicModelsAsync()
        {
            return await _context.BasicModels
                .Select(b => new BasicModelDTO
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToListAsync();
        }

        public async Task<BasicModelDTO> GetBasicModel(int id)
        {
#pragma warning disable CS8603
            return await _context.BasicModels
                .Select(b => new BasicModelDTO
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .SingleOrDefaultAsync(c => c.Id == id);
#pragma warning restore CS8603
        }

        public async Task<BasicModel> AddBasicModelAsync(BasicModelDTO basicModelDto)
        {
            BasicModel basicModel = new BasicModel()
            {
                Name = basicModelDto.Name
            };
            var result = await _context.BasicModels.AddAsync(basicModel);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task DeleteBasicModelAsync(int id)
        {
            BasicModel basicModel = await _context.BasicModels.FindAsync(id);

            if (basicModel != null)
            {
                _context.BasicModels.Remove(basicModel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateModel(BasicModelDTO basicModelDto)
        {
            BasicModel basicModel = new BasicModel()
            {
                Id = basicModelDto.Id,
                Name = basicModelDto.Name
            };
            _context.Entry(basicModel).State = EntityState.Modified;



            await _context.SaveChangesAsync();
        }
    }
}
