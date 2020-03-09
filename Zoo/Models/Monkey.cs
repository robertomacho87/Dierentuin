namespace Zoo.Models
{
    public class Monkey : Animal
    {
        public override int CurrentEnergy => 20;

        public override int MaxEnergy => 2000;

        public override string Name { get; set; }

        public Monkey(string name)
        {
            Name = name;
        }

        public override void Eat()
        {
            CurrentEnergy += 250;
        }

        public override void UseEnergy()
        {
            CurrentEnergy -= 2;
        }
    }
}
