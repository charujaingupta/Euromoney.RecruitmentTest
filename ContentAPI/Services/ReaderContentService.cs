using ContentAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContentAPI
{
    public class ReaderContentService : IContentService
    {
        IContentRepository<AllContent> _conRep;
        IContentRepository<NegativeWords> _negRep;

        public ReaderContentService(IContentRepository<AllContent> rep, IContentRepository<NegativeWords> negRep)
        {
            _conRep = rep;
            _negRep = negRep;
        }

        public string GetContent()
        {
            return ParseText(_conRep.Content);
        }

        private string ParseText(string text)
        {
            string testString = _negRep.Content.Replace(" ", "|");
            Regex regx = new Regex(testString, RegexOptions.IgnoreCase);
            string cleaned = Regex.Replace(text, "\\b" + testString + "\\b", m=>Mask(m.Value));
            return cleaned;
        }

        private string Mask(string word)
        {
            int ctr = 0;
            string masked = string.Empty;
            word.ToCharArray().ToList().ForEach(x => {
                if (ctr == 0 || ctr == word.Length - 1)
                {
                    masked += x;
                }
                else
                {
                    masked += '#';
                }
                ctr++;
            });

            return masked;
        }

    }
}
