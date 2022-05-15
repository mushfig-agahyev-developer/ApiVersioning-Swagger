using ApiProjectModul.AppDataAccessLayer;
using ApiProjectModul.Exteensions;
using ApiProjectModul.Models;
using ApiProjectModul.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace ApiProjectModul.DataBaseGenerates
{
    public class DataBaseGenerate : IDataBaseGenerate
    {
        private readonly AppDataBase _db;

        public DataBaseGenerate(AppDataBase appDataBase)
        {
            _db = appDataBase;
        }

        public IQueryable<Composition> GetAll(QueryParameters queryParameters)
        {
            IQueryable<Composition> _allItems = _db.Compositions.OrderBy(queryParameters.OrderBy, true);
            IQueryable<Composition> compositions = _db.Compositions.OrderBy("Type", "asc");
            var hhh1 = queryParameters.OrderBy;
            var  hhh2 = queryParameters.IsDescending();

            if (queryParameters.HasQuery())
            {
                _allItems = _allItems
                    .Where(x => x.Name.ToLowerInvariant().Contains(queryParameters.Query.ToLowerInvariant()));
            }

            return _allItems
                .Skip(queryParameters.PageCount * (queryParameters.Page - 1))
                .Take(queryParameters.PageCount);
        }

        public Composition GetSingle(int id)
        {
            return _db.Compositions.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Composition item)
        {
            _db.Compositions.Add(item);
        }

        public void Delete(int id)
        {
            Composition foodItem = GetSingle(id);
            _db.Compositions.Remove(foodItem);
        }

        public Composition Update(int id, Composition item)
        {
            _db.Compositions.Update(item);
            return item;
        }
        public int Count()
        {
            return _db.Compositions.Count();
        }

        public bool Save()
        {
            var mmm = _db.SaveChanges();
            return (_db.SaveChanges() >= 0);
        }

        public ICollection<Composition> GetRandomMeal()
        {
            List<Composition> toReturn = new List<Composition>();

            toReturn.Add(GetRandomItem("Starter"));
            toReturn.Add(GetRandomItem("Main"));
            toReturn.Add(GetRandomItem("Dessert"));

            return toReturn;
        }

        private Composition GetRandomItem(string type)
        {
            return _db.Compositions
                .Where(x => x.Type == type)
                .OrderBy(o => Guid.NewGuid())
                .FirstOrDefault();
        }
    }
}
