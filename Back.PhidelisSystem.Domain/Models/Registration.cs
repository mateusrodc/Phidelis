using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.PhidelisSystem.Domain.Models
{
    public class Registration
    {
        public int id { get; set; }
        public DateTime registrationdate { get; set; }
        public int studentid { get; set; }
        public string grade { get; set; }
        public string lesson { get; set; }
        public Registration()
        {

        }
        public Registration(DateTime _registrationdate, int _studentid, string _grade, string _lesson)
        {
            registrationdate = _registrationdate;
            studentid = _studentid;
            grade = _grade;
            lesson = _lesson;
        }
    }
}
