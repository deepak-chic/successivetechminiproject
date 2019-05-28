using System.ComponentModel.DataAnnotations;

namespace SuccessiveTechiniProject.WebAPI
{
    /// <summary>
    /// This class is used to maintain the user detail
    /// </summary>
    public class Person
    {
        /// <summary>
        /// User id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// User first name
        /// </summary>
        [MaxLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// User last name
        /// </summary>
        [MaxLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// User phone number
        /// </summary>
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
    }
}