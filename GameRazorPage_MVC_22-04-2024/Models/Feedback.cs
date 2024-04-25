using System.Diagnostics.CodeAnalysis;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameRazorPage_MVC_22_04_2024.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int Rating { get; set; }
        public DateTime LastUpdateTime { get; set; } 
        public int VideoGameId { get; set; }
       public Feedback() {}
        public VideoGame? VideoGame { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Text} - {Rating} - {LastUpdateTime}";
        }
    }
}
