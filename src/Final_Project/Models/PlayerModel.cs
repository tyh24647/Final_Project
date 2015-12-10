using System;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models {
    public class PlayerModel {

        public DateTime Updated { get; private set; }
        
        public void SetUpdated() {
            Updated = DateTime.UtcNow;
        }

        public string ETag {
            get {
                return "\"" + Updated.ToLongTimeString() + "\"";
                //return "\"" + this.Name + ":" + Updated.ToLongTimeString() + "\"";
            }
        }

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
