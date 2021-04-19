using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExaminationSystemAPI.Models
{
    [Keyless]
    public class CalculatedResult
    {

        public int TotalMarks { get; set; }

        public int TotalCorrectAnswers { get; set; }
    }
}
