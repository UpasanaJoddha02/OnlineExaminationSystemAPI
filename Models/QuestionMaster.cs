using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExaminationSystemAPI.Models
{
    public class QuestionMaster
    {
        [Key]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Type { get; set; }
        public string Answer { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public int Marks { get; set; }
        public int CreatedBy { get; set; }
    }
}
