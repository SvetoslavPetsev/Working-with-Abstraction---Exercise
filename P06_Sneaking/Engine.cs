namespace P06_Sneaking
{
    using System;

    public class Engine
    {
        private Room room;

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            this.room = new Room(n);
            this.room.CreateField();

            char[] commands = Console.ReadLine().ToCharArray();

            for (int i = 0; i < commands.Length; i++)
            {
                char currCommand = commands[i];

                this.room.MoveEnemy();

                if (this.room.IsSamKilled())
                {
                    this.room.EndProgramSam();
                    break;
                }

                this.room.MovePlayer(currCommand);

                if (this.room.IsNikoladzeKilled())
                {
                    this.room.EndProgramNikoladze();
                    break;
                }
            }

        }
    }
}
