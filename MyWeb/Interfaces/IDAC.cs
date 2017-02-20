using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;

namespace Interfaces
{
    public interface IMovie
    {
        void Create(Movie _movie);

        Movie Read(Movie _movie);

        List<Movie> ReadAll();

        void Update(Movie _movie);

        void Delete(Movie _movie);

    }

    public interface IComents
    {
        void Create(Coments _coments);

        Coments Read(Coments _coments);

        List<Coments> ReadAll();

        void Update(Coments _coments);

        void Delete(Coments _coments);

    }
}
