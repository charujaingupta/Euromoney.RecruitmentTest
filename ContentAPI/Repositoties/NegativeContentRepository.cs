using ContentAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentAPI
{
    public class NegativeContentRepository : IContentRepository<NegativeWords>
    {
        private string _initialContent = "swine bad nasty horrible";

        public string Content
        {
            get { return _initialContent; }
            set { _initialContent = value; }
        }

        public void Add(string input)
        {
            input = " " + input.Trim();
            Content = Content.Trim() + input;
        }

        public void Remove(string input)
        {
            input = input.Trim();
            int negWordIndex = Content.IndexOf(input);
            int len = input.Length;
            if (negWordIndex > -1)
            {
                //to also remove the space before the word
                if (negWordIndex != 0)
                {
                    negWordIndex--; 
                    len++;
                }
                Content = Content.Remove(negWordIndex, len);
            }
        }
    }
}
