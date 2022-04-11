using System;
using System.IO;
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

        //Note: Update and Insert functions return the number of rows
        //      updated, if -1 is a result that is added by these functions
        //      to indicate that there is already an entry in the table.


        //User statements
        public int saveUserAsync(user user)                                             //Creates or inserts user
        {
            user sameUsername = database.Table<user>()
                            .Where(element => element.username == user.username)
                            .FirstOrDefaultAsync().Result;

            if(sameUsername == null)                                        //Checks if database doesn't contain 
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
            } else
            {
                return -1;                                                  //Returns -1 only if user exists with same username
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
            day sameDay =  database.Table<day>()
                            .Where(element => element.userId == day.userId)
                            .Where(element => element.date == day.date)
                            .FirstOrDefaultAsync().Result;

            if(sameDay == null)
            {
                if (day.id != 0)
                {
                    // Update an existing day.
                    return database.UpdateAsync(day).Result;
                }
                else
                {
                    // Save a new day.
                    return database.InsertAsync(day).Result;
                }
            } else
            {
                return -1;
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
            foodItemEntry sameFoodItemEntry = database.Table<foodItemEntry>()
                            .Where(element => element.dayId == foodItemEntry.dayId)
                            .Where(element => element.foodItemId == foodItemEntry.foodItemId)
                            .Where(element => element.mealTypeId == foodItemEntry.mealTypeId)
                            .FirstOrDefaultAsync().Result;

            if(sameFoodItemEntry == null)
            {
                return database.InsertAsync(foodItemEntry).Result;
            } else
            {
                return -1;
            }
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
                // Update an existing mealType.
                return database.UpdateAsync(mealType).Result;
            }
            else
            {
                // Save a new mealType.
                return database.InsertAsync(mealType).Result;
            }
        }

        public mealType getMealTypeByFoodItemEntryAsync(foodItemEntry foodItemEntry)    //Returns individual mealType
        {
            return database.Table<mealType>()
                            .Where(element => element.id == foodItemEntry.mealTypeId)
                            .FirstOrDefaultAsync().Result;
        }

        public List<mealType> getAllMealTypesAsync()                                    //Gets all mealTypes
        {
            return database.Table<mealType>()
                            .ToListAsync().Result;
        }


        //FoodItem statements
        public int saveFoodItemAsync(foodItem foodItem)                                 //Creates or inserts foodItem
        {
            foodItem sameFoodItem = database.Table<foodItem>()
                            .Where(element => element.name.ToLower() == foodItem.name.ToLower())
                            .FirstOrDefaultAsync().Result;

            if(sameFoodItem == null)
            {
                if (foodItem.id != 0)
                {
                    // Update an existing foodItem.
                    return database.UpdateAsync(foodItem).Result;
                }
                else
                {
                    // Save a new foodItem.
                    return database.InsertAsync(foodItem).Result;
                }
            } else
            {
                return -1;
            }
        }

        public foodItem getFoodItemByIdAsync(int id)                                    //Returns individual foodItem by its id
        {
            return database.Table<foodItem>()
                            .Where(element => element.id == id)
                            .FirstOrDefaultAsync().Result;
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
