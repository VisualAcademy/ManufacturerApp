using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManufacturerApp.Models
{
    public interface IManufacturerRepository
    {
        Task<Manufacturer> AddManufacturer(Manufacturer manufacturer);  // 입력
        Task<List<Manufacturer>> GetManufacturers();                    // 출력
        Task<Manufacturer> GetManufacturer(int id);                     // 상세
        Task<Manufacturer> EditManufacturer(Manufacturer manufacturer); // 수정
        Task DeleteManufacturer(int id);                                // 삭제
    }
}
