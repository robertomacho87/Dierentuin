namespace Zoo.Models
{
    public class Lion : Animal
    {
        public override int CurrentEnergy => 10;

        public override int MaxEnergy => 1000;

        public override string Name { get; set; }

        public Lion(string name)
        {
            Name = name;
        }

        public override void Eat()
        {
            CurrentEnergy += 625;
        }

        public override void UseEnergy()
        {
            CurrentEnergy -= 10;
        }
    }
}
