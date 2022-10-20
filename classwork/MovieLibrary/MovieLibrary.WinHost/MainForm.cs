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

        //Called to handle Movies\Add
        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var child = new MovieForm();

            //Showing form modally
            if (child.ShowDialog(this) != DialogResult.OK)
                return;            

            //TODO: Save this off
            _movie = child.SelectedMovie;
            UpdateUI();
        }
        
        private void OnMovieDelete ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            if (!Confirm($"Are you sure you want to delete '{movie.Title}'?", "Delete"))
                return;

            //TODO: Implement Delete
            _movie = null;
            UpdateUI();
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var child = new MovieForm();
            child.SelectedMovie = movie;

            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //TODO: Save this off
            _movie = child.SelectedMovie;
            UpdateUI();
        }

        #region Private Members

        private void UpdateUI ()
        {
            //Get movies
            var movies = _movies.GetAll();
            //movies[0] = new Movie();
            movies[0].Title = "New Movie";

            _lstMovies.Items.Clear();
            _lstMovies.Items.AddRange(movies);

            //if (_movie != null)
            //{
            //    _lstMovies.Items.Add(_movie);
            //};
        }

        private Movie GetSelectedMovie ()
        {
            return _movie;
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

        private Movie _movie;
        private MovieDatabase _movies = new MovieDatabase();
        #endregion

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutForm();

            about.ShowDialog();
        }
    }
}