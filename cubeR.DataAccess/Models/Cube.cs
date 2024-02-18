namespace cubeR.DataAccess
{
    public class Cube
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty; 

        public int SidesCount { get; set; }

        public int PiecesCount { get; set; }

        public List<Solve> Solves { get; set; } = new List<Solve>();
    }
}
