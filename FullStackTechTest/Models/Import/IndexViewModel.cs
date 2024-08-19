using DAL;
using Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FullStackTechTest.Models.Import
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            ImportPeopleList = new List<Person>();
            ImportAddressList = new List<Address>();
        }

        public List<Person> ImportPeopleList { get; set; }

        public List<Address> ImportAddressList { get; set; }

        public void LoadJson(string jsonPath)
        {
            

            using (FileStream openStream = File.OpenRead(jsonPath))//See best way to read
            {
                var jsonPeopleList = JsonSerializer.Deserialize<List<JsonFormatPeople>>(openStream);//May need to add process for making address object 
                if (jsonPeopleList != null)
                {
                    this.ConvertJSON(jsonPeopleList);
                }
            }
            
        }

        private void ConvertJSON(List<JsonFormatPeople> jsonFormatPeople)
        {
            //Turns this list into People and Address list for adding to tables
            foreach (var person in jsonFormatPeople)
            {
                this.ImportPeopleList.Add(new Person()
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    GMC = person.GMC,
                });
                this.ImportAddressList.Add(person.Address);
            }
        }

        private List<JsonFormatPeople> FilterPeopleByGMC(List<JsonFormatPeople> jsonFormatPeople)
        {

            return jsonFormatPeople; 
        
        }

        private class JsonFormatPeople
        {
            public string FirstName;
            public string LastName;
            public int GMC;
            public Address Address;

        }
    }
    
}
