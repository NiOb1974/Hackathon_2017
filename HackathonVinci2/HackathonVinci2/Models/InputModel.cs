using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackathonVinci2.Models
{
    public class InputModel
    {
        public Guid Id { get; private set; }

        public string Profile { get; set; }

        public InputModel()
        {
            this.Id = new Guid();
        }
    }
}