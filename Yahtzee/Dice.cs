using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    //key must not be null
    //Represents a dice 
    //To Roll the Dice, it must be in the cup 
    public class Dice<Id>
    {

        private static int FACE_NOT_VISBLE = -1;

        //pre: id != null
        //pre: maxInclusive >= 0
        //pre: face >= 0 && face <= maxInclusive 
        public static Dice<Id> Build(Id id, int maxInclusive, int face, bool inCup)
        {
            if(id == null)
            {
                throw new ArgumentException("argument id: id != null"); 
            }
            if(maxInclusive <= 0)
            {
                throw new ArgumentException("arguemnt maxInclusive: maxInclusive >= 0"); 
            }
            if(face <= 0 || face >= maxInclusive)
            {
                throw new ArgumentException("arguemnt face: face >= 0 && face <= maxInclusive"); 
            }
            return new Dice<Id>(id, inCup, face, maxInclusive); 
        }

        //invaraint: id != null 
        private readonly Id id;

        private bool inCup;

        //invaraint: maxInclusive >= 0 
        private readonly int maxInclusive;

        //invaraint: face >= 0 && face <= maxInclusive 
        private int face;

        private Dice(Id id, bool inCup, int face, int maxInclusive)
        {
            this.id = id;
            this.inCup = inCup;
            this.face = face;
            this.maxInclusive = maxInclusive; 
        }

        //pre: id != null
        //pre: equalityComaprer != null 
        public bool SameDice(Id id, IEqualityComparer<Id> equalityComparer)
        {
            if(id == null)
            {
                throw new ArgumentException("argument id: id != null");
            }
            if(equalityComparer == null)
            {
                throw new ArgumentException("argument equalityComparer: equalityComparer != null");
            }
            return true; 
        }

        public void MoveToCup()
        {
            face = FACE_NOT_VISBLE;
            inCup = true; 
        }
        
        //pre: randomness != null 
        public void Roll(IRandom randomness)
        {
            if(randomness == null)
            {
                throw new ArgumentException("argument randomness: randomness != null"); 
            }
            inCup = false;
            face = randomness.next(0, maxInclusive + 1); 
        }

        //post: return >= 0 && return <= maxInclusive 
        public int Top()
        {
            return face; 
        }
   }
}
