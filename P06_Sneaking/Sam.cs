namespace P06_Sneaking
{
    public class Sam
    {
        public Sam(int rowPosition, int colPosition)
        {
            this.RowPosition = rowPosition;
            this.ColPosition = colPosition;
            this.Label = 'S';
        }
        public int RowPosition { get; set; }
        public int ColPosition { get; set; }
        public char Label { get; set; }
    }
}
