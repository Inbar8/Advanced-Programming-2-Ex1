using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
  
    public class FunctionsContainer
    {
        /// <summary>
        /// create a dictionary that contains the key= a string- which is the function's name.
        /// and the val= which is the function itself. (lambda expression).
        /// </summary>
        private Dictionary<string, Func<double,double>> funcDictionary { set; get; }

        /// <summary>
        ///  a constructor for the FunctionsContainer.
        /// </summary>
        public FunctionsContainer(){
            funcDictionary = new Dictionary<string, Func<double, double>>();
        }
        

        public Func<double,double> this[string index] {
            get {
                //if the command does ont exist - return the given value.
                if (!funcDictionary.ContainsKey(index))
                {
                    funcDictionary[index] = param => param;
                }
                return funcDictionary[index];
            }
            set {

                this.funcDictionary[index] = value;
            }
        }

        /// <summary>
        /// gel all missions func.
        /// </summary>
        /// <returns>
        /// returnes a list of keys= the functions' names.
        /// </returns>
        public List<string> getAllMissions()
        {
            return new List<string>(this.funcDictionary.Keys);
        }

    }
}


