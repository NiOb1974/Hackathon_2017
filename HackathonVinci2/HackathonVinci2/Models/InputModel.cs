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

        [DisplayName("Amount of coal-fired power stations")]
        [Required]
        public int CoalSiteAmount { get; set; }

        [DisplayName("Amount of solar power plants")]
        [Required]
        public int SolarSiteAmount { get; set; }

        [DisplayName("Amount of wind power stations")]
        [Required]
        public int WindSiteAmount { get; set; }

        [DisplayName("Time span of prediction (in months)")]
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