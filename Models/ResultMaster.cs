using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExaminationSystemAPI.Models
{
    public class ResultMaster
    {
        [Key]
        public int Id { get; set; }

        public int TestId { get; set; }

        public int StudentId { get; set; }

        public int Marks { get; set; }
    }
}
