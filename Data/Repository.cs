using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ordermanager_dotnet.Models;

namespace ordermanager_dotnet.Data
{
    public class Repository : IRepository
    {
        public ApplicationDbContext _context {get;}
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

          public void Update<T>(T entity) where T : class
        {
           _context.Update(entity);
        }

        public async Task<Manufacturer[]> GetAllManufacturersAsync(bool includeModel = false)
        {
            IQueryable<Manufacturer> query = _context.Manufacturers;
            if(includeModel){
                query = query.Include(mo => mo.Models);
            }
            query = query.AsNoTracking().OrderBy(manufacturer => manufacturer.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Manufacturer> GetManufacturerAsyncById(int ManufacturerId, bool includeModel)
        {
            IQueryable<Manufacturer> query = _context.Manufacturers;
            if(includeModel)
            {
                query = query.Include(mo => _context.Models);
            }
            query = query.AsNoTracking().OrderBy(manufacturer => manufacturer.Id).Where(manufacturer => manufacturer.Id == ManufacturerId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Model[]> GetAllModelAsync(bool includeManufacturer = false, bool includeMachine = false)
        {
            IQueryable<Model> query = _context.Models;
            if(includeManufacturer){
                query = query.Include(ma => ma.Manufacturers);
                query = query.Include(mac => mac.Machines);
            }
            query = query.AsNoTracking().OrderBy(model => model.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Model> GetModelAsyncById(int ModelId, bool includeManufacturer, bool includeMachine)
        {
            IQueryable<Model> query = _context.Models;
            if(includeManufacturer && includeMachine){
                query = query.Include(ma => ma.Manufacturers);
                query = query.Include(mac => mac.Machines);
            }
            query = query.AsNoTracking().OrderBy(model => model.Id).Where(model => model.Id == ModelId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<Machine[]> GetAllMachineAsync(bool includeModel = false)
        {
            IQueryable<Machine> query= _context.Machines;
            if(includeModel){
                query = query.Include(mo => mo.Models);
            }
            query = query.AsNoTracking().OrderBy(machine => machine.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Machine> GetMachineAsyncById(int MachineId, bool includeModel)
        {
            IQueryable<Machine> query = _context.Machines;
            if(includeModel){
                query = query.Include(mo => mo.Models);
            }
            query = query.AsNoTracking().OrderBy(machine => machine.Id).Where(machine => machine.Id == MachineId);
            return await query.FirstOrDefaultAsync();
        }
    }
}
