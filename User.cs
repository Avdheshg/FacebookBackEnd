using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookBackEnd
{
    public class User
    {
        private static int counter = 0;
        private int id;
        private string name;

        public int Id { get; set; }
        public string Name { get; set; }

        public User(string name)
        {
            this.name = name;
            this.id = GetUniqueID();
        }

        private int GetUniqueID()
        {
            counter++;
            return counter;
        }

        public void AddCommentToPost(Post post, Comment comment)
        {
            comment.UserId = Id;
            comment.PostId = post.Id;
            comment.ParentId = comment.Id;

            post.AddComment(comment);
        }

        public void ReplyToComment(Post post, int parentId, Comment comment)
        {
            comment.UserId = Id;
            comment.PostId = post.Id;
            comment.ParentId = parentId;

            post.AddNestedComment(comment, parentId);
        }

        public void EditComment(Post post, int parentId, int commentId, string description)
        {
            foreach (Comment comment in post.Comments)
            {
                if (comment.Id == commentId)
                {
                    if (comment.UserId !=  Id)
                    {
                        Console.WriteLine("Unauthorized user");
                    }
                    break;
                }
            }
            post.EditComment(parentId, commentId, description);
        }

        public void DeleteComment(Post post, int parentId, int commentId)
        {
            foreach (Comment comment in post.Comments)
            {
                if (comment.UserId != Id)
                {
                    Console.WriteLine("Unauthorized user");
                }
            }
            post.DeleteComment(parentId, commentId);
        }
    }
}
