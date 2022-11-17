namespace MovieLibrary.WinHost
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm ()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnFormClosing ( FormClosingEventArgs e )
        {
            base.OnFormClosing(e);

            if (Confirm("Are you sure you want to leave?", "Close"))
                return;

            //Stop the event
            e.Cancel = true;
        }

        protected override void OnFormClosed ( FormClosedEventArgs e )
        {
            base.OnFormClosed(e);
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            UpdateUI(true);
        }

        #region Event Handlers

        //Called to handle Movies\Add
        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var child = new MovieForm();

            do
            {
                //Showing form modally
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    _movies.Add(child.SelectedMovie);
                    UpdateUI();
                    return;
                } catch (InvalidOperationException ex)
                {
                    DisplayError("Movies must be unique.", "Add Failed");                    
                } catch (ArgumentException ex)
                {
                    DisplayError("You messed up developer.", "Add Failed");
                } catch (Exception ex)
                {
                    DisplayError(ex.Message, "Add Failed");

                    //Rethrow
                    //throw ex;
                    //throw;
                };
                
            } while (true);
        }
        
        private void OnMovieDelete ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            if (!Confirm($"Are you sure you want to delete '{movie.Title}'?", "Delete"))
                return;

            try
            {
                _movies.Remove(movie.Id);
                UpdateUI();
            } catch (Exception ex)
            {
                DisplayError(ex.Message, "Delete Failed");
            };            
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var child = new MovieForm();
            child.SelectedMovie = movie;

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;
                
                try
                {
                    Cursor = Cursors.WaitCursor;                    
                    _movies.Update(movie.Id, child.SelectedMovie);                    
                    System.Threading.Thread.Sleep(1000);
                    //Cursor = Cursors.Default;

                    UpdateUI();
                    return;                    
                } catch (Exception ex)
                {
                    //Cursor = Cursors.Default;
                    DisplayError(ex.Message, "Update Failed");
                } finally
                {
                    //Guaranteed to run
                    Cursor = Cursors.Default;
                };
            } while (true);
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutForm();

            about.ShowDialog();
        }
        #endregion

        #region Private Members

        private void UpdateUI ()
        {
            UpdateUI(false);
        }

        private void UpdateUI ( bool initialLoad )
        {
            //Get movies
            var movies = _movies.GetAll();

            //Extension methods - static methods on static classes
            // 1. Expose a static method as an instance method for discoverability
            // 2. Called like instance methods (on an instance)
            // 3. Compiler rewrites code to call static method on static class
            //Enumerable.Count(movies) == movies.Count()            
            if (initialLoad && 
                    //movies.Count() == 0)
                    //movies.FirstOrDefault() == null)            
                    !movies.Any())
            {
                if (Confirm("Do you want to seed some movies?", "Database Empty"))
                {
                    //SeedMovieDatabase.Seed(_movies);
                    _movies.Seed();
                    movies = _movies.GetAll();
                };
            };

            _lstMovies.Items.Clear();

            //Order movies by title, then by release year
            //Chain calls together
            //          movies.OrderBy(OrderByTitle());
            //  foreach item in source
            //      sortValue = func(item)
            //      compare sortValue to other values
            //var items = movies.OrderBy(OrderByTitle)
            //               .ThenBy(OrderByReleaseYear)
            var items = movies.OrderBy(x => x.Title)
                              .ThenBy(x => x.ReleaseYear)
                              .ToArray();
            //movies = movies.ThenBy();

            //Use Enumerable 
            //_lstMovies.Items.AddRange(Enumerable.ToArray(movies));
            _lstMovies.Items.AddRange(items);
            //foreach (var movie in movies)
            //    _lstMovies.Items.Add(movie);
        }

        private Movie GetSelectedMovie ()
        {
            //var allTextBoxes = Controls.OfType<TextBox>();
            //IEnumerable<Movie> temp = _lstMovies.SelectedItems.OfType<Movie>();

            return _lstMovies.SelectedItem as Movie;
        }

        private bool Confirm ( string message, string title )
        {
            DialogResult result = MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //private Movie _movie;
        private IMovieDatabase _movies = new Sql.SqlMovieDatabase(Program.GetConnectionString("AppDatabase"));
        #endregion        
    }
}