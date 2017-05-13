using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HackathonVinci2.Models
{
    public class InputModel
    {
        public Guid Id { get; private set; }

        [DisplayName("Anzahl Kohlekraftwerke")]
        [Required]
        public int CoalSiteAmount { get; set; }

        [DisplayName("Anzahl Solarkraftanlagen")]
        [Required]
        public int SolarSiteAmount { get; set; }

        [DisplayName("Anzahl Windkraftanlagen")]
        [Required]
        public int WindSiteAmount { get; set; }

        [DisplayName("Zeitraum der Vorhersage (in Monaten)")]
        [DataType(DataType.Duration)]
        [Required]
        public int Duration { get; set; }

        public InputModel()
        {
            Id = new Guid();
            // Defaults
            CoalSiteAmount = 1;
            WindSiteAmount = 0;
            SolarSiteAmount = 0;
            Duration = 24;
        }
    }
}