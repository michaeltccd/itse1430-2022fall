using System;

namespace MovieLibrary
{
    /// <summary>Provides a database of movies.</summary>
    public class MovieDatabase
    {
        //TODO: Seed database

        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The new movie.</returns>
        /// <remarks>
        /// Fails if:
        ///   - Movie is null
        ///   - Movie is not valid
        ///   - Movie title already exists
        /// </remarks>
        public virtual Movie Add ( Movie movie, out string errorMessage )
        {
            //Array
            // Find first null element
            // If found then set to new movie
            // Else
            //   Resize the array 
            //   Copy all existing elements over
            //   Set 'oldarray.Length' to new movie

            //Validate movie
            if (movie == null)
            {
                errorMessage = "Movie cannot be null";
                return null;
            };
            if (!movie.Validate(out errorMessage))
                return null;

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
            {
                errorMessage = "Movie must be unique";
                return null;
            };

            //Add
            movie.Id = _id++;
            _movies.Add(movie.Clone());

            errorMessage = null;
            return movie;
        }

        /// <summary>Gets a movie.</summary>
        /// <param name="id">ID of the movie.</param>
        /// <returns>The movie, if any.</returns>
        /// <remarks>
        /// Fails if:
        ///    - Id is less than 1
        /// </remarks>
        public Movie Get ( int id )
        {
            //Enumerate array looking for match            
            //for (var index = 0; index < _movies.Length; ++index)
            //if (_movies[index]?.Id == id)
            //return _movies[index].Clone();  //Clone because of ref type
            foreach (var movie in _movies)
                if (movie?.Id == id)
                    return movie.Clone();  //Clone because of ref type

            return null;
        }

        /// <summary>Gets all the movies.</summary>
        /// <returns>The movies.</returns>
        public Movie[] GetAll ()
        {
            var items = new Movie[_movies.Count];
            //for (var index = 0; index < _movies.Length; ++index)
            //    items[index] = _movies[index]?.Clone();
            var index = 0;
            foreach (var movie in _movies)
                items[index++] = movie.Clone();

            //Empty array
            //new Movie[0];

            return items;
        }

        public void Remove ( int id )
        {
            //TODO: Switch to foreach
            //Enumerate array looking for match
            for (var index = 0; index < _movies.Count; ++index)
                if (_movies[index]?.Id == id)
                {
                    //_movies[index] = null;
                    _movies.RemoveAt(index);
                    return;
                };
        }

        public bool Update ( int id, Movie movie, out string errorMessage )
        {
            //Validate movie
            if (movie == null)
            {
                errorMessage = "Movie cannot be null";
                return false;
            };
            if (!movie.Validate(out errorMessage))
                return false;

            //Movie must already exist
            var oldMovie = FindById(id);
            if (oldMovie == null)
            {
                errorMessage = "Movie does not exist";
                return false;
            };

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null && existing.Id != id)
            {
                errorMessage = "Movie must be unique";
                return false;
            };

            //Copy 
            movie.CopyTo(oldMovie);
            oldMovie.Id = id;

            errorMessage = null;
            return true;
        }

        #region Private Members
        
        private Movie FindById ( int id )
        {
            foreach (var movie in _movies)
                if (movie.Id == id)
                    return movie;

            return null;
        }

        private Movie FindByTitle ( string title )
        {
            foreach (var movie in _movies)
                if (String.Equals(movie.Title, title, StringComparison.OrdinalIgnoreCase))
                    return movie;

            return null;
        }

        private int _id = 1;

        //System.Collections.Generic
        //private Movie[] _movies = new Movie[100];
        private List<Movie> _movies = new List<Movie>();
        //private Collection<Movie> _movies = new Collection<Movie>();
        //List<string>;
          //  List<int>;
        #endregion
    }
}
