namespace MusicStore.Web.Helpers
{
    public static class DateHelper
    {
        public static int GetSeconds(int minutes, int seconds)
        {
            return minutes * 60 + seconds;
        }
    }
}