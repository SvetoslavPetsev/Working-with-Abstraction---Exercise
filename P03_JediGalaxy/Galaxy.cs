namespace P03_JediGalaxy
{
    public class Galaxy
    {
        private int[,] matrix;
        public int MaxRow { get; private set; }
        public int MaxCol { get; private set; }
        public Galaxy(int row, int col)
        {
            this.MaxRow = row;
            this.MaxCol = col;
            this.matrix = new int[row, col];
            FillMatrix();
        }

        public void FillMatrix()
        {
            int value = 0;
            for (int i = 0; i < this.MaxRow; i++)
            {
                for (int j = 0; j < this.MaxCol; j++)
                {
                    this.matrix[i, j] = value++;
                }
            }
        }
        public void ChangeCellToZero(int row, int col)
        {
            this.matrix[row, col] = 0;
        }
        public int GetCellValue(int row, int col)
        {
            return this.matrix[row, col];
        }
    }
}
