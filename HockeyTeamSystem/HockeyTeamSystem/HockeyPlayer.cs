﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTeamSystem
{
    // change "internal" to public if you are interested in using the class outside of the current namespace
    public class HockeyPlayer
    {
        private string _fullName;
        private int _primaryNumber;
        public PlayerPosition Position { get; private set; }
        public int PrimaryNumber
        {
            get { return _primaryNumber; }

            private set 
            {
                // Validate that the primary number is between 1 and 99
                if (value < 1 || value > 99)
                {
                    throw new ArgumentException("HockeyPlayer PrimaryNumber must be between 1 and 99.");
                }
                _primaryNumber = value;
            }
        }

        // Define a fully-implemented property for FullName with readonly information
        public string FullName
        {
            get { return _fullName; }

            private set
            {
                // Validate FullName is not null, not empty, and not a whitespace
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("HockeyPlayer FullName must not be null, empty, or be a whitespace.");
                }

                // Validate FullName contains at minimum 3 characters
                if (value.Length < 3)
                {
                    throw new ArgumentException("HockeyPlayer FullName must contain at least 3 characters.");
                }

                _fullName = value.Trim();
            }
        }

        // Define a greedy constructor
        #pragma warning disable CS8618   
        public HockeyPlayer(string fullName, int primaryNumber, PlayerPosition playerPosition)
        {
            FullName = fullName;
            PrimaryNumber = primaryNumber;
            Position = playerPosition;
        }

        // Override the ToString() method to return a CSV
        public override string ToString()
        {
            return $"{FullName}, {PrimaryNumber}, {Position}";
        }
    }
}