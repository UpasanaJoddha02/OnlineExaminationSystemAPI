using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExaminationSystemAPI.Models
{
    public class TestMaster
    {
        [Key]
        public int TestId { get; set; }
        public string TestName { get; set; }
        public string Duration { get; set; }
        public string Type { get; set; }
    }
}
