using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManufacturerAppCore.Models
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly ManufacturerDbContext _context;

        public ManufacturerRepository(ManufacturerDbContext context)
        {
            this._context = context;
        }

        // 입력
        public async Task<Manufacturer> AddManufacturerAsync(Manufacturer manufacturer)
        {
            _context.Manufacturers.Add(manufacturer);
            await _context.SaveChangesAsync();
            return manufacturer;
        }

        // 출력
        public async Task<List<Manufacturer>> GetManufacturersAsync()
        {
            return await _context.Manufacturers.OrderBy(m => m.Id).ToListAsync();
        }

        // 상세
        public async Task<Manufacturer> GetManufacturerAsync(int id)
        {
            //return await _context.Manufacturers.Where(m => m.Id == id).SingleOrDefaultAsync(); 
            return await _context.Manufacturers.FindAsync(id);
        }

        // 수정
        public async Task<Manufacturer> EditManufacturerAsync(Manufacturer manufacturer)
        {
            _context.Entry(manufacturer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return manufacturer; 
        }

        // 삭제 
        public async Task DeleteManufacturerAsync(int id)
        {
            //var manufacturer = await _context.Manufacturers.Where(m => m.Id == id).SingleOrDefaultAsync();
            var manufacturer = await _context.Manufacturers.FindAsync(id); 
            if (manufacturer != null)
            {
                _context.Manufacturers.Remove(manufacturer);
                await _context.SaveChangesAsync(); 
            }
        }
    }
}
