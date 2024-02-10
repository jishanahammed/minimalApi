using Microsoft.EntityFrameworkCore;
using mfminimalApi.Models;
using mfminimalApi.logManagers;

namespace mfminimalApi.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _context;

        public CommandRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            await _context.AddAsync(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Remove(cmd);
        }

        public async Task<IEnumerable<Command>> GetAllCommands()
        {
            try
            {
                var commands = await _context.Commands.ToListAsync();
                LogManager.writeToLog("INFORMATION", "Get All Commands", "Count data :" + commands.Count().ToString(), "Success");
                return commands;
            }
            catch (Exception ex)
            {
                LogManager.writeToLog("ERROR", "Get All Commands", "Count data : 0", ex.ToString());
                throw;
            }

        }

        public async Task<Command?> GetCommandById(int id)
        {
            return await _context.Commands.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}