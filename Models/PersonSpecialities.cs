using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class PersonSpecialities
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int SpecialityId {  get; set; }
        [NotMapped]
        public string SpecialityName { get; set; } = string.Empty;
    }
}
