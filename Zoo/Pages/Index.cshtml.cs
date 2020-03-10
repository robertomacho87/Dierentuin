using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading;
using Zoo.Models;
using Zoo.Services;

namespace Zoo.Pages
{
    public class IndexModel : PageModel
    {
        public ObservableCollection<Animal> animals;

        private readonly ILogger<IndexModel> _logger;
        private readonly AnimalService _animalService;
        private Timer timer;

        public IndexModel(ILogger<IndexModel> logger, AnimalService animalService)
        {
            _logger = logger;
            _animalService = animalService;
            animals = _animalService.GetAnimals();
        }

        public void OnGet()
        {
            animals.CollectionChanged += OnCollectionChanged;
            StartTimer();
        }

        public void OnPostAdd(string type, string name)
        {
            if (name is null)
            {
                return;
            }
    
            switch (type)
            {
                case "monkey":
                    _animalService.AddAnimal(new Monkey(name));
                    break;

                case "lion":
                    _animalService.AddAnimal(new Lion(name));
                    break;

                case "elephant":
                    _animalService.AddAnimal(new Elephant(name));
                    break;
            }
        }

        public void OnPostFeed(string type)
        {
            switch (type)
            {
                case "all":
                    foreach(Animal animal in _animalService.GetAnimals())
                    {
                        animal.Eat();
                    }
                    break;

                case "monkey":
                    foreach(Monkey monkey in _animalService.FindAnimalsByType<Monkey>())
                    {
                        monkey.Eat();
                    }
                    break;

                case "lion":
                    foreach (Lion lion in _animalService.FindAnimalsByType<Lion>())
                    {
                        lion.Eat();
                    }
                    break;

                case "elephant":
                    foreach (Elephant elephant in _animalService.FindAnimalsByType<Elephant>())
                    {
                        elephant.Eat();
                    }
                    break;
            }
        }

        public void StartTimer()
        {
            timer = new Timer(UseEnergy, null, 10, 500);
        }

        public void UseEnergy(object _)
        {
            foreach(Animal animal in animals)
            {
                animal.UseEnergy();
            }
        }

        public void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            Debug.WriteLine($"item: {args.Action} + {animals.Count}");
        }
    }
}
