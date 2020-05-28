namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] galaxyDimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Galaxy galaxy = new Galaxy(galaxyDimestions[0], galaxyDimestions[1]);
            long sum = 0;
            string command;
            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoStartPoint = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                Ivo ivo = new Ivo(ivoStartPoint);

                int[] evilStartPoint = Console
                    .ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                Evil evil = new Evil(evilStartPoint);

                while (evil.IsMoveAcross() && ivo.IsMoveAcross())
                {
                    if (evil.IsOnTheGalaxy(galaxy))
                    {
                        evil.Destroy(galaxy);
                    }

                    evil.Move();

                    if (ivo.IsOnTheGalaxy(galaxy))
                    {
                        sum += ivo.GetValue(galaxy);
                    }

                    ivo.Move();
                }
            }
            Console.WriteLine(sum);
        }
    }
}
