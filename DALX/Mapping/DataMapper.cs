using DALX.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DALX.Mapping
{
    public class DataMapper<TEntity> where TEntity : class, new()
    {
        public TEntity Map(DataRow row)
        {
            TEntity entity = new TEntity();
            return Map(row, entity);
        }

        public TEntity Map(DataRow row, TEntity entity)
        {
            
            var properties = (entity.GetType()).GetProperties()
                                              .Where(x => x.GetCustomAttributes(typeof(DataMapping), true).Any())
                                              .ToList();
            foreach (var prop in properties)
            {
                PropertyMapHelper.Map(entity.GetType(), row, prop, entity);
            }

            return entity;
        }

        public IEnumerable<TEntity> Map(DataTable table)
        {
           
            List<TEntity> entities = new List<TEntity>();
            foreach (DataRow row in table.Rows)
            {
                TEntity entity = new TEntity();

                Map(row, entity);
                entities.Add(entity);
            }

            return entities;
        }
    }
}
