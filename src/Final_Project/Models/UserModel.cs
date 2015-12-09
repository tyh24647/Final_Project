using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models {
    public class UserModel {

        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        public string Character { get; set; }
        
        [Required]
        [MinLength(1)]
        public string Weapon { get; set; }

        [Required]
        [MinLength(1)]
        public string Game { get; set; }        
    }
}
