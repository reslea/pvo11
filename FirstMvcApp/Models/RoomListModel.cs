using FirstMvcApp.Data;

namespace FirstMvcApp.Models
{
    public class RoomListModel
    {
        public List<Room> Rooms { get; set; }

        public bool IsAuthenticated { get; set; }

    }
}
