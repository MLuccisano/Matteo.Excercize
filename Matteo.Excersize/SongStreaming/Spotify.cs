namespace SongStreaming
{
    public sealed class Spotify : StreamingPlatform
    {

        public Spotify()
        {
            files = new SpotifyMusic[] {
                new SpotifyMusic(){ title ="Back to Black", Color = System.ConsoleColor.Blue},
                new SpotifyMusic(){ title ="Highway to Hell",Color = System.ConsoleColor.Cyan},
                new SpotifyMusic(){ title ="Nothing Else Matters",Color = System.ConsoleColor.Green},
                new SpotifyMusic(){ title ="Fear of the Dark",Color = System.ConsoleColor.Yellow}

                };
            totalTacks = files.Length;
            multimedia = "song";
        }
        private class SpotifyMusic : Music
        {
            public SpotifyMusic()
            {
            }
        }
    }

}
