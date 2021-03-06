﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BridgePattern
{
    /// <summary>
    /// Abstraction
    /// </summary>
    public abstract class Manuscript
    {
        protected readonly IFormatter formatter;

        public Manuscript(IFormatter formatter)
        {
            this.formatter = formatter;
        }

        public abstract void Print();
    }

    public class Book : Manuscript
    {
        public Book(IFormatter formatter)
            : base(formatter)
        {
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }

        public override void Print()
        {
            Console.WriteLine("Print Book");
            Console.WriteLine(formatter.Format("Title", Title));
            Console.WriteLine(formatter.Format("Author", Author));
            Console.WriteLine(formatter.Format("Text", Text));
            Console.WriteLine();
        }
    }

    public class TermPaper : Manuscript
    {
        public TermPaper(IFormatter formatter)
            : base(formatter)
        {
        }

        public string Class { get; set; }
        public string Student { get; set; }
        public string Text { get; set; }
        public string References { get; set; }

        public override void Print()
        {
            Console.WriteLine("Print TermPaper");
            Console.WriteLine(formatter.Format("Class", Class));
            Console.WriteLine(formatter.Format("Student", Student));
            Console.WriteLine(formatter.Format("Text", Text));
            Console.WriteLine(formatter.Format("References", References));
            Console.WriteLine();
        }
    }

    public class FAQ : Manuscript
    {
        public string Title { get; set; }
        public Dictionary<string, string> Questions { get; set; }

        public FAQ(IFormatter formatter)
            : base(formatter)
        {
            Questions = new Dictionary<string, string>();
        }

        public override void Print()
        {
            Console.WriteLine("Print FAQ");
            Console.WriteLine(formatter.Format("Title", Title));
            foreach (var question in Questions)
            {
                Console.WriteLine(formatter.Format("   Question", question.Key));
                Console.WriteLine(formatter.Format("   Answer", question.Value));
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Implementation
    /// </summary>
    public interface IFormatter
    {
        string Format(string key, string value);
    }

    public class StandardFormatter : IFormatter
    {
        public string Format(string key, string value)
        {
            return string.Format("{0}: {1}", key, value);
        }
    }

    public class FancyFormatter : IFormatter
    {
        public string Format(string key, string value)
        {
            return string.Format("-= {0} ----- =- {1}", key, value);
        }
    }

    public class BackwardsFormatter : IFormatter
    {
        public string Format(string key, string value)
        {
            return string.Format("{0}: {1}", key, new string(value.Reverse().ToArray()));
        }
    }
}
