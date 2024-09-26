using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia
{
    abstract class Post
    {
        public string Username { get; set; }

        public DateTime Timestamp { get; set; }

        public int Likes { get; set; }

        public List<string> Comments { get; set; }

        public Formatter formatter { get; set; }

        public Post(string username, Formatter formatter)
        {
            this.Username = username;
            Timestamp = DateTime.Now;
            this.formatter = formatter;
        }

        public void Like()
        {
            Likes++;
        }

        public void Unlike()
        {
            if (Likes > 0)
            {
                Likes--;
            }
        }

        public abstract void Display();
    }

    class MessagePost : Post
    {
        public string Message { get; set; }

        protected string title;

        public MessagePost(string username, string msg, string title, Formatter formatter) : base(username, formatter)
        {
            this.Message = msg;
            this.title = title;
        }

        public override void Display()
        {
            this.formatter.BoldText(title);
            this.formatter.NewLine();
            this.formatter.PlainText(Message);
            this.formatter.NewLine();
            this.formatter.NewLine();

        }
    }

    class PhotoPost : Post
    {
        public string Filename { get; set; }

        protected string caption;

        public PhotoPost(string username, string filename, string caption, Formatter formatter) : base(username, formatter)
        {
            this.Filename = filename;
            this.caption = caption;
        }
        public override void Display()
        {
            this.formatter.Image(Filename);
            this.formatter.NewLine();
            this.formatter.ItalicText(caption);
            this.formatter.NewLine();
            this.formatter.NewLine();
        }

        public void ApplyFilter()
        {
            // apply filter
        }
    }
}
