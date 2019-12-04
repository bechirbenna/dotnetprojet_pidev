using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pidev.Models
{
    public class SkillModel
    {
        public int skillId { get; set; }
        public string skillDesc { get; set; }
        public string skillName { get; set; }
        public DateTime skillDate { get; set; }
    }
}