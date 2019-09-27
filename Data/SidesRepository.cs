using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Data
{
    public class SidesRepository
    {
        private readonly IDbConnection _db;

        public Side Create(Side sideData)
        {
            var sql = @"INSERT INTO sides
            (id, name, description, price)
            VALUES
            (@Id, @Name, @Description, @Price);";
            var x = _db.Execute(sql, sideData);

            return sideData;
        }

        public IEnumerable<Side> GetAll()
        {
            return _db.Query<Side>("SELECT * FROM sides");
        }

        public Side GetSideByName(string name)
        {
            return _db.QueryFirstOrDefault<Side>(
                "SELECT * FROM sides WHERE name = @name",
                new { name } // Dapper requires all @prop to be an actual property on an object
            );
        }

        public Side GetSideById(string id)
        {
            return _db.QueryFirstOrDefault<Side>(
                "SELECT * FROM sides WHERE id = @id",
                new { id } // Dapper requires all @prop to be an actual property on an object
            );
        }

        internal bool SaveSide(Side side)
        {
            var nRows = _db.Execute(@"
                UPDATE sides SET
                name = @Name,
                description = @Description,
                price = @Price
                WHERE id = @Id
                ", side);
            return nRows == 1;
        }

        internal bool DeleteSide(string id)
        {
            var success = _db.Execute("DELETE FROM sides WHERE id = @id", new { id });
            if (success == 1)
            {
                return true;
            }
            return false;
        }

        public SidesRepository(IDbConnection db)
        {
            _db = db;
        }

    }
}