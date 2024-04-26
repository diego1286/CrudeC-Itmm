

namespace ebooksItm.Models
{
    public class User
    {
      public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        // Propiedad de navegación para la lista de libros del usuario
        public List<Ebook> Libros { get; set; }
        public List<Review> Reviews { get; set; } 


  
        public User(int id, string name, string lastName, string location, string email, string password)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Location = location;
            Email = email;
            Password = password;
            Libros = new List<Ebook>();
            Reviews = new List<Review>();
         
        }

    }
}