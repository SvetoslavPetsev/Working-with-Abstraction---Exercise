namespace P05_GreedyTimes
{
    using System;
    using System.Collections.Generic;

    public class Engine
    { 
        private Bag bag;
        private readonly List<Item> goldList = new List<Item>();
        private readonly List<Item> gemList = new List<Item>();
        private readonly List<Item> cashList = new List<Item>();
        public void Run()
        {
            CreateBag();
            AddItems();
            Output();
        }
        public void CreateBag()
        {
            long capacity = long.Parse(Console.ReadLine());

            this.bag = new Bag(capacity);
        }
        public void AddItems()
        {
            string input = Console.ReadLine();
            string[] content = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < content.Length; i += 2)
            {
                string name = content[i];
                long quantity = long.Parse(content[i + 1]);

                if (name.Length == 3)
                {
                    Item newCash = new Item(name, quantity);
                    this.cashList.Add(newCash);
                }
                else if (name.Length >= 4 && name.ToLower().EndsWith("gem"))
                {
                    Item newGem = new Item(name, quantity);
                    this.gemList.Add(newGem);
                }
                else if (name.ToLower().Equals("gold"))
                {
                    Item newGold = new Item(name, quantity);
                    this.goldList.Add(newGold);
                }
            }

            bag.AddGold(goldList);
            bag.AddGems(gemList);
            bag.AddCash(cashList);
        }
        public void Output()
        {
            Console.WriteLine(bag.ToString());
        }
    }
}
