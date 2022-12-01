namespace MovieLibrary
{
    /// <summary>Provides a base implementation of <see cref="IMovieDatabase"/>.</summary>
    public abstract class MovieDatabase : IMovieDatabase
    {
        /// <inheritdoc />
        public Movie Add ( Movie movie )
        {
            //Validate movie
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            //Use IValidatableObject Luke...
            ObjectValidator.Validate(movie);

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
                throw new InvalidOperationException("Movie title must be unique.");

            movie.OldMethod();

            //Add
            movie = AddCore(movie);            
            return movie;
        }
        
        /// <inheritdoc />        
        public Movie Get ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            return GetCore(id);
        }

        /// <inheritdoc />                
        public IEnumerable<Movie> GetAll ()
        {
            return GetAllCore();
        }

        /// <inheritdoc />        
        public void Remove ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            RemoveCore(id);
        }

        /// <inheritdoc />        
        public void Update ( int id, Movie movie )
        {
            //Validate movie
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            if (movie == null)
                throw new ArgumentNullException(nameof(movie));
            ObjectValidator.Validate(movie);

            //Movie must already exist
            var oldMovie = GetCore(id);
            if (oldMovie == null)
                throw new ArgumentException("Movie does not exist", nameof(movie));

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null && existing.Id != id)
                throw new InvalidOperationException("Movie title must be unique.");

            try
            {
                UpdateCore(id, movie);
            } catch (Exception e)
            {
                throw new Exception("Update failed", e);
            };
        }

        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The new movie.</returns>
        protected abstract Movie AddCore ( Movie movie );

        /// <summary>Gets a movie by ID.</summary>
        /// <param name="id">The ID of the movie.</param>
        /// <returns>The movie, if any.</returns>
        protected abstract Movie GetCore ( int id );

        /// <summary>Gets all movies.</summary>
        /// <returns>The list of movies.</returns>
        protected abstract IEnumerable<Movie> GetAllCore ();

        /// <summary>Removes a movie given its ID.</summary>
        /// <param name="id">The movie ID.</param>
        protected abstract void RemoveCore ( int id );

        /// <summary>Updates an existing movie.</summary>
        /// <param name="id">The movie ID.</param>
        /// <param name="movie">The movie details.</param>
        protected abstract void UpdateCore ( int id, Movie movie );

        /// <summary>Finds a movie by its title.</summary>
        /// <param name="title">The movie title.</param>
        /// <returns>The movie, if any.</returns>
        protected abstract Movie FindByTitle ( string title );
    }
}
