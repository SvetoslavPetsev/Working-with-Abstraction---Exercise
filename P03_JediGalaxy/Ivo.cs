namespace P03_JediGalaxy
{
  public class Ivo
    {      
        private int row;
        private int col;

        public Ivo(int[] coordinates)
        {            
            this.row = coordinates[0];
            this.col = coordinates[1];
        }

        public long Value { get; private set; }
        public bool IsMoveAcross()
        {
            return this.row >= 0;
        }
        public bool IsOnTheGalaxy(Galaxy galaxy)
        {
            return this.row >= 0 && this.row < galaxy.MaxRow && this.col >= 0 && this.col < galaxy.MaxCol;
        }
        public void Move()
        {
            this.row--;
            this.col++;
        }
        public long GetValue(Galaxy galaxy)
        {
            return this.Value = galaxy.GetCellValue(this.row, this.col);
        }
    }
}
