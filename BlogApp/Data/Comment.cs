using System.ComponentModel.DataAnnotations;

namespace BlogApp.Data
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int? ParentId { get; set; }
        public string WriterName { get; set; }
        public string Content { get; set; }
        public Comment Parent { get; set; }
        public List<Comment> Child { get; set; }

    }
}
