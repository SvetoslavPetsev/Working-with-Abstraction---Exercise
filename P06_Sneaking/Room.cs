namespace P06_Sneaking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Room
    {
        private int row;
        private int col;
        public Room(int n)
        {
            this.row = n;
            this.Field = new char[this.row][];
            this.EnemyList = new List<Enemy>();
            this.Sam = new Sam(0, 0);
            this.Nikoladze = new Nikoladze(0, 0);
        }
        public char[][] Field { get; private set; }
        public List<Enemy> EnemyList { get; set; }
        public Sam Sam { get; set; }
        public Nikoladze Nikoladze { get; set; }

        public void CreateField()
        {
            for (int i = 0; i < this.row; i++)
            {
                char[] rowContent = Console.ReadLine().ToCharArray();
                this.Field[i] = rowContent;
                this.col = rowContent.Length;
                for (int j = 0; j < this.col; j++)
                {
                    if (rowContent[j] == 'S')
                    {
                        this.Sam.RowPosition = i;
                        this.Sam.ColPosition = j;
                        this.Sam.Label = 'S';
                    }
                    else if (rowContent[j] == 'N')
                    {
                        this.Nikoladze.RowPosition = i;
                        this.Nikoladze.ColPosition = j;
                    }
                    else if (rowContent[j] == 'b' || rowContent[j] == 'd')
                    {
                        char direction = rowContent[j];
                        this.EnemyList.Add(new Enemy(direction, i, j));
                    }
                }
            }
        }
        public void MoveEnemy()
        {
            for (int i = 0; i < this.EnemyList.Count; i++)
            {

                if (this.EnemyList[i].Direction == 'b' && this.EnemyList[i].ColPosition < this.col - 1)
                {
                    this.EnemyList[i].ColPosition++;
                    continue;
                }
                else if (this.EnemyList[i].Direction == 'd' && this.EnemyList[i].ColPosition > 0)
                {
                    this.EnemyList[i].ColPosition--;
                    continue;
                }
                if (this.EnemyList[i].Direction == 'b' && this.EnemyList[i].ColPosition == this.col - 1)
                {
                    this.EnemyList[i].Direction = 'd';
                }
                else if (this.EnemyList[i].Direction == 'd' && this.EnemyList[i].ColPosition == 0)
                {
                    this.EnemyList[i].Direction = 'b';
                }
                
            }
        }
        public void MovePlayer(char command)
        {
            int oldRow = this.Sam.RowPosition;
            int oldCol = this.Sam.ColPosition;
            if (command == 'W')
            {
                return;
            }
            else if (command == 'U')
            {
                this.Sam.RowPosition--;
            }
            else if (command == 'D')
            {
                this.Sam.RowPosition++;
            }
            else if (command == 'L')
            {
                this.Sam.ColPosition--;
            }
            else if (command == 'R')
            {
                this.Sam.ColPosition++;
            }
            int newRow = this.Sam.RowPosition;
            int newCol = this.Sam.ColPosition;
            var enemy = this.EnemyList.FirstOrDefault(x => x.RowPostion == newRow && x.ColPosition == newCol);
            this.EnemyList.Remove(enemy);
        }
        public bool IsNikoladzeKilled()
        {

            return  this.Nikoladze.RowPosition == this.Sam.RowPosition;
        }
        public bool IsSamKilled()
        {
            foreach (var enemy in this.EnemyList.Where(x => x.RowPostion == this.Sam.RowPosition))
            {
                if (enemy.Direction == 'b' && this.Sam.ColPosition > enemy.ColPosition)
                {
                    return true;
                }
                else if (enemy.Direction == 'd' && this.Sam.ColPosition < enemy.ColPosition)
                {
                    return true;
                }
            }
            return false;
        }
        public void EndProgramNikoladze()
        {
            this.Nikoladze.Label = 'X';
            Console.WriteLine("Nikoladze killed!");
            RefreshField();
            PrintField();
        }
        public void EndProgramSam()
        {
            this.Sam.Label = 'X';
            Console.WriteLine($"Sam died at {this.Sam.RowPosition}, {this.Sam.ColPosition}");
            RefreshField();
            PrintField();
        }
        public void RefreshField()
        {
            for (int i = 0; i < this.Field.Length; i++)
            {
                char[] curr = this.Field[i];
                for (int j = 0; j < curr.Length; j++)
                {
                    this.Field[i][j] = '.';
                }
            }
            this.Field[Nikoladze.RowPosition][Nikoladze.ColPosition] = this.Nikoladze.Label;
            this.Field[Sam.RowPosition][Sam.ColPosition] = this.Sam.Label;
            foreach (var enemy in this.EnemyList)
            {
                this.Field[enemy.RowPostion][enemy.ColPosition] = enemy.Direction;
            }
        }
        public void PrintField()
        {
            foreach (var row in this.Field)
            {
                Console.WriteLine(new string(row));
            }
        }
    }
}
