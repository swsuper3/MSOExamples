using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia
{
    public abstract class Formatter
    {
        public abstract void BoldText(string text);
        public abstract void ItalicText(string text);
        public abstract void PlainText(string text);
        public abstract void Image(string filename);

        public abstract void NewLine();
    }

    public class MarkdownFormatter : Formatter
    {
        public override void BoldText(string text)
        {
            Console.WriteLine("**"+text+"**");    
        }

        public override void ItalicText(string text)
        {
            Console.WriteLine("*" + text + "*");
        }

        public override void PlainText(string text)
        {
            Console.WriteLine(text);
        }

        public override void Image(string filename)
        {
            Console.WriteLine(filename);
        }

        public override void NewLine()
        {
            Console.WriteLine();
        }
    }

    public class HTMLFormatter : Formatter
    {
        public override void BoldText(string text)
        {
            Console.WriteLine("<strong>"+text+"</strong>");
        }

        public override void ItalicText(string text)
        {
            Console.WriteLine("<em>"+text+"</em>");
        }

        public override void PlainText(string text)
        {
            Console.WriteLine("<p>"+text+"</p>");
        }

        public override void Image(string filename)
        {
            Console.WriteLine("<img src="+filename+"> </img>");
        }

        public override void NewLine()
        {
            Console.WriteLine();
        }
    }
}
