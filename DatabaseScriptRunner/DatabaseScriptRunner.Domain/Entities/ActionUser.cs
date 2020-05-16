using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatabaseScriptRunner.Domain.Entities
{
    public class ActionUser
    {
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAction { get; set; }
        public string command { get; set; }

        [ForeignKey("User")]
        public int IdUser { get; set; }

        //public virtual ICollection<User> Users { get; set; }
    }
}
