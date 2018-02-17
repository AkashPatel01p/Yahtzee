using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    //added for testing code 
    public sealed class StringEqualityByEquals : IEqualityComparer<string>
    {

        public static IEqualityComparer<string> Build()
        {
            return new StringEqualityByEquals(); 
        }

        private StringEqualityByEquals()
        {

        }

        bool IEqualityComparer<string>.Equals(string x, string y)
        {
            return x.Equals(y); 
        }

        int IEqualityComparer<string>.GetHashCode(string obj)
        {
            return obj.GetHashCode(); 
        }
    }
}
