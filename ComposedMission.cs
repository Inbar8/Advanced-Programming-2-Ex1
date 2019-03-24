using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        private string funcName;

        private List<Func<double, double>> funcs = new List<Func<double, double>> { };

        /// <summary>
        /// a constructor for ComposedMission.
        /// </summary>
        /// <param name="funcName"></param>
        public ComposedMission(string funcName)
        {
            this.funcName = funcName;
        }

        /// <summary>
        /// initiating the function's name.
        /// </summary>
        public string Name
        {
            private set { funcName = value; }
            get { return this.funcName; }
        }
        
        /// <summary>
        ///  initiating the function's type- single or composed.
        ///  in this case, its composed.
        /// </summary>
        public string Type
        {
            private set;
            get;
        } = "Composed";

        public event EventHandler<double> OnCalculate; // An Event of when a mission is activated
        
        /// <summary>
        /// calculates the value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns> returnes the value after operating the function.
        /// </returns>
        public double Calculate(double value)
        {
            double funcValue = value;
            foreach(Func<double, double> func in funcs)
            {
                funcValue = func(funcValue);
            }
            OnCalculate?.Invoke(this, funcValue);
            return funcValue;
        }

        public ComposedMission Add(Func<double,double> funcToAdd)
        {
            this.funcs.Add(funcToAdd);
            return this;
        }
    }
}
