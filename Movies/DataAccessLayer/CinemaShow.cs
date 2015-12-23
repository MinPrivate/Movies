using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class CinemaShow
    {
        private string _name;

        private string _adress;
        private int _movieNum;

        public string Name 
        { 
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
                
        }

        public string Address
        {
            get
            {
                return _adress;
            }
            set
            {
                _adress = value;
            }

        }

        public int MovieNum
        {
            get
            {
                return _movieNum;
            }
            set
            {
                _movieNum = value;
            }

        }
    }
}
