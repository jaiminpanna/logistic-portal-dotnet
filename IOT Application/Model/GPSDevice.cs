using System.ComponentModel.DataAnnotations;

namespace IOT_Application.Model
{
    public class GPSDevice
    {

        [Required]
        [Key]
        public string DeviceId { get; set; }

        public string? EquipmentType { get; set; }

        public int? AccountId { get; set; }

        public string? AccountName { get; set; }

        public int? CourierId { get; set; }

        [EmailAddress]
        public string? ContactEmail { get;  set; }

        public string? Description { get; set; }

        public string? Status { get; set; }
    }
}
