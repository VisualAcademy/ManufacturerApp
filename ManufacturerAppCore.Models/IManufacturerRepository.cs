using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManufacturerAppCore.Models
{
    public interface IManufacturerRepository
    {
        Task<Manufacturer> AddManufacturerAsync(Manufacturer manufacturer);  // 입력
        Task<List<Manufacturer>> GetManufacturersAsync();                    // 출력
        Task<Manufacturer> GetManufacturerAsync(int id);                     // 상세
        Task<Manufacturer> EditManufacturerAsync(Manufacturer manufacturer); // 수정
        Task DeleteManufacturerAsync(int id);                                // 삭제
    }
}
