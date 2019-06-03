namespace TeduShop.Web.Models
{
    public class PostTagViewModel
    {
        public long PostId { get; set; }

        public string TagId { get; set; }
  
        public virtual PostViewModel Post { get; set; }

        public virtual TagViewModel Tag { get; set; }
    }
}