using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace NutritionTracker.Data
{
    public class databaseSettings
    {
        public static string defaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3");
    }
}
