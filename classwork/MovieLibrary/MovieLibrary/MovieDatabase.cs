using System.ComponentModel.DataAnnotations;

namespace MovieLibrary
{
    /// <summary>Provides a database of movies.</summary>
    public class MovieDatabase
    {
        //TODO: Seed database
        public MovieDatabase ()
        {
            //Array/collection initializer syntax
            //var movies = new Movie[3];

            //Object initializer syntax
            //new Movie("Jaws", "PG");
            //var movie = new Movie();
            //movie.Title = "Jaws";
            //movie.Rating = "PG";
            //movie.RunLength = 210;
            //movie.ReleaseYear = 1977;
            //movie.Description = "Shark eats people";
            //movie.IsClassic = true;
            //movies[0] = new Movie() {
            //    Title = "Jaws",
            //    Rating = "PG",
            //    RunLength = 210,
            //    ReleaseYear = 1977,
            //    Description = "Shark eats people",
            //    IsClassic = true,
            //};            
            //movies[1] = new Movie() {
            //    Title = "Jaws 2",
            //    Rating = "PG-13",
            //    RunLength = 220,
            //    ReleaseYear = 1979,
            //    Description = "Shark eats people...again"                
            //};
            //movies[2] = new Movie() {
            //            Title = "Dune",
            //            Rating = "PG-13",
            //            RunLength = 320,
            //            ReleaseYear = 1985,
            //            Description = "Based on book",
            //        };
            var movies = new Movie[] {
                new Movie() {
                    Title = "Jaws",
                    Rating = "PG",
                    RunLength = 210,
                    ReleaseYear = 1977,
                    Description = "Shark eats people",
                    IsClassic = true,
                },
                new Movie() {
                    Title = "Jaws 2",
                    Rating = "PG-13",
                    RunLength = 220,
                    ReleaseYear = 1979,
                    Description = "Shark eats people...again"
                },
                new Movie() {
                    Title = "Dune",
                    Rating = "PG-13",
                    RunLength = 320,
                    ReleaseYear = 1985,
                    Description = "Based on book",
                }
            };
            foreach (var movie in movies)
                Add(movie, out var error);
        }

        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <param name="errorMessage">The error message, if any.</param>
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

            //Use IValidatableObject Luke...
            //if (!movie.Validate(out errorMessage))
            if (!new ObjectValidator().IsValid(movie, out errorMessage))
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

        /// <summary>Remove a movie.</summary>
        /// <param name="id">ID of the movie to remove.</param>
        /// <remarks>
        /// Fails if:
        /// - Id <= 0
        /// </remarks>
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

        /// <summary>Updates a movie in the database.</summary>
        /// <param name="movie">The new movie information.</param>
        /// <param name="errorMessage">The error message, if any.</param>
        /// <returns>true if successful or false otherwise.</returns>
        /// <remarks>
        /// Fails if:
        ///   - Id is <= 0
        ///   - Movie does not already exist
        ///   - Movie is null
        ///   - Movie is not valid
        ///   - Movie title already exists
        /// </remarks>
        public bool Update ( int id, Movie movie, out string errorMessage )
        {
            //Validate movie
            if (movie == null)
            {
                errorMessage = "Movie cannot be null";
                return false;
            };
            //if (!movie.Validate(out errorMessage))
            if (!new ObjectValidator().IsValid(movie, out errorMessage))
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
