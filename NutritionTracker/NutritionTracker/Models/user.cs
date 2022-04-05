﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NutritionTracker.Models
{
    public class user
    {
        public user() { }

        public user(string Username, string Password)   //This is for logging a user in, because only the username and password are entered but the hash function is needed
        {
            username = Username;
            password = Password;
        }

        public user(string Username, string Password, DateTime Birthdate, string Gender, int Weight, int Height, string MedicalConditions, int EnergyGoal)
        {
            username = Username;
            password = Password;
            birthdate = Birthdate;
            gender = Gender;
            weight = Weight;
            height = Height;
            medicalConditions = MedicalConditions;
            energyGoal = EnergyGoal;
        }

        private int _id;                    //PK
        private string _username;
        private string _password;
        private DateTime _birthdate;
        private string _gender;
        private int _weight;
        private int _height;
        private string _medicalConditions;
        private int _energyGoal;

        [PrimaryKey, AutoIncrement]
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public DateTime birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }

        public string gender
        {
            get { return _gender; }
            set
            {
                if(value.ToLower() == "female" || value.ToLower() == "male")
                {
                    _gender = value;
                } else
                {
                    _gender = "N/A";
                }
            }
        }

        public int weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public int height
        {
            get { return _height; }
            set { _height = value; }
        }

        public string medicalConditions
        {
            get { return _medicalConditions; }
            set { _medicalConditions = value; }
        }

        public int energyGoal
        {
            get { return _energyGoal; }
            set { _energyGoal = value; }
        }

        public int getRDI()                 //Calculates the Recommended Daily Intake (RDI) based on the users details
        {
            int RDI;
            //Some calculations
            RDI = 10;   //Just for testing purposes

            return RDI;
        }

        public string getPasswordHash()     //Hashes the password for securing the login
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(_password);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
    }
}
