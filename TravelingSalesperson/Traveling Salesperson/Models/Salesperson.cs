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
        private string _accountNumber;
        private string _productName;

        private int _productUnits;
        private int _age;
        private int _monies;

        private List<string> _locationsVisited;
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

        public string Accountnumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int ProductUnits
        {
            get { return _productUnits; }
            set { _productUnits = value; }
        }

        public int Monies
        {
            get { return _monies; }
            set { _monies = value; }
        }

        public List<string> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }

        }

        #endregion


        #region CONSTRUCTORS

        public Salesperson()
        {
            _locationsVisited = new List<string>();
        }

        public Salesperson(string firstName, string lastName, string accountNumber, int age, List<string> locationsVisited)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = Age;
            _accountNumber = accountNumber;
            _locationsVisited = new List<string>();
        }

        #endregion


        #region METHODS



        #endregion
    }
}
