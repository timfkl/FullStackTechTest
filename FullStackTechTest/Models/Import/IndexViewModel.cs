using DAL;
using Models;
using System.Text.Json.Serialization;

namespace FullStackTechTest.Models.Import
{
    public class IndexViewModel
    {

        public List<Person> ImportPeopleList { get; set; }

        public List<Address> ImportAddressList { get; set; }

        public void LoadJson(string jsonPath)
        {
            using (StreamReader r = new StreamReader(jsonPath))
            {
                string json = r.ReadToEnd();
                //List<JsonFormatPeople> people = JsonConvert.DeserializeObject<List<JsonFormatPeople>>(json);
            }
        }

        private void ConvertJSON(List<JsonFormatPeople> jsonFormatPeople)
        {
            //Turns this list into People and Address list for adding to tables
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
