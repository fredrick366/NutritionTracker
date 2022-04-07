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

        //User statements
        public int saveUserAsync(user user)                                             //Creates or inserts user
        {
            user.password = user.getPasswordHash();
            if (user.id != 0)
            {
                // Update an existing user.
                return database.UpdateAsync(user).Result;
            }
            else
            {
                // Save a new user.
                return database.InsertAsync(user).Result;
            }
        }

        public user getUserByLoginAsync(string username, string password)               //Takes in plaintext username and password straight from text fields
        {
            user user = new user();
            string passwordHash = user.getPasswordHash(password);           //Hashes password to check against stored hashed password

            return database.Table<user>()
                            .Where(element => element.username == username)
                            .Where(element => element.password == passwordHash)
                            .FirstOrDefaultAsync().Result;
        }


        //Day statements
        public int saveDayAsync(day day)                                                //Creates or inserts day
        {
            if (day.id != 0)
            {
                // Update an existing user.
                return database.UpdateAsync(day).Result;
            }
            else
            {
                // Save a new user.
                return database.InsertAsync(day).Result;
            }
        }

        public List<day> getDaysByUserAsync(user user)                                  //Returns list of days associated with user
        {
            return database.Table<day>()
                            .Where(element => element.userId == user.id)
                            .ToListAsync().Result;
        }

        public int deleteDayAsync(day day)                                              //Deletes individual day record
        {
            return database.Table<day>()
                            .Where(element => element.id == day.id)
                            .DeleteAsync().Result;
        }


        //FoodItemEntry statements
        public int saveFoodItemEntryAsync(foodItemEntry foodItemEntry)                  //Inserts new foodItemEntry
        {
            return database.InsertAsync(foodItemEntry).Result;
        }

        public List<foodItemEntry> getFoodItemEntrysByDayAsync(day day)                 //Returns list of foodItemEntries associated with day
        {
            return database.Table<foodItemEntry>()
                            .Where(element => element.dayId == day.id)
                            .ToListAsync().Result;
        }

        public int deleteFoodItemEntryAsync(foodItemEntry foodItemEntry)                //Deletes individual foodItemEntry record
        {
            return database.Table<foodItemEntry>()
                            .Where(element => element.dayId == foodItemEntry.dayId)
                            .Where(element => element.foodItemId == foodItemEntry.foodItemId)
                            .DeleteAsync().Result;
        }


        //MealType statements
        public int saveMealTypeAsync(mealType mealType)                                 //Creates or inserts mealType
        {
            if (mealType.id != 0)
            {
                // Update an existing user.
                return database.UpdateAsync(mealType).Result;
            }
            else
            {
                // Save a new user.
                return database.InsertAsync(mealType).Result;
            }
        }

        public mealType getMealTypeByFoodItemEntryAsync(foodItemEntry foodItemEntry)    //Returns individual mealType
        {
            return database.Table<mealType>()
                            .Where(element => element.id == foodItemEntry.mealTypeId)
                            .FirstOrDefaultAsync().Result;
        }

        public List<mealType> getAllMealTypesAsync()                                    //Deletes individual mealType record
        {
            return database.Table<mealType>()
                            .ToListAsync().Result;
        }


        //FoodItem statements
        public int saveFoodItemAsync(foodItem foodItem)                                 //Creates or inserts foodItem
        {
            if (foodItem.id != 0)
            {
                // Update an existing user.
                return database.UpdateAsync(foodItem).Result;
            }
            else
            {
                // Save a new user.
                return database.InsertAsync(foodItem).Result;
            }
        }

        public foodItem getFoodItemByFoodItemEntryAsync(foodItemEntry foodItemEntry)    //Returns individual foodItem associated with foodItemEntry
        {
            return database.Table<foodItem>()
                            .Where(element => element.id == foodItemEntry.foodItemId)
                            .FirstOrDefaultAsync().Result;
        }

        public List<foodItem> getFoodItemByNameAsync(string name)                       //Returns list of foodItems by name
        {
            return database.Table<foodItem>()
                            .Where(element => element.name.ToLower().Contains(name.ToLower()))
                            .ToListAsync().Result;
        }

        public int deleteFoodItemAsync(foodItem foodItem)                               //Deletes individual foodItem record
        {
            return database.Table<foodItem>()
                            .Where(element => element.id == foodItem.id)
                            .DeleteAsync().Result;
        }
    }
}
