namespace P05_GreedyTimes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Bag
    {
        private long capacity;
        public Bag(long capacity)
        {
            this.capacity = capacity;
            this.Gold = new List<Item>();
            this.Gem = new List<Item>();
            this.Cash = new List<Item>();
        }
        public List<Item> Gold { get; private set; }
        public List<Item> Gem { get; private set; }
        public List<Item> Cash { get; private set; }

        public bool HaveCapacity(long quantity)
        {
            return this.capacity - quantity >= 0;
        }
        public bool RespondQuantityRule(string itemType, long quantity)
        {
            if (itemType == "Gem")
            {
                return quantity + this.Gem.Sum(x => x.Quantity) >= this.Cash.Sum(x => x.Quantity)
                    && quantity + this.Gem.Sum(x => x.Quantity) <= this.Gold.Sum(x => x.Quantity)
                    && this.Gold.Count > 0;
            }
            else if (itemType == "Cash")
            {
                return quantity + this.Cash.Sum(x => x.Quantity) <= this.Gem.Sum(x => x.Quantity) 
                    && this.Gem.Count > 0;
            }
            return false;
        }
        public void AddGold(List<Item> goldList)
        {
            foreach (var currGold in goldList.OrderByDescending(x => x.Quantity))
            {
                if (HaveCapacity(currGold.Quantity))
                {
                    if (this.Gold.Any(x => x.Name == currGold.Name))
                    {
                        this.Gold.FirstOrDefault(x => x.Name == currGold.Name).Quantity += currGold.Quantity;
                    }
                    else
                    {
                        this.Gold.Add(currGold);
                    }
                    ReduceCapacity(currGold.Quantity);
                }
            }
        }
        public void AddGems(List<Item> gemList)
        {
            foreach (var currGem in gemList.OrderByDescending(x => x.Quantity))
            {
                if (HaveCapacity(currGem.Quantity)
                    && RespondQuantityRule("Gem", currGem.Quantity))
                {
                    if (this.Gem.Any(x => x.Name == currGem.Name))
                    {
                        this.Gem.FirstOrDefault(x => x.Name == currGem.Name).Quantity += currGem.Quantity;
                    }
                    else
                    {
                        this.Gem.Add(currGem);
                    }
                    ReduceCapacity(currGem.Quantity);
                }
            }
        }
        public void AddCash(List<Item> cashList)
        {
            foreach (var currCash in cashList.OrderByDescending(x => x.Quantity))
            {
                if (HaveCapacity(currCash.Quantity)
                    && RespondQuantityRule("Cash", currCash.Quantity))
                {
                    if (this.Cash.Any(x => x.Name == currCash.Name))
                    {
                        this.Cash.FirstOrDefault(x => x.Name == currCash.Name).Quantity += currCash.Quantity;
                    }
                    else
                    {
                        this.Cash.Add(currCash);
                    }
                    ReduceCapacity(currCash.Quantity);
                }
            }
        }
        public void ReduceCapacity(long quantity)
        {
            this.capacity -= quantity;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (this.Gold.Count > 0)
            {
                sb.AppendLine($"<Gold> ${this.Gold.Sum(x => x.Quantity)}");
                foreach (var gold in this.Gold
                    .OrderByDescending(x => x.Name)
                    .ThenBy(y => y.Quantity))
                {
                    sb.AppendLine($"##{gold.Name} - {gold.Quantity}");
                }
            }

            if (this.Gem.Count > 0)
            {
                sb.AppendLine($"<Gem> ${this.Gem.Sum(x => x.Quantity)}");
                foreach (var gem in this.Gem
                    .OrderByDescending(x => x.Name)
                    .ThenBy(y => y.Quantity))
                {
                    sb.AppendLine($"##{gem.Name} - {gem.Quantity}");
                }
            }

            if (this.Cash.Count > 0)
            {
                sb.AppendLine($"<Cash> ${this.Cash.Sum(x => x.Quantity)}");
                foreach (var cash in this.Cash
                    .OrderByDescending(x => x.Name)
                    .ThenBy(y => y.Quantity))
                {
                    sb.AppendLine($"##{cash.Name} - {cash.Quantity}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
