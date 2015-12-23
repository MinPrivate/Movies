using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class MovieShow
    {
        private string _name;
        private string _showTime;
        private int _price;
        
        private string _buyWebsite;

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

        public string ShowTime
        {
            get
            {
                return _showTime;
            }
            set
            {
                _showTime = value;
            }

        }

        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }

        }

        public string BuyWebsite
        {
            get
            {
                return _buyWebsite;
            }
            set
            {
                _buyWebsite = value;
            }

        }
    }
}
