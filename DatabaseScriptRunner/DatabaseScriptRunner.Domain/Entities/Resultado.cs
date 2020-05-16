
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DatabaseScriptRunner.Domain.Entities
{
 public class Resultado
    {
        public int iduser { get; set; }
        public string textresult { get; set; }
        public List<string> getter { get; set; }

        public int afectedrows { get; set; }
        public int UltimoId { get; set; }
    }
}
