namespace MovieLibrary.Memory
{
    /// <summary>Provides an implementation of <see cref="IMovieDatabase"/> using an in-memory list.</summary>
    public class MemoryMovieDatabase : MovieDatabase
    {
        /// <inheritdoc />
        protected override Movie AddCore ( Movie movie )
        {
            movie.Id = _id++;
            _movies.Add(movie.Clone());

            return movie;
        }

        /// <inheritdoc />
        protected override Movie GetCore ( int id )
        {
            return _movies.FirstOrDefault(x => x.Id == id)?.Clone();
        }

        /// <inheritdoc />
        //When method returns IEnumerable<T> you MAY use an iterator instead
        protected override IEnumerable<Movie> GetAllCore ()
        {
            // Select transforms IEnumerable<S> into IEnumerable<T>
            //return _movies.Select(x => x.Clone());

            //LINQ syntax version
            //   from tempVar in IEnumerable<T>
            //   where <condition>
            //   order by
            //   select <expression>
            return from movie in _movies
                   //where movie.Id > 10
                   orderby movie.Title, movie.ReleaseYear
                   select movie.Clone();
        }

        /// <inheritdoc />
        protected override void RemoveCore ( int id )
        {
            var movie = FindById(id);
            if (movie != null)
                _movies.Remove(movie);
        }

        /// <inheritdoc />
        protected override void UpdateCore ( int id, Movie movie )
        {
            //Copy 
            var oldMovie = FindById(id);            
            if (oldMovie == null)
                throw new NotSupportedException("Movie does not exist.");

            movie.CopyTo(oldMovie);
            oldMovie.Id = id;
        }

        /// <inheritdoc />
        protected override Movie FindByTitle ( string title )
        {
            return _movies.FirstOrDefault(
                        x => String.Equals(x.Title, title, StringComparison.OrdinalIgnoreCase));
        }

        #region Private Members

        //Action -> Method with no return type
        // Action<T> -> parameter of T
        // Action<T1..T16> -> parameters of T1 to T16
        //Func<R> -> Method with a return type of R
        // Func<T, R> -> parameter of T
        // Func<T1..T16, R> -> parameters of T1 to T16
        private Movie FindById ( int id )
        {
            // Where takes a IEnumerable<T> and returns all items that match the predicate
            // defined by Func<Movie, bool>
            //return _movies.Where(FilterById)
            //              .FirstOrDefault();
            // If you need extra data then a nested class with the data would be needed
            // return _movies.FirstOrDefault(new MyHiddenClass(id).FilterById);
            //return _movies.FirstOrDefault(FilterById);

            //lambda - anonymous method/function
            //  foo ( Movie x ) { return x.Id == id; }
            return _movies.FirstOrDefault(x => x.Id == id);

            //foreach (var movie in _movies)
            //    if (movie.Id == id)
            //        return movie;

            //return null;
        }
        //private bool FilterById ( Movie movie )
        //{
        //    return true;
        //}
        
        private int _id = 1;

        //private Movie[] _movies = new Movie[100];
        private List<Movie> _movies = new List<Movie>();
        #endregion
    }
}
