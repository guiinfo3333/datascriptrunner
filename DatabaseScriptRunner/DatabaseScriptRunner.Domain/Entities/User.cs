using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace DatabaseScriptRunner.Domain.Entities
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdUser { get; set; }

        public string Name { get; set; }

        public string Login { get; set; } //IsComplet

        public string Password { get; set; }



        //public virtual List<UserDatabase> UserDatabases { get; set; }
        public virtual ICollection<UserDatabase> UserDatabases {get;set;}
        //public virtual ICollection<Database> Databases { get; set; } //nao faz diferença
        //public virtual ICollection<Database> Databases { get; set; }

    }
}
