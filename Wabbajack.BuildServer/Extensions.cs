﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Wabbajack.BuildServer
{
    public static class Extensions
    {
        public static async Task<T> FindOneAsync<T>(this IMongoCollection<T> coll, Expression<Func<T, bool>> expr)
        {
            return (await coll.AsQueryable().Where(expr).Take(1).ToListAsync()).FirstOrDefault();
        }
    }
}
