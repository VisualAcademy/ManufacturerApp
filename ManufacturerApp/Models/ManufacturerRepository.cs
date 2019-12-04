using ManufacturerApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManufacturerApp.Models
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly ApplicationDbContext _context;

        public ManufacturerRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        // 입력
        public async Task<Manufacturer> AddManufacturer(Manufacturer manufacturer)
        {
            _context.Manufacturers.Add(manufacturer);
            await _context.SaveChangesAsync();
            return manufacturer;
        }

        // 출력
        public async Task<List<Manufacturer>> GetManufacturers()
        {
            return await _context.Manufacturers.OrderBy(m => m.Id).ToListAsync();
        }

        // 상세
        public async Task<Manufacturer> GetManufacturer(int id)
        {
            //return await _context.Manufacturers.Where(m => m.Id == id).SingleOrDefaultAsync(); 
            return await _context.Manufacturers.FindAsync(id);
        }

        // 수정
        public async Task<Manufacturer> EditManufacturer(Manufacturer manufacturer)
        {
            _context.Entry(manufacturer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return manufacturer; 
        }

        // 삭제 
        public async Task DeleteManufacturer(int id)
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
