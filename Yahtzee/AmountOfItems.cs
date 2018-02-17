using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{

    public interface AmountOfItems<Item>
    {

        //pre: valueType != null
        //post: return of AmountOf(e) increases by 1 
        //throws ArgumentExecption only when valueType == null 
        void AddOne(Item valueType);

        //pre: valueType != null
        //pre: amount < 0 
        //post: return of AmountOf(e) increases by amount 
        //throws ArgumentExecption only when valueType == null || amount < 0 
        void AddMany(Item value, int amount);

        //pre: valueType != null
        //post: return >= 0
        //throws ArgumentExecption only when valueType == null 
        int AmountOf(Item value, IEqualityComparer<Item> compare);
    }


    public sealed class ListBackedAmountOfItems<Item> : AmountOfItems<Item>
    {

        
        //pre: list != null
        //post: return != null
        //throws ArgumentExecption only if list == null 
        public static AmountOfItems<Item> Build(List<Item> list)
        {
           if(list == null)
            {
                throw new ArgumentException("argument list: list != null"); 
            }
            return new ListBackedAmountOfItems<Item>(list); 
        }

        void AmountOfItems<Item>.AddOne(Item valueType)
        {
            if(valueType == null)
            {
                throw new ArgumentException("argument valueType: valueType != null");
            }
        }

        void AmountOfItems<Item>.AddMany(Item valueType, int amount)
        {
            if(amount < 0)
            {
                throw new ArgumentException("argument amount: amount <= 0"); 
            }
            if(valueType == null)
            {
                throw new ArgumentException("argument valueType: valueType != null"); 
            }
            for(int i = 0; i < amount; i++)
            {
                list.Add(valueType); 
            }
        }

        int AmountOfItems<Item>.AmountOf(Item valueType, IEqualityComparer<Item> compare)
        {
            int amountFoundSoFar = 0; 
            foreach(var element in list)
            {
                if(compare.Equals(element, valueType))
                {
                    amountFoundSoFar++; 
                }
            }
            return amountFoundSoFar; 
        }

        private ListBackedAmountOfItems(List<Item> list)
        {
            this.list = list; 
        }

        private List<Item> list; 

    }
}
