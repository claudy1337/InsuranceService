using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Service.Car
{
    public static class Cars
    {
        public class Car
        {
            public List<Item> Items { get; set; }
        }

        public class Item
        {
            public string ID { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public string Year { get; set; }
            public string Car_Category { get; set; }
            public string Car_Engine_position { get; set; }
            public string Car_Engine { get; set; }
            public string Car_Engine_type { get; set; }
            public string Car_Valves_per_cylinder { get; set; }
            public string Car_Max_power { get; set; }
            public string Car_Max_torque { get; set; }
            public string Car_Bore_stroke { get; set; }
            public string Car_Compression { get; set; }
            public string Car_Top_speed { get; set; }
            public string Car_Fuel { get; set; }
            public string Car_Transmission { get; set; }
            public string Car_Power_per_weight { get; set; }
            public string _0_100_km_h_0_62_mph { get; set; }
            public string Car_Drive { get; set; }
            public string Car_Seats { get; set; }
            public string Car_Passenger_space { get; set; }
            public string Car_doors { get; set; }
            public string Car_Country_of_origin { get; set; }
            public string Car_Front_tire { get; set; }
            public string Car_Rear_tire { get; set; }
            public string Car_Chassis { get; set; }
            public string Car_CO2_emissions { get; set; }
            public string Car_Turn_circle { get; set; }
            public string Car_Weight { get; set; }
            public string Car_Towing_weight { get; set; }
            public string Car_total_length { get; set; }
            public string Car_total_width { get; set; }
            public string Car_total_height { get; set; }
            public string Car_Max_weight_with_load { get; set; }
            public string Car_Ground_clearance { get; set; }
            public string Car_Wheelbase { get; set; }
            public string Car_Cooling { get; set; }
            public string Car_Front_brakes_type { get; set; }
            public string Car_Rear_brakes_type { get; set; }
            public string Car_Cargo_space { get; set; }
            public string Car_Lubrication { get; set; }
            public string Car_front_Leg_room { get; set; }
            public string Car_Aerodynamic_dragcoefisient { get; set; }
            public string Car_Fuel_with_highway_drive { get; set; }
            public string Car_Fuel_with_mixed_drive { get; set; }
            public string Car_Fuel_with_city_drive { get; set; }
            public string CarFuelTankCapacity { get; set; }
            public override string ToString()
            {
                return $"{ID} {Model} {Year} {Car_total_length} {Car_Cooling} {Car_Top_speed}";
            }
            

        }

        public class Root
        {
            public Car Cars { get; set; }
        }


    }
}
