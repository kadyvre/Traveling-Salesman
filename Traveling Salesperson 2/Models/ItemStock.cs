using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingActivity_TheTravelingSalesperson
{
    public class ItemStock
    {
        #region ENUMERABLES

        public enum ItemType
        {
            None
        }

        #endregion
        
        #region FIELDS

        private ItemType _type;
        private int _numberOfUnits;

        #endregion

        
        #region PROPERTIES

        public ItemType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int NumberOfUnits
        {
            get { return _numberOfUnits; }
        }

        #endregion


        #region CONSTRUCTORS

        public ItemStock()
        {
            _type = ItemType.None;
            _numberOfUnits = 0;
        }

        public ItemStock(ItemType type, int numberOfUnits)
        {
            _type = type;
            _numberOfUnits = numberOfUnits;
        }

        #endregion


        #region METHODS

        /// <summary>
        /// add widgets to the inventory
        /// </summary>
        /// <param name="unitsToAdd">number of units to add</param>
        public void AddItems(int unitsToAdd)
        {
            if ( unitsToAdd < 0 )
            {
                Console.WriteLine("Please enter a positive whole number.");
            }
            else
            {
                _numberOfUnits += unitsToAdd;
            }
            
        }

        // TODO - validate to disable negative stock unit values
        /// <summary>
        /// subtract widgets from the inventory
        /// </summary>
        /// <param name="unitsToSubtract">number of units to subtract</param>
        public void SubtractItems(int unitsToSubtract)
        {
            if (_numberOfUnits < 0)
            {
                Console.WriteLine("You do not have that many to sell.");
            }
            else
            {
                _numberOfUnits -= unitsToSubtract;
            }
            
        }

        #endregion
    }
}
