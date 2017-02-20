using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using Entities;
using Interfaces;


namespace SQLDAL
{
    public class MovieDAC : IMovie 
    {
        private string _cnStr;
        private SqlConnection _conection;
        private SqlCommand _command;
        //private SqlDataReader _reader;

        private void ConfConnComm(string _querystr)
        { 	
       
               _cnStr = ConfigurationManager.AppSettings["cnStr"];

               _conection = new SqlConnection(_cnStr);

               _command = new SqlCommand(_querystr,_conection);

        }

        public void Create(Movie _movie)
        {

            ConfConnComm("INSERT INTO Film (Title, Descr, Img)" +
                         "VALUES (@Title, @Descr, @Img)");

            SqlParameter _par = new SqlParameter( "@Title", SqlDbType.NVarChar );
            _par.Value = _movie.Title;  
	        _par.Direction = ParameterDirection.Input;  
	        _command.Parameters.Add(_par);  
	  
	        _par = new SqlParameter("@Descr", SqlDbType.NVarChar);  
	        _par.Value = _movie.Description;  
	        _command.Parameters.Add(_par);  
	  
	        _par = new SqlParameter("@Img", SqlDbType.Image);  
	        _par.Value = _movie.Img;  
	        _command.Parameters.Add(_par);  

            using (_conection)
            {
                _conection.Open();
                _command.ExecuteNonQuery();
                
            }
        }

        public Movie Read(Movie _movie)
        {
            ConfConnComm("SELECT * FROM Film WHERE ID = @id");

            _command.Parameters.Add("@id", SqlDbType.Int);
            _command.Parameters["@id"].Value = _movie.ID;
 
            using (_conection)
            {
                _conection.Open();
     
                    using (var _reader = _command.ExecuteReader())
                    {
                        _reader.Read();
                        _movie.ID = (int)_reader["ID"];
                        _movie.Title = (string)_reader["Title"];
                        _movie.Img = (byte[])_reader["Img"];
                        _movie.Description = (string)_reader["Descr"];

                    }


                    _command.ExecuteNonQuery();

                
            }

            return _movie;
        }

        public List<Movie> ReadAll()
        {
            List<Movie> movie = new List<Movie>();

            //ConfConnComm();

            //using (_conection)
            //{
            //    _conection.Open();

            //    using (_command)
            //    {

            //        _command.Connection = _conection;
            //        _command.CommandText = string.Format("SELECT * FROM Film");

            //        using (_reader = _command.ExecuteReader())
            //        {

            //            while (_reader.Read())
            //            {
            //                Movie _movies = new Movie();
            //                _movies.ID = (int)_reader["ID"];
            //                _movies.Img = (byte[])_reader["Img"];
            //                _movies.Title = (string)_reader["Title"];
            //                _movies.Description = (string)_reader["Descr"];
                             
            //                movie.Add(_movies);
            //            }

            //        }


            //        _command.ExecuteNonQuery();

            //    }
            //}

            return movie;
        }

        public void Update(Movie _movie)
        {
            //ConfConnComm();

            //using (_conection)
            //{
            //    _conection.Open();

            //    using (_command)
            //    {
                    
            //        _command.Connection = _conection;
            //        _command.CommandText = string.Format("UPDATE Film SET Title = '{0}', Img = {1}, Descr = '{2}' WHERE ID = {3}", _movie.Title, _movie.Img, _movie.Description, _movie.ID);
            //        _command.ExecuteNonQuery();

            //    }
            //}

        }


        public void Delete(Movie _movie)
        {
            //ConfConnComm();

            //using (_conection)
            //{
            //    _conection.Open();

            //    using (_command)
            //    {
            //        _command.Connection = _conection;
            //        _command.CommandText = string.Format("DELETE FROM Film WHERE ID = {0}", _movie.ID);
            //        _command.ExecuteNonQuery();

            //    }
            //}

        }
    }

    public class ComentsDAC : IComents
    {
        private string _cnStr;
        private SqlConnection _conection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        private void ConfConnComm()
        {
            _cnStr = ConfigurationManager.AppSettings["cnStr"];

            _conection = new SqlConnection(_cnStr);

            _command = new SqlCommand();

        }

        public void Create(Coments _coments)
        {
            ConfConnComm();

            using (_conection)
            {
                _conection.Open();

                using (_command)
                {
                    _command.Connection = _conection;
                    _command.CommandText = string.Format("INSERT INTO Coments (Coment, Rating, ID_Film) VALUES ('{0}',{1},{2})", _coments.Coment , _coments.Rating , _coments.ID_Film);
                    _command.ExecuteNonQuery();

                }
            }
        }

        public Coments Read(Coments _coments)
        {
            ConfConnComm();

            using (_conection)
            {
                _conection.Open();

                using (_command)
                {

                    _command.Connection = _conection;
                    _command.CommandText = string.Format("SELECT * FROM Coments WHERE ID = {0}", _coments.ID);

                    using (_reader = _command.ExecuteReader())
                    {
                        _reader.Read();
                        _coments.ID = (int)_reader["ID"];
                        _coments.Coment = (string)_reader["Coment"];
                        _coments.Rating = (int)_reader["Rating"];
                        _coments.ID_Film = (int)_reader["ID_Film"];

                    }


                    _command.ExecuteNonQuery();

                }
            }

            return _coments;
        }

        public List<Coments> ReadAll()
        {
            List<Coments> coment = new List<Coments>();

            ConfConnComm();

            using (_conection)
            {
                _conection.Open();

                using (_command)
                {

                    _command.Connection = _conection;
                    _command.CommandText = string.Format("SELECT * FROM Coments");

                    using (_reader = _command.ExecuteReader())
                    {
                        
                        while (_reader.Read())
                        {
                            Coments _coments = new Coments();
                            _coments.ID = (int)_reader["ID"];
                            _coments.Coment = (string)_reader["Coment"];
                            _coments.Rating = (int)_reader["Rating"];
                            _coments.ID_Film = (int)_reader["ID_Film"];

                            coment.Add(_coments);
                        }

                    }


                    _command.ExecuteNonQuery();

                }
            }

            return coment;
        }

        public void Update(Coments _coments)
        {
            ConfConnComm();

            using (_conection)
            {
                _conection.Open();

                using (_command)
                {
                    _command.Connection = _conection;
                    _command.CommandText = string.Format("UPDATE Coments SET Coment = '{0}', Rating = {1}, ID_Film = {2} WHERE ID = {3}", _coments.Coment, _coments.Rating, _coments.ID_Film, _coments.ID);
                    _command.ExecuteNonQuery();

                }
            }

        }


        public void Delete(Coments _coments)
        {
            ConfConnComm();

            using (_conection)
            {
                _conection.Open();

                using (_command)
                {
                    _command.Connection = _conection;
                    _command.CommandText = string.Format("DELETE FROM Coments WHERE ID = {0}", _coments.ID);
                    _command.ExecuteNonQuery();

                }
            }

        }
    }
}
