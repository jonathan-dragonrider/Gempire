using Gempire.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Gempire.Repositories
{
    public class BuildingRepository
    {
        private readonly string _path = @"C:\Users\jonph\Desktop\C#\Projects\Gempire\Gempire\Data\Buildings.txt";

        public void CreateBuilding(Building building)
        {
            string serializedBuilding = JsonConvert.SerializeObject(building);
            using (var file =
            new StreamWriter(_path, true))
            {
                file.WriteLine(serializedBuilding);
            }
        }

        public List<Building> GetBuildings()
        {
            using (var file = new StreamReader(_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Building> buildings = new List<Building>();

                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Building deserializedBuilding = JsonConvert.DeserializeObject<Building>(line);
                    buildings.Add(deserializedBuilding);
                }

                return buildings;
            }
        }

        public Building GetBuildingByName(string name)
        {
            var buildings = GetBuildings();
            foreach (var building in buildings)
            {
                if (building.Name == name)
                {
                    return building;
                }
            }

            return null;
        }

        public bool EditBuilding(Building editedBuilding, string originalName)
        {
            // JSON LINQ - Find(originalName), replace with editedBuilding
            using (var file = new StreamReader(_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Building> buildings = new List<Building>();

                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Building deserializedBuilding = JsonConvert.DeserializeObject<Building>(line);
                    buildings.Add(deserializedBuilding);
                }

            }
        }

    }
}
