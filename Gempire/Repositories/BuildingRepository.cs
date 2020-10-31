using Gempire.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            // You cannot edit a single line without rewriting the entire file - https://stackoverflow.com/questions/1971008/edit-a-specific-line-of-a-text-file-in-c-sharp
            // Convert file to string list of lines, use Json Linq to find line with original info, replace with edited info
            string serializedEditedBuilding = JsonConvert.SerializeObject(editedBuilding);
            List<string> lines = File.ReadLines(_path).ToList();
            foreach (var line in lines)
            {
                // Parse to JObject to use Linq, replace line
                JObject jsonParse = JObject.Parse(line);
                if ((string)jsonParse["name"] == originalName)
                {
                    lines[lines.IndexOf(line)] = serializedEditedBuilding;
                }
            }

            // Rewrite file
            foreach (var line in lines)
            {
                using (var file = new StreamWriter(_path, true))
                {
                    file.WriteLine(line);
                }
            }

            return true;

        }

    }
}
