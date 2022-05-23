using FirstMvcApp.Data;
using FirstMvcApp.Helpers;
using FirstMvcApp.Models;
using FirstMvcApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvcApp.Models
{
    public class RoomController : Controller
    {
        private readonly IRoomService _service;
        private readonly ClaimsWrapper _claimsWrapper;

        public RoomController(IRoomService service, ClaimsWrapper claimsWrapper)
        {
            _service = service;
            _claimsWrapper = claimsWrapper;
        }

        public IActionResult Index()
        {
            List<Room> rooms = _service.GetRooms();
            var isAuthenticated = _claimsWrapper.IsAuthenticated;

            return View(new RoomListModel() 
            {
                Rooms = rooms,
                IsAuthenticated = isAuthenticated,
                UserLang = (string)HttpContext.Items["USER_PRIMARY_LANG"]!
    });
        }

        [HttpGet, RequireRole("Admin")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost, RequireRole("Admin")]
        public IActionResult Add(AddRoomModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _service.Add(new Room 
            { 
                Name = model.Name, 
                MaxVisitorsCount = model.MaxVisitorsCount 
            });

            return RedirectToAction(nameof(Index));
        }
    }
}
