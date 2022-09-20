namespace MovieLibrary
{    
    /// <summary>Represents a movie.</summary>
    public class Movie
    {
        public string title = "";
        public string description = "";
        
        public int runLength = 0; //in minutes
        public int releaseYear = 1900;
        public string rating = "";
        public bool isClassic = false;
    }
}