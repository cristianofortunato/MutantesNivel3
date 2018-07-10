using System;
using Newtonsoft.Json;

namespace Classes
{
    public class Mutant
    {
        // Other properties are not displayed
        internal string _DNA { get; set; }
        public long Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string[] DNA
        {
            get { return _DNA == null ? null : JsonConvert.DeserializeObject<string[]>(_DNA); }
            set { _DNA = JsonConvert.SerializeObject(value); }
        }
    }
}