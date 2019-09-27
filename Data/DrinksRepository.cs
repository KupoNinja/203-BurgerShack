using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Data
{
    public class DrinksRepository
    {
        private readonly IDbConnection _db;

        public Drink Create(Drink drinkData)
        {
            var sql = @"INSERT INTO drink
            (id, name, description, price)
            VALUES
            (@Id, @Name, @Description, @Price);";
            var x = _db.Execute(sql, drinkData);

            return drinkData;
        }

        public IEnumerable<Drink> GetAll()
        {
            return _db.Query<Drink>("SELECT * FROM drinks");
        }

        public Drink GetDrinkByName(string name)
        {
            return _db.QueryFirstOrDefault<Drink>(
                "SELECT * FROM drinks WHERE name = @name",
                new { name } // Dapper requires all @prop to be an actual property on an object
            );
        }

        public Drink GetDrinkById(string drink)
        {
            return _db.QueryFirstOrDefault<Drink>(
                "SELECT * FROM drink WHERE id = @id",
                new { id } // Dapper requires all @prop to be an actual property on an object
            );
        }

        internal bool SaveDrink(Drink drink)
        {
            var nRows = _db.Execute(@"
                UPDATE sides SET
                name = @Name,
                description = @Description,
                price = @Price
                WHERE id = @Id
                ", drink);
            return nRows == 1;
        }

        internal bool DeleteDrink(string id)
        {
            var success = _db.Execute("DELETE FROM drink WHERE id = @id", new { id });
            if (success == 1)
            {
                return true;
            }
            return false;
        }

        public DrinksRepository(IDbConnection db)
        {
            _db = db;
        }

    }
}