using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Key]
        [StringLength(7)]
        public int PassportNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAdress { get; set; }
        public FullName FullName { get; set; }

        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]
        public int TelNumber { get; set; }
        //public List<Flight> Flights { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public override string ToString()
        {
            return "FirstName & LastName: " +this.FullName.FirstName + this.FullName.LastName;
        }

        //public bool CheckProfile(string firstName, string lastName)
        //{
        //    return firstName == this.FirstName && lastName == this.LastName;
        //}

        //public bool CheckProfile(string firstName, string lastName,string email)
        //{
        //    return firstName == this.FirstName && lastName == this.LastName && 
        //        email == this.EmailAdress;
        //}

        public bool CheckProfile(string firstName, string lastName,string email = null)
        {
            if(email == null)
            {
                return firstName == this.FullName.FirstName && lastName == this.FullName.LastName;
            }
            else
            {
                return firstName == this.FullName.FirstName && lastName == this.FullName.LastName &&
                email == this.EmailAdress;
            }
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }
    }
}
