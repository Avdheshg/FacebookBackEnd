using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookBackEnd
{
    // https://leetcode.com/discuss/interview-question/object-oriented-design/4159518/LLD-or-Design-Facebook-Comment-System
    public class Comment
    {
        // ??? What is the difference between
        //          V define the private variable and then use it into a property
        //          V directly define the property

        //private static int counter = 0;
        //private int postId;
        //private int userId;
        //private string description;
        //private int id;
        //private int parentId;
        //private List<Comment> comments;
        //private bool isParent;

        public static int Counter {  get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public List<Comment> Comments { get;}
        public int ParentId { get; set; }   
        public bool IsParent {  get; set; }

        public Comment(string description)
        {
            PostId = 0;
            UserId = 0;
            Description = description;
            Id = GetUniqueId();
            Comments = new List<Comment>();
            ParentId = 0;
            IsParent = false;
        }

        private int GetUniqueId()
        {
            counter++;
            return counter;
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public void DeleteNestedComment(int commentId)
        {
            foreach (Comment comment in Comments)
            {
                if (comment.Id == commentId)
                {
                    Comments.Remove(comment);
                    break;
                }
            }
        }

    }
}
