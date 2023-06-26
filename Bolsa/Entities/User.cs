using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackendBolsaDeTrabajoUTN.Helpers;

namespace BackendBolsaDeTrabajoUTN.Entities
{
    public abstract class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = Security.CreateSHA512(value); }
        }
        //[Required]
        public string UserName { get; set; }
        public string UserType { get; set; }

        public string UserEmail { get; set; }  

        public bool UserIsActive { get; set; }
    }
}
