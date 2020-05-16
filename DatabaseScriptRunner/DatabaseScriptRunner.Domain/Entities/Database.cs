using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseScriptRunner.Domain.Entities
{
    public class Database
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDatabase { get; set; }

        public string Name { get; set; }

        public string ConnectionString { get; set; } //IsComplet


        public virtual ICollection<UserDatabase> UserDatabases { get; set; } // tipo um 'for'

        

    }
}
