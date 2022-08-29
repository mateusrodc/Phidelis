using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.PhidelisSystem.Domain.Models
{
    public class Registration
    {
        public int id { get; set; }
        public int studentid { get; set; }
        public string grade { get; set; }
        public string lesson { get; set; }
        public Registration()
        {

        }
        public Registration(int _studentid, string _grade, string _lesson)
        { 
            studentid = _studentid;
            grade = _grade;
            lesson = _lesson;
        }
    }
}
