using App.Domain.Entities.Setting;
using App.Domain.Identity;

namespace App.DTOs
{
    public class EmailViewModel
    {
        public User User { get; set; }
        public Setting Setting { get; set; }
    }
}
