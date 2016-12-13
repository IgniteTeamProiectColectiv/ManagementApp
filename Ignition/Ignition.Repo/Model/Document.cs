using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignition.Repo.Model
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String name { get; set; }
        public float version { get; set; }
        public List<Tuple<string,string>> fields { get; set; }

        public virtual Flux flux { get; set; }

        public Document()
        {
            version = 0.1f;
            fields = new List<Tuple<string, string>>();
        }

        public Document(List<Tuple<string,string>> list)
        {
            fields = list;
        }
    }
}
