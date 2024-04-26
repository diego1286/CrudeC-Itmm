using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ebooksItm.Models
{
    public class Review
    {
public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } // Este es el usuario que escribió la reseña
        public int EbookId { get; set; }
        public Ebook Ebook { get; set; }
        public int Rating { get; set; } // De 1 a 5 estrellas
        public string Comment { get; set; } // Reseña escrita
         public int Stars { get; set; }
        
    }
}