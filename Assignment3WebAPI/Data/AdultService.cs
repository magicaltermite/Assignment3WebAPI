using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment3WebAPI.Models;

namespace Assignment3WebAPI.Data
{
    public class AdultService : IAdultService
    {
        private string adultsFile = "adults.json";
        private IList<Adult> adults;


        public AdultService() {
            if (!File.Exists(adultsFile)) {
                Seed();
                WriteAdultsToFile();
            }
            else {
                string content = File.ReadAllText(adultsFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }
        }

        


        public async Task<IList<Adult>> GetAdultsAsync() {
            List<Adult> tmp = new List<Adult>(adults);
            return tmp;
        }

        public async Task<Adult> AddAdultAsync(Adult adult) {
            int max = adults.Max(adult => adult.Id);
            adult.Id = ++max;
            adults.Add(adult);
            WriteAdultsToFile();
            return adult;
        }

        public async Task RemoveAdultAsync(int adultId) {
            Adult toRemove = adults.First(t => t.Id == adultId);
            adults.Remove(toRemove);
            WriteAdultsToFile();
        }

        public async Task<Adult> UpdateAdultAsync(Adult adult) {
            Adult toUpdate = adults.FirstOrDefault(t => t.Id == adult.Id);

            if (toUpdate == null) throw new Exception($"Did not find adult with id: {adult.Id}");
            WriteAdultsToFile();
            return toUpdate;

        }
        
        
        
        private void WriteAdultsToFile() {
            string productAsJson = JsonSerializer.Serialize(adults);
            
            File.WriteAllText(adultsFile, productAsJson);
        }

        private void Seed() {
            Adult[] ts = {
                new Adult {
                    Id = 1,
                    FirstName = "Markus",
                    LastName = "Lorensen",
                    HairColor = "brown",
                    EyeColor = "Blue",
                    Age = 21,
                    Weight = 65,
                    Height = 185,
                    JobTitle = "Student",
                    Sex = "M"
                }
            };
            adults = ts.ToList();



        }
    }
}