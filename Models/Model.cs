
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ordermanager_dotnet.Models
{
    public class Model
    {
        [Required]
        public int Id {get;set;}

        [Required]
        public string Description {get;set;}

        [Required]
        public int ManufacturerId {get;set;}
        public Manafacturer Manufacturers {get;set;}
        public List<Machine> Machines {get;set;}
    }
}
