using System;

namespace Zoo.Models
{
    public abstract class Animal
    {
        private int energy;

        public abstract string Name { get; set; }

        public abstract int MaxEnergy { get; }

        public virtual int CurrentEnergy
        {
            get => energy;
            set
            {
                energy = Math.Clamp(value, 0, MaxEnergy);
            }
        }

        public abstract void Eat();

        public abstract void UseEnergy();
    }
}
