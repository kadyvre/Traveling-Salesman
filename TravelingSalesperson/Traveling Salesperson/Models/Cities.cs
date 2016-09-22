using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingActivity_TheTravelingSalesperson.Solution.Models
{
    public class Cities
    {
        private List<string> _cities;

        //public List<string> cityList
        //{
        //    get { return _cities; }
        //    set { _cities = cityList; }
        //}
        public Cities()
        {
            _cities = new List<string>();
            _cities.Add("Lansing");
            _cities.Add("Detroit");
            _cities.Add("Traverse City");
            _cities.Add("Jackson");
        }


    }
}

