using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Zoo.Models;

namespace Zoo.Services
{
    public class AnimalService
    {
        public ObservableCollection<Animal> animals;

        public AnimalService()
        {
            animals = new ObservableCollection<Animal>();
        }

        public Animal FindAnimalById(int id)
        {
            return animals.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> FindAnimalsByType<T>() where T : Animal
        {
            return animals.Where(x => x.GetType() == typeof(T)).Cast<T>();
        }

        public ObservableCollection<Animal> GetAnimals()
        {
            return animals;
        }

        public void AddAnimal<T>(T animal) where T : Animal
        {
            animals.Add(animal);
        }
    }
}
