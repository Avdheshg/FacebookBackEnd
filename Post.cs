using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookBackEnd
{
    public class Post
    {   
        private static int Counter {  get; set; }
        public int Id { get; set; }
        public List<Comment> Comments { get; set; }

        public Post() 
        {
            Id = GetUniqueID();
            Comments = new List<Comment>();
        }

        private int GetUniqueID()
        {
            Counter++;
            return Counter;
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public void AddNestedComment(Comment comment, int parentId)
        {
            foreach (Comment c in Comments)
            {
                if (c.Id == parentId)
                {
                    c.AddComment(comment);
                    break;
                }
            }
        }

        public void EditComment(int parentId, int commentId, string description)
        {
            foreach (Comment comment in Comments)
            {
                if (comment.Id == parentId)
                {
                    if (comment.Id == commentId)
                    {
                        comment.Description = description;
                    }
                    else
                    {
                        foreach (Comment nestedComment in comment.Comments)
                        {
                            if (nestedComment.Id == commentId)
                            {
                                nestedComment.Description = description;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void DeleteComment(int parentId, int commentId)
        {
            foreach (Comment comment in Comments)
            {
                if (comment.Id == parentId)
                {
                    if (comment.Id == commentId)
                    {
                        Comments.Remove(comment);
                        break;
                    }
                    else
                    {
                        comment.DeleteNestedComment(commentId);
                        break;
                    }
                }
            }
        }

    }
}
