using FirstMvcApp.Data;

namespace FirstMvcApp.Services
{
    public interface IRoomService
    {
        List<Room> GetRooms();

        void Add(Room room);
    }
}
