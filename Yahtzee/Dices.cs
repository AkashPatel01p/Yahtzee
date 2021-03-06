﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Yahtzee
{
    // Represents several dices 
    //key must be unique within the instance 
    //key must not be null 
    public sealed class Dices<Id> 
    {

       

        public static String HIDDEN = "N/A";

        //pre: keyChecker != null 
        public static Dices<Id> Build(IEqualityComparer<Id> keyChecker)
        {
            if(keyChecker == null)
            {
                throw new ArgumentException("argument keyChecker: keyChecker != null"); 
            }
            return new Dices<Id>(keyChecker); 
        }

        //keyCompare is how to compare keys 
        //pre: keyChecker != null 
        private Dices(IEqualityComparer<Id> keyChecker)
        {
            this.keyChecker = keyChecker;
            dices = new List<Dice<Id>>(); 
        }
        

        //pre: dice != null 
        public void AddDice(Dice<Id> dice)
        {
            if(dice == null)
            {
                throw new ArgumentException("argument dice: dice != null");
            }
            dices.Add(dice); 
        }

        //pre: id != null
        //pre: id in set of added dices 
        public void MoveToCup(Id id)
        {
            bool found = false;

            if(id == null)
            {
                throw new ArgumentException("arguemnt id: id != null"); 
            }

            foreach(var dice in dices)
            {
                if(dice.SameDice(id, keyChecker))
                {
                    dice.MoveToCup();
                    found = true; 
                }
            }

            if(!found)
            {
                throw new ArgumentException("argument id: id must belong to dice added");
            }
           
        }

        //pre: random != null
        //rolls dice in cup 
        public void Roll(IRandom random)
        {
            if(random == null)
            {
                throw new ArgumentException("argument random: random != null"); 
            }

            foreach(var dice in dices)
            {
                dice.Roll(random); 
            }
        }

        //pre: id != null
        public String TopOf(Id id)
        {
            string topOf = HIDDEN;

            if (id == null)
            {
                throw new ArgumentException("argument id: id != null");
            }

            foreach(var dice in dices)
            {
                if(dice.SameDice(id, keyChecker))
                {
                    topOf = $"{dice.Top()}"; 

                }
            }

            return topOf;  
        }
        
        
        private readonly List<Dice<Id>> dices;
        
        private readonly IEqualityComparer<Id> keyChecker;
        
    }
}
