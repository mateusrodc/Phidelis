using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.PhidelisSystem.Domain.Models
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string birthdate { get; set; }
        public string mother { get; set; }
        public bool registered { get; set; }
        public DateTime registrationdate { get; set; }
        public Student()
        {

        }
        public Student (string _name, string _mother, string _birthdate, bool _registered, DateTime _registrationdate)
        {
            name = _name;
            mother = _mother;
            birthdate = _birthdate;
            registered = _registered;
            registrationdate = _registrationdate;
        }
    }
}
