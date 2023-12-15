
namespace FacebookBackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            User u1 = new User("Avdhesh");

            Comment c1 = new Comment("First Comment");
            Comment c2 = new Comment("Second Comment");
            Comment c21 = new Comment("Second nested Comment");
            Comment c11 = new Comment("First nested Comment");
            Comment c12 = new Comment("First second nested Comment");
            Comment c13 = new Comment("First third nested Comment");

            Post post = new Post();

            // Add comments to the post
            u1.AddCommentToPost(post, c1);
            u1.AddCommentToPost(post, c2);

            // Reply to comments
            u1.ReplyToComment(post, c1.Id, c11);
            u1.ReplyToComment(post, c1.Id, c12);
            u1.ReplyToComment(post, c1.Id, c13);
            u1.ReplyToComment(post, c2.Id, c21);

            // Print header
            Console.WriteLine("========================================================================");
            Console.WriteLine("Printing Comments on the post");
            Console.WriteLine("========================================================================");

            // Print comments and their replies of a post
            foreach (Comment comment in post.Comments)
            {
                Console.WriteLine(comment.Description);
                foreach (Comment reply in comment.Comments)
                {
                    Console.WriteLine("\t" + reply.Description);
                }
            }

            // Print header for editing
            Console.WriteLine("========================================================================");
            Console.WriteLine("Editing Comments");
            Console.WriteLine("========================================================================");

            // Edit comments
            u1.EditComment(post, c1.Id, c11.Id, "Edited Comment");
            u1.EditComment(post, c2.Id, c12.Id, "Edited Comment 2");

            // Print header for deleting
            Console.WriteLine("========================================================================");
            Console.WriteLine("Deleting comment");
            Console.WriteLine("========================================================================");

            u1.DeleteComment(post, c2.Id, c12.Id);

            Console.WriteLine("========================================================================");
            Console.WriteLine("Printing comments on the post");
            Console.WriteLine("========================================================================");

            // Print comments and their replies 
            foreach (Comment comment in post.Comments)
            {
                Console.WriteLine(comment.Description);
                foreach (Comment reply in comment.Comments)
                {
                    Console.WriteLine("\t" + reply.Description);
                }
            }

        }


    }

}

