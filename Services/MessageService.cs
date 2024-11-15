using BlazorAppCarsCrud.Data;
using BlazorAppCarsCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppCarsCrud.Services
{
    public class MessageService
    {

        private readonly AppDbContext _context;

        public MessageService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddAsync(Message message)
        {
            try
            {
                await _context.AddAsync(message);
                await _context.SaveChangesAsync();
                Console.WriteLine("The message is saved!");
                return "1";
               
            }
            catch (Exception e)
            {
                Console.WriteLine("Error on Messages Service Add : " + DateTime.Now + " | " + e.Message);

                return e.Message;
            }
        }

        public async Task<List<Message>> Get()
        {
            try
            {
                return await _context.Messages
                    .OrderBy(x => x.Date)
                    .ToListAsync();
            }
            catch (Exception e)
            {

                Console.WriteLine("Error on Messages Service Get : " + DateTime.Now + " | " + e.Message);
                return null;
            }
        }
    }
}
