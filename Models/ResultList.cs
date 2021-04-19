using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExaminationSystemAPI.Models
{
    [Keyless]
    public class ResultList
    {
        public int TestId { get; set; }

        public string TestName { get; set; }

        public int Marks { get; set; }
    }
}
