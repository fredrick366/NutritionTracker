using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using SQLite;
using NutritionTracker.Models;

namespace NutritionTracker.Data
{
    public class databaseManager
    {
        readonly SQLiteAsyncConnection database;

        public databaseManager(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<day>().Wait();
            database.CreateTableAsync<foodItem>().Wait();
            database.CreateTableAsync<foodItemEntry>().Wait();
            database.CreateTableAsync<mealType>().Wait();
            database.CreateTableAsync<user>().Wait();
        }

        public int saveUserAsync(user user)
        {
            user.password = user.getPasswordHash();
            if (user.id != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(user).Result;
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(user).Result;
            }
        }
        public user getUserByLoginAsync(string username, string passwordHash)
        {
            return database.Table<user>()
                            .Where(element => element.username == username)
                            .Where(element => element.password == passwordHash)
                            .FirstOrDefaultAsync().Result;
        }
    }
}
