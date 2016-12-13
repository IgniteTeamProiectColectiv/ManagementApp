using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ignition.Repo.Model
{
    public class Flux
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public List<string> signatures { get; set; }

        public virtual ICollection<Document> documents { get; set; }

        public Flux()
        {
            documents = new List<Document>();
        }

    }
}
