using FirstMvcApp.Data;
using FirstMvcApp.Database;

namespace FirstMvcApp.Services
{
    public class RoomService : IRoomService
    {
        private readonly UserDbContext _context;

        public RoomService(UserDbContext context)
        {
            _context = context;
        }

        public void Add(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public List<Room> GetRooms()
        {
            return _context.Rooms.ToList();
        }
    }
}
