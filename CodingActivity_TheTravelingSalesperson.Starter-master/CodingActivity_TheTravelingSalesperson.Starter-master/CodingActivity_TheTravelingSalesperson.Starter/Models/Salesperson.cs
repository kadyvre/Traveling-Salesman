using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingActivity_TheTravelingSalesperson
{
    public class Salesperson
    {
        #region FIELDS

        private string _firstName;
        private string _lastName;
        #endregion
        
        #region PROPERTIES

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        #endregion


        #region CONSTRUCTORS

        //public Salesperson()
        //{

        //}

        public Salesperson(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        #endregion


        #region METHODS



        #endregion
    }
}
