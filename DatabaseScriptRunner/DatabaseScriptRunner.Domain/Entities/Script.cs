using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatabaseScriptRunner.Domain.Entities
{
    public  class Script
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   
        public string text { get; set; }

        public int[] Databases { get; set; }
      //  public virtual ICollection<Database> Databases { get; set;}

      


    }
}
