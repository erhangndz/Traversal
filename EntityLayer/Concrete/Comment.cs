using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentID { get; set; }
      
        public string? Image { get; set; }
        public DateTime CommentDate { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public int DestinationID { get; set; }
        public Destination Destination { get; set; }  
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }    
    }
}
