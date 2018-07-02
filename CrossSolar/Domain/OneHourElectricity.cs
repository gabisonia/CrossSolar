using System;
using System.ComponentModel.DataAnnotations;

namespace CrossSolar.Domain
{
    public class OneHourElectricity
    {
        public int Id { get; set; }

        public int PanelId { get; set; }

        [Required]
        public long KiloWatt { get; set; }

        public DateTime DateTime { get; set; }
    }
}