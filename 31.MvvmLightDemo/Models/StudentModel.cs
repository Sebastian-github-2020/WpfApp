using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _31.MvvmLightDemo.Models
{
    public class StudentModel
    {
        private int id;

        public int Id {
            get { return id; }
            set { id = value; }
        }



        private string name;

        public string Name {
            get { return name; }
            set { name = value; }
        }


    }
}
