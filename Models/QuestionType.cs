using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExaminationSystemAPI.Models
{
    public class QuestionType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
