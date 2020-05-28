namespace P06_Sneaking
{
    public class Enemy
    {
        public Enemy(char direction, int rowPosition, int colPostion)
        {
            this.Direction = direction;
            this.RowPostion = rowPosition;
            this.ColPosition = colPostion;
        }
        public char Direction { get; set; }
        public int RowPostion { get; set; }
        public int ColPosition { get; set; }
    }
}
