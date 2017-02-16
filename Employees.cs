using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerAndStruct
{
    struct Employees
    {
        public string name;
        public string surname;
        public string position;
        public int year;
        public int salary;

        public Employees(string _name, string _surname, string _position, int _year, int _salary)
        {
            name = _name;
            surname = _surname;
            position = _position;
            year = _year;
            salary = _salary;
        }
    }
}
