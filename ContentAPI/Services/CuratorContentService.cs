using ContentAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContentAPI
{
    public class CuratorContentService : IContentService
    {
        IContentRepository<AllContent> _conRep;
        IContentRepository<NegativeWords> _negRep;

        public CuratorContentService(IContentRepository<AllContent> rep, IContentRepository<NegativeWords> negRep)
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
            return GetNegativeWords().Count();
        }

        private List<string> GetNegativeWords()
        {
            string testString = _negRep.Content.Replace(" ", "|");
            Regex regx = new Regex(testString, RegexOptions.IgnoreCase);
            List<string> mactches = regx.Matches(_conRep.Content).OfType<Match>().Select(m => m.Value).ToList();
            return mactches;
        }


    }
}
