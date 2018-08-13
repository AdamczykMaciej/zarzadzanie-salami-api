using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.Models
{
    public class EducationalClassroom : Classroom
    {
        public int Liczba_gniazd_sieciowych { get; set; }
        public bool TV { get; set; }
        public bool Projektor { get; set; }
        public int Liczba_miejsc_dydaktycznych { get; set; }
    }
}
