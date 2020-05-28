namespace P03_JediGalaxy
{
   public class Evil
    {
        private int row;
        private int col;

        public Evil(int[] coordinates)
        {   
            this.row = coordinates[0];
            this.col = coordinates[1];
        }
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
            this.col--;
        }
        public void Destroy(Galaxy galaxy)
        {
            galaxy.ChangeCellToZero(this.row, this.col);
        }
    }
}
