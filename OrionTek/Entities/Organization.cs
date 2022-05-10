using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrionTek.Entities
{
    public class Organization : BaseModel
    {
        [StringLength(200, MinimumLength = 3, ErrorMessage = "The {0} field must have at least {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Client> Clients { get; set; }
    }
}
