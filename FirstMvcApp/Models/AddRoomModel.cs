using System.ComponentModel.DataAnnotations;

namespace FirstMvcApp.Models
{
    public class AddRoomModel
    {
        [Required]
        public string Name { get; set; }

        [Range(1, 10)]
        public int MaxVisitorsCount { get; set; }
    }
}