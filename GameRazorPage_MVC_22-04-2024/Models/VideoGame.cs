namespace GameRazorPage_MVC_22_04_2024.Models
{
    public class VideoGame
    {
        public int Id { get; set; }
        public string Title {  get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Rate { get; set; }
        public int CopiesSold {  get; set; }

        public VideoGame() { }

        public override string ToString()
        {
            return $"{Id} - {Title} - {Description} - {Price} - {ReleaseDate} - {Rate} - {CopiesSold}";
        }
    }
}
