using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;
using Entities;
using Interfaces;

namespace BLL
{
    public class AvRating
    {
        private static int _count;
       
        public static int AverageRating()
        {
            _count = 0;

            ComentsBLL commen = new ComentsBLL();

            foreach (var ra in commen.ReadAll())
            {
                _count += ra.Rating;
            }
            _count = _count / commen.ReadAll().Count;
           
            return _count ;   
        }
    }

    public class Mov
    {
        public void CreateBLL(string _title, string _description, byte[] _img)
        {
            Movie movies = new Movie();
            MovieBLL movbll = new MovieBLL();
            movies.Title = _title;
            movies.Description = _description;
            movies.Img = _img;

            movbll.Create(movies);
           

        }

        public Movie ReadBLL(int _id)
        {
            Movie movies = new Movie();
            MovieBLL movbll = new MovieBLL();
            movies.ID = _id;
            
            return movbll.Read(movies);

        }

        public byte[] ReadImgBLL(int _id)
        {
            return ReadBLL(_id).Img;
        }

        public List<Movie> ReadAllBLL()
        {
            MovieBLL movbll = new MovieBLL();
            return movbll.ReadAll();
        }

        public void UpdateBLL(int _id, string _title, string _description, byte[] _img)
        {
            Movie movies = new Movie();
            MovieBLL movbll = new MovieBLL();
            movies.ID = _id;
            movies.Title = _title;
            movies.Description = _description;
            movies.Img = _img;

            movbll.Update(movies);

        }

        public void DeleteBLL(int _id)
        {
            Movie movies = new Movie();
            MovieBLL movbll = new MovieBLL();
            movies.ID = _id;

            movbll.Delete(movies);
        }

    }

    public class MovieBLL : IMovie
    {
     
        private Assembly _ass = null;
        private Type _type;
        private object _obj;
        private MethodInfo _method;

        private void Init(string _str)
        {
            


            try
            {
                _ass = Assembly.Load("SQLDAL");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                return;
            }

            _type = _ass.GetType("SQLDAL.MovieDAC");
            _obj = Activator.CreateInstance(_type);
            _method = _type.GetMethod(_str);

        }


        public void Create(Movie _movie)
        {
            Init("Create");

            object[] paramArr = new object[1];
            paramArr[0] = _movie;

            _method.Invoke(_obj, paramArr);

        }

        public Movie Read(Movie _movie)
        {
            Init("Read");

            object[] paramArr = new object[1];
            paramArr[0] = _movie;

            return _movie = (Movie)_method.Invoke(_obj, paramArr);
        }

        public List<Movie> ReadAll()
        {
            Init("ReadAll");

            return (List<Movie>)_method.Invoke(_obj, null);

        }

        public void Update(Movie _movie)
        {
            Init("Update");

            object[] paramArr = new object[1];
            paramArr[0] = _movie;

            _method.Invoke(_obj, paramArr);

        }


        public void Delete(Movie _movie)
        {
            Init("Delete");

            object[] paramArr = new object[1];
            paramArr[0] = _movie;

            _method.Invoke(_obj, paramArr);

        }
    }
    public class Com
    {
        public void CreateBLL(string _coment, int _rating, int _idFilm)
        {
            Coments comments = new Coments();
            ComentsBLL combll = new ComentsBLL();
            comments.Coment = _coment;
            comments.Rating = _rating;
            comments.ID_Film = _idFilm;

            combll.Create(comments);


        }
      
    }

    public class ComentsBLL : IComents
    {

        private Assembly _ass = null;
        private Type _type;
        private object _obj;
        private MethodInfo _method;

        private void Init(string _str)
        {


            try
            {
                _ass = Assembly.Load("SQLDAL");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                return;
            }

            _type = _ass.GetType("SQLDAL.ComentsDAC");
            _obj = Activator.CreateInstance(_type);
            _method = _type.GetMethod(_str);

        }


        public void Create(Coments _coments)
        {
            Init("Create");

            object[] paramArr = new object[1];
            paramArr[0] =_coments;

            _method.Invoke(_obj, paramArr);

        }

        public Coments Read(Coments _coments)
        {

            Init("Read");

            object[] paramArr = new object[1];
            paramArr[0] = _coments;

            return _coments = (Coments)_method.Invoke(_obj, paramArr);
        }

        public List<Coments> ReadAll()
        {
            Init("ReadAll");

            return (List<Coments>)_method.Invoke(_obj, null);
        
        }

        public void Update(Coments _coments)
        {
            Init("Update");

            object[] paramArr = new object[1];
            paramArr[0] = _coments;

            _method.Invoke(_obj, paramArr);

        }


        public void Delete(Coments _coments)
        {
            Init("Delete");

            object[] paramArr = new object[1];
            paramArr[0] = _coments;

            _method.Invoke(_obj, paramArr);

        }
    }
}
