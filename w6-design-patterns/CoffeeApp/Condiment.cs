using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp
{
    abstract class Condiment : Beverage
    {
        protected Beverage beverage;

        protected Condiment(Beverage beverage)
        {
            this.beverage = beverage;
        }

    }

    class Milk : Condiment
    {
        public int Quantity { get; set; }
        public Milk(Beverage beverage, int q = 1) : base(beverage)
        {
            Quantity = q;
        }

        public override string Make()
        {
            return this.beverage.Make() + " + milk";
        }

        public override decimal Price
        {
            get => 0.50m * Quantity + this.beverage.Price;
        }
    }

    class Cacao : Condiment
    {

        public Cacao(Beverage beverage) : base(beverage) { }
        
        public override string Make()
        {
            return this.beverage.Make() + " + cacao";
        }

        public override decimal Price
        {
            get => 0.25m + this.beverage.Price;
        }
    }

    public enum SyrupType { Caramel, Chocolate, Hazelnut }
    class Syrup : Condiment
    {
        private SyrupType _syrupType;
        public Syrup(Beverage beverage, SyrupType type) : base(beverage)
        {
            _syrupType = type;
        }
        public override string Make()
        {
            return this.beverage.Make() + $"+ {_syrupType} syrup ";
        }

        public override decimal Price
        {
            get => 0.55m + this.beverage.Price;
        }
    }
}
