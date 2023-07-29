using AgendaMvc.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgendaMvc.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "preencha o campo {0}")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "preencha o campo {0}")]
        public string? Email { get; set; }

        [DisplayName("Celular")]

        [Required(ErrorMessage = "preencha o campo {0}")]
        public string? Phone { get; set; }

        public ContactGroup Group { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }


    }
}
