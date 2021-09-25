using System.Threading.Tasks;
using ordermanager_dotnet.Models;

namespace ordermanager_dotnet.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveChangesAsync();

        //Manufacturer
        Task<Manafacturer[]> GetAllManufacturersAsync(bool includeModel);
        Task<Manafacturer> GetManufacturerAsyncById(int ManufacturerId, bool includeModel);

        //Model
        Task<Model[]> GetAllModelAsync(bool includeManufacturer, bool includeMachine);
        Task<Model> GetModelAsyncById(int ModelId, bool includeManufacturer, bool includeMachine);

        //Machine
        Task<Machine[]> GetAllMachineAsync(bool includeModel);
        Task<Machine> GetMachineAsyncById(int MachineId, bool includeModel);
    }
}
