using ContentAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContentAPI
{
    public class UserContentService : IContentService
    {
        IContentRepository<AllContent> _conRep;
        IContentRepository<NegativeWords> _negRep;

        public UserContentService(IContentRepository<AllContent> rep, IContentRepository<NegativeWords> negRep)
        {
            _conRep = rep;
            _negRep = negRep;
        }

        public string GetContent()
        {
            return _conRep.Content;
        }

        public int CountNegativeWords()
        {
            string testString = _negRep.Content.Replace(" ", "|");
            Regex regx = new Regex(testString, RegexOptions.IgnoreCase);
            return regx.Matches(_conRep.Content).OfType<Match>().Select(m => m.Value).ToList().Count();
        }
    }
}
