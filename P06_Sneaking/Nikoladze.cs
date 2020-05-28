namespace P06_Sneaking
{
    public class Nikoladze
    {
        public Nikoladze(int rowPosition, int colPosition)
        {
            this.RowPosition = rowPosition;
            this.ColPosition = colPosition;
            this.Label = 'N';
        }
        public int RowPosition { get; set; }
        public int ColPosition { get; set; }
        public char Label { get; set; }
    }
}
