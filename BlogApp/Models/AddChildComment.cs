namespace BlogApp.Models
{
    public class AddChildComment
    {
        public int BlogId { get; set; }
        public int RootCommentId { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }


    }
}
