namespace Zoo.Models
{
    public class Elephant : Animal
    {
        public override int CurrentEnergy => 10;

        public override int MaxEnergy => 1000;

        public override string Name { get; set; }

        public Elephant(string name)
        {
            Name = name;
        }

        public override void Eat()
        {
            CurrentEnergy += 1250;
        }

        public override void UseEnergy()
        {
            CurrentEnergy -= 5;
        }
    }
}
