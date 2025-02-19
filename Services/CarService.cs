using BlazorAppCarsCrud.Data;
using BlazorAppCarsCrud.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace BlazorAppCarsCrud.Services
{
    public class CarService
    {
        private readonly AppDbContext _context;

        public CarService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> Get()
        {
            try
            {
                return await _context.Cars
              .OrderByDescending(c => c.CreationDate)
              .ToListAsync();
            }
            catch (Exception e)
            {

                Console.WriteLine("Error : "+e.Message);
                return null;
            }
          
        }

        public async Task<List<Car>> GetBySearch(string search)
        {
            try
            {
                return await _context.Cars
              .Where(c => c.Title.ToLower().Contains(search.ToLower()))
              .OrderByDescending(c => c.CreationDate)
              .ToListAsync();
            }
            catch (Exception e)
            {

                Console.WriteLine("Error on Get Cars, Date :" + DateTime.Now + " | " + e.Message);
                return null;
            }

        }
        public async Task<Car> GetById(int id)
        {
            return await _context.Cars.FindAsync(id); 
        }


        public async Task<string> Delete(int id)
        {
            try
            {
                var exist = await _context.Cars.FindAsync(id);
                if (exist != null)
                {
                    _context.Cars.Remove(exist);
                    await _context.SaveChangesAsync();
                    return "1";
                }
                return "0";
            }
            catch (Exception e)
            {
               
                return e.Message;
            }

        }
        public async Task<string> Add(Car model)
        {
            try
            {
                await _context.Cars.AddAsync(model);
                await _context.SaveChangesAsync();
                return "1";
            }
            catch (Exception e)
            {

                return e.Message;
            }

        }

        public async Task<string> Update(Car model)
        {

            try
            {
                var exist = await _context.Cars.FindAsync(model.Id);
                if (exist != null)
                {
                    _context.Cars.Update(model);
                    await _context.SaveChangesAsync();
                    return "1";
                }
                return "0";

            }
            catch (Exception e)
            {

                return e.Message;
            }

        }
    }
}
