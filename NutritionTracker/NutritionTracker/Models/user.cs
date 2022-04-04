﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionTracker.Models
{
    class user
    {
        //public user(int Id, string Username, string Password, DateTime Birthdate, char Gender, int Weight, int Height, string MedicalConditions, int EnergyGoal)
        //{

        //}

        private int _id;
        private string _username;
        private string _password;
        private DateTime _birthdate;
        private char _gender;
        private int _weight;
        private int _height;
        private string _medicalConditions;
        private int _energyGoal;

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

        public char gender
        {
            get { return _gender; }
            set
            {
                if(value == 'f' || value == 'm')
                {
                    _gender = value;
                } else
                {
                    _gender = 'f';
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
