using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        private string funcName;
        private Func<double, double> missionFunction;
        
        /// <summary>
        /// a constructor for SingleMission.
        /// </summary>
        /// <param name="missionFunction"></param>
        /// <param name="funcName"></param>
        public SingleMission(Func<double, double> missionFunction, string funcName)
        {
            this.funcName = funcName;
            this.missionFunction = missionFunction;
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
        ///  in this case, its single.
        /// </summary>
        public string Type
        {
            private set;
            get;
        } = "Single";

        public event EventHandler<double> OnCalculate;  // An Event of when a mission is activated

        /// <summary>
        /// calculates the value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns> returnes the value after operating the function.
        /// </returns>
        public double Calculate(double value)
        {
            double funcValue = missionFunction(value);
            OnCalculate?.Invoke(this, funcValue);
            return funcValue;
        }

    }
}
