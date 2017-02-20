using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Movie
    {
        
        public int ID
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

         

        public byte[] Img
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

    }

    public class Coments
    {
        private int _rating;
        private string _comment;

        public int ID
        {
            get;
            set;
        }

        public string Coment
        {
            get {return _comment;}
            set
            {
                int k = 1;
                int j = value.Length;

                for (int i = 0; i < j; i++)
                { 
                  
                    if ((i!=0) & (value[i] == ' '))
                    {                       
                        k = 1;
                    }


                    if ((k % 40) == 0)
                    {
                        
                         value = value.Insert(i, " </br>");
                         i = i + 5;
                         j = j + 5; 
                    
                    }
                    k++; 
                }

                _comment = value; 
            }
        }

        public int Rating
        {
            get { return _rating; }
            set
            {
                if (value < 0)
                {
                    _rating = 0;
                }
                else
                {
                    if (value <= 10)
                    {
                        _rating = value;
                    }
                    else
                    {
                        _rating = 10;
                    }
                }
            }
        }

        public int ID_Film
        {
            get;
            set;
        }

    }
}
