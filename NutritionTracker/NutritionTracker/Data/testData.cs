using System;
using System.Collections.Generic;
using System.Text;
using NutritionTracker.Models;

namespace NutritionTracker.Data
{
    class testData
    {
        public List<day> createDays()
        {
            List<day> returnData = new List<day>();

            returnData.Add(new day(1, new DateTime(2022, 4, 4, 0, 0, 0)));
            returnData.Add(new day(1, new DateTime(2022, 4, 5, 0, 0, 0)));
            returnData.Add(new day(1, new DateTime(2022, 4, 6, 0, 0, 0)));
            returnData.Add(new day(1, new DateTime(2022, 4, 7, 0, 0, 0)));
            returnData.Add(new day(1, new DateTime(2022, 4, 8, 0, 0, 0)));

            return returnData;
        }

        public List<foodItem> createFoodItems()
        {
            List<foodItem> returnData = new List<foodItem>();

            returnData.Add(new foodItem("apples", 218));
            returnData.Add(new foodItem("oranges", 197));
            returnData.Add(new foodItem("bread", 1109));
            returnData.Add(new foodItem("red wine", 356));
            returnData.Add(new foodItem("walnuts", 2736));
            returnData.Add(new foodItem("cashews", 2314));
            returnData.Add(new foodItem("pistachios", 2351));
            returnData.Add(new foodItem("broccoli", 146));
            returnData.Add(new foodItem("potatoes", 322));
            returnData.Add(new foodItem("chickpeas", 1523));
            returnData.Add(new foodItem("lentils", 485));
            returnData.Add(new foodItem("dates", 1180));
            returnData.Add(new foodItem("spinach", 96));
            returnData.Add(new foodItem("eggs", 649));
            returnData.Add(new foodItem("anchovies", 879));
            returnData.Add(new foodItem("olive oil", 3699));
            returnData.Add(new foodItem("butter", 3000));
            returnData.Add(new foodItem("kale", 205));
            returnData.Add(new foodItem("pasta", 548));
            returnData.Add(new foodItem("tomatoes", 75));
            returnData.Add(new foodItem("mushrooms", 92));

            return returnData;
        }

        public List<foodItemEntry>createFoodItemEntries()
        {
            List<foodItemEntry> returnData = new List<foodItemEntry>();

            returnData.Add(new foodItemEntry(1, 3, 1, 120));
            returnData.Add(new foodItemEntry(1, 7, 2, 70));
            returnData.Add(new foodItemEntry(2, 5, 2, 80));
            returnData.Add(new foodItemEntry(2, 4, 3, 150));

            return returnData;
        }

        public List<mealType> createMealTypes()
        {
            List<mealType> returnData = new List<mealType>();

            returnData.Add(new mealType("Breakfast"));
            returnData.Add(new mealType("Lunch"));
            returnData.Add(new mealType("Dinner"));
            returnData.Add(new mealType("Snacks"));

            return returnData;
        }

        public List<user> createUsers()
        {
            List<user> returnData = new List<user>();

            returnData.Add(new user(
                "user1",
                "password",
                new DateTime(2000, 1, 1, 0, 0, 0),
                "male",
                70,
                170,
                "none",
                8500
            ));
            returnData.Add(new user(
                "user2",
                "12345",
                new DateTime(1998, 10, 10, 0, 0, 0),
                "female",
                60,
                170,
                "none",
                8300
            ));
            returnData.Add(new user(
                "internetguy",
                "qwerty",
                new DateTime(1995, 5, 8, 0, 0, 0),
                "male",
                110,
                180,
                "none",
                8100
            ));

            return returnData;
        }
    }
}
