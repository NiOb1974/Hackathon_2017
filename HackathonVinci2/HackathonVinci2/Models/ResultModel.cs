using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackathonVinci2.Models
{
    public class ResultModel
    {
        public ResultModel()
        {
            TableList = new List<rowElement>();
        }
        public int Month { get; set; }
        public List<rowElement> TableList { get; set; }
        public decimal Ertrag { get; set; }
        public string ViewErtrag { get; set; }
    }
}