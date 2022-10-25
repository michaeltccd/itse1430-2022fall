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
        public virtual Movie Add ( Movie movie )
        {
            var numberOfElements = _movies.Length;

            _movie = movie;
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
            if (_movie != null && _movie.Id == id)
                return _movie;

            return null;
        }

        /// <summary>Gets all the movies.</summary>
        /// <returns>The movies.</returns>
        public Movie[] GetAll ()
        {
            //TODO: Filter out null
            var items = new Movie[_movies.Length];
            for (var index = 0; index < _movies.Length; ++index)
                items[index] = _movies[index]?.Clone();

            //Empty array
            //new Movie[0];

            return items;
        }

        //TODO: Remove

        //TODO: Update

        #region Private Members

        //TODO: Remove this
        private Movie _movie;
        private Movie[] _movies = new Movie[100];
        #endregion
    }
}
