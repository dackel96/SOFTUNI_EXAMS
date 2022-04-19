using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;
        private string material;
        private int capacity;

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = new List<Fish>();
        }

        public List<Fish> Fish
        {
            get { return fish; }
            set { fish = value; }
        }

        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public int Count => fish.Count;
        public string AddFish(Fish fish)
        {
            if (string.IsNullOrEmpty(fish.FishType))
            {
                return "Invalid fish.";
            }

            if (fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (Fish.Count == capacity)
            {
                return "Fishing net is full.";
            }
            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight)
        {
            Fish removeThisFish = fish.FirstOrDefault(x => x.Weight == weight);
            return fish.Remove(removeThisFish);
        }
        public Fish GetFish(string fishType)
        {
            //??
            Fish getFish = fish.FirstOrDefault(x => x.FishType == fishType);
            return getFish;
        }
        public Fish GetBiggestFish()
        {
            Fish longestOne = fish.OrderByDescending(x => x.Length).FirstOrDefault();
            return longestOne;
        }
        public string Report()
        {
            // interpolirano
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {material}:");
            foreach (var fishy in fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(fishy.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
