


namespace ebooksItm.Models
{
    public class Ebook
    { public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateTime Year { get; set; }
        public string CoverImage { get; set; } = null!;
        
        // Agregar propiedad para la relación con el usuario
        public User Usuario { get; set; }

    
        
             // Nueva propiedad para la calificación
        public double Rating { get; set; }

        // Lista de reseñas
        public List<Review> Reviews { get; set; }

    

        // Constructor
        public Ebook(string titulo, string author, DateTime year, string coverImage)
        {
            Titulo = titulo;
            Author = author;
            Year = year;
            CoverImage = coverImage;
              // Inicialización de propiedades nuevas
            Rating = 0;
            Reviews = new List<Review>();
     
        }

                 // Función para calcular el promedio de calificación
        public void CalculateRating()
        {
            if (Reviews.Count > 0)
            {
                double sum = 0;
                foreach (var review in Reviews)
                {
                    sum += review.Stars;
                }
                Rating = sum / Reviews.Count;
            }
        }


    }
}