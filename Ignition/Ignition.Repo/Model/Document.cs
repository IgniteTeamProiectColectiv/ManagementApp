﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ignition.Repo.Model
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        public float version { get; set; }
        public List<Tuple<string,string>> fields { get; set; }

        public virtual Flux flux { get; set; }

        public int signature { get; set; }

        public Document()
        {
            version = 0.1f;
            signature = -1;
            fields = new List<Tuple<string, string>>();
        }

        public Document(List<Tuple<string,string>> list)
        {
            fields = list;
        }
    }
}
