namespace GameTournamentAPI2._0.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Description { get; set } = string.Empty;
        public int MaxPlayers { get; set; }
        
        public int DateTime { get; set; }
        
    }
}
