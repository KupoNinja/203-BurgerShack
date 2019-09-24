using System;
using System.Collections.Generic;
using System.Linq;
using BurgerShack.Data;
using BurgerShack.Models;

namespace BurgerShack.Services
{
    public class BurgersService
    {
        private readonly BurgersRepository _repo;
        private readonly FakeDb _fakeRepo;

        public Burger AddBurger(Burger burgerData)
        {
            var exists = _repo.GetAll().ToList().Find(b => b.Name == burgerData.Name);
            if (exists != null)
            {
                throw new Exception("This burger already exists.");
            }
            burgerData.Id = Guid.NewGuid().ToString();
            _repo.Create(burgerData);
            return burgerData;
        }

        public Burger EditBurger(Burger burgerData)
        {
            var burger = _fakeRepo.Burgers.Find(b => b.Id == burgerData.Id);
            if (burger == null) { throw new Exception("I DONT LIKE BAD ID's"); }
            burger.Name = burgerData.Name;
            burger.Description = burgerData.Description;
            burger.Price = burgerData.Price;
            return burger;
        }

        public Burger DeleteBurger(string id)
        {
            var burger = GetBurgerById(id);
            _fakeRepo.Burgers.Remove(burger);
            return burger;
        }

        public List<Burger> GetBurgers()
        {
            // if (_repo.Burgers.Count < 1) { throw new Exception("There are no burgers"); }
            return _repo.GetAll().ToList();
        }

        public Burger GetBurgerById(string id)
        {
            var burger = _fakeRepo.Burgers.Find(b => b.Id == id);
            if (burger == null) { throw new Exception("I DONT LIKE BAD ID's"); }
            return burger;
        }

        public BurgersService(FakeDb fakeRepo, BurgersRepository repo)
        {
            _fakeRepo = fakeRepo;
            _repo = repo;
        }
    }
}