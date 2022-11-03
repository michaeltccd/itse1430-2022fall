namespace MovieLibrary.Memory
{
    /// <summary>Provides an implementation of <see cref="IMovieDatabase"/> using an in-memory list.</summary>
    public class MemoryMovieDatabase : MovieDatabase
    {
        /// <inheritdoc />
        protected override Movie AddCore ( Movie movie )
        {
            //Array
            // Find first null element
            // If found then set to new movie
            // Else
            //   Resize the array 
            //   Copy all existing elements over
            //   Set 'oldarray.Length' to new movie
           
            //Add
            movie.Id = _id++;
            _movies.Add(movie.Clone());

            return movie;
        }

        /// <inheritdoc />
        protected override Movie GetCore ( int id )
        {
            //TODO: Simplify this
            //Enumerate array looking for match            
            //for (var index = 0; index < _movies.Length; ++index)
            //if (_movies[index]?.Id == id)
            //return _movies[index].Clone();  //Clone because of ref type
            foreach (var movie in _movies)
                if (movie?.Id == id)
                    return movie.Clone();  //Clone because of ref type

            return null;
        }

        /// <inheritdoc />
        //When method returns IEnumerable<T> you MAY use an iterator instead
        protected override IEnumerable<Movie> GetAllCore ()
        {
            //TODO: Simplify this
            //var items = new List<Movie>();

            //When returning an array, clone it...
            //var items = new Movie[_movies.Count];
            //for (var index = 0; index < _movies.Length; ++index)
            //    items[index] = _movies[index]?.Clone();
            //var index = 0;
            foreach (var movie in _movies)
            {
                //items[index++] = movie.Clone();
                //items.Add(movie.Clone());
                yield return movie.Clone();
            };

            //return items;
        }

        /// <inheritdoc />
        protected override void RemoveCore ( int id )
        {
            //TODO: Simplify this
            for (var index = 0; index < _movies.Count; ++index)
                if (_movies[index]?.Id == id)
                {
                    //_movies[index] = null;
                    _movies.RemoveAt(index);
                    return;
                };
        }

        /// <inheritdoc />
        protected override void UpdateCore ( int id, Movie movie )
        {
            //Copy 
            var oldMovie = FindById(id);
            movie.CopyTo(oldMovie);
            oldMovie.Id = id;
        }

        protected override Movie FindByTitle ( string title )
        {
            //TODO: Simplify this
            foreach (var movie in _movies)
                if (String.Equals(movie.Title, title, StringComparison.OrdinalIgnoreCase))
                    return movie;

            return null;
        }

        #region Private Members

        private Movie FindById ( int id )
        {
            //TODO: Simplify this
            foreach (var movie in _movies)
                if (movie.Id == id)
                    return movie;

            return null;
        }
        
        private int _id = 1;

        //private Movie[] _movies = new Movie[100];
        private List<Movie> _movies = new List<Movie>();
        #endregion
    }
}
