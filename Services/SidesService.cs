using System;
using System.Collections.Generic;
using System.Linq;
using BurgerShack.Data;
using BurgerShack.Models;

namespace BurgerShack.Services
{
    public class SidesService
    {
        private SidesRepository _repo;

        public List<Side> GetSides()
        {
            return _repo.GetAll().ToList();
        }

        public Side GetSideById(string id)
        {
            var side = _repo.GetSideById(id);
            if (side == null) { throw new Exception("I DONT LIKE BAD ID's"); }
            return side;
        }

        public Side AddSide(Side sideData)
        {
            var exists = _repo.GetSideByName(sideData.Name);
            if (exists != null)
            {
                throw new Exception("This side already exists.");
            }
            sideData.Id = Guid.NewGuid().ToString();
            _repo.Create(sideData);
            return sideData;
        }

        public Side EditSide(Side sideData)
        {
            var side = _repo.GetSideById(sideData.Id);
            if (side == null) { throw new Exception("I DONT LIKE BAD ID's"); }
            side.Name = sideData.Name;
            side.Description = sideData.Description;
            side.Price = sideData.Price;
            bool success = _repo.SaveSide(side);
            if (!success)
            {
                throw new Exception("Nope I couldn't update the side.... Please Try Again Later, or now is probably fine");
            }

            return side;
        }

        public Side DeleteSide(string id)
        {
            var side = _repo.GetSideById(id);
            var deleted = _repo.DeleteSide(id);
            if (!deleted)
            {
                throw new Exception($"Unable to remove side at Id {id}");
            }

            return side;
        }

        public SidesService(SidesRepository repo)
        {
            _repo = repo;
        }
    }
}