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
        public String name;
        public float version;

        public Document()
        {
            version = 0.1f;
        }
    }
}
