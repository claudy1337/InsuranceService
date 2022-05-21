using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using Newtonsoft.Json;


namespace Insurance_Service.Car
{
    public class EnvironmentConstantCars
    {
        private const string _nameJsonFile = "cars.json";
        public void Provide(out EnvironmentConstantCars enObject)
        {
            string jsonObject = File.ReadAllText(_nameJsonFile);
            enObject = JsonSerializer.Deserialize<EnvironmentConstantCars>(jsonObject);
        }
    }
}
