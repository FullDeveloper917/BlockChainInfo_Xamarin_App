using System;
namespace DataGridApp.Models
{
    public class Crypto
    {
        private string name;
        private long marketCap;
        private float price;
        private long volume;
        private long cirSupply;
        private string change;

        public Crypto()
        {
            this.name = "";
            this.marketCap = 0;
            this.price = 0.0f;
            this.volume = 0;
            this.cirSupply = 0;
            this.change = "";
        }

        public Crypto(string name, long marketCap, float price, long volume, long cirSupply, string change)
        {
            this.name = name;
            this.marketCap = marketCap;
            this.price = price;
            this.volume = volume;
            this.cirSupply = cirSupply;
            this.change = change;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public long MarketCap
        {
            get => marketCap;
            set => marketCap = value;
        }

        public float Price
        {
            get => price;
            set => price = value;
        }

        public long Volume
        {
            get => volume;
            set => volume = value;
        }

        public long CirSupply
        {
            get => cirSupply;
            set => cirSupply = value;
        }

        public string Change
        {
            get => change;
            set => change = value;
        }

    }
}
