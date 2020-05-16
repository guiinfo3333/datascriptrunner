using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatabaseScriptRunner.Domain.Entities
{
    [Table("UserDatabase")]
    public class UserDatabase
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // chave estrangeira
        [ForeignKey("User")]
        public int IdUser { get; set; }
        [ForeignKey("Database")]
        public int IdDatabase { get; set; }

        //public virtual ICollection<UserDatabase> UserDatabases { get; set; }

        //public virtual Database Database { get; set; }

        //public virtual ICollection<Database> Databases { get; set; }  // buga se ativar esse código

        //public virtual User User { get; set; }



    }
}
