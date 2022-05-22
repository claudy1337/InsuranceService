using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Service.Car
{
    public class InitializeCars
    {
        protected EnvironmentConstantCars environmentCar;
        private void InitializeData()
        {
            new EnvironmentConstantCars().Provide(out EnvironmentConstantCars constantCars);
            environmentCar = constantCars;
        }
        protected void DoBeforeAll()
        {
            InitializeData();
        }
    }
}
