using ContentAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContentAPI
{
    public class AdminContentService : IContentService
    {
        IContentRepository<AllContent> _conRep;
        IContentRepository<NegativeWords> _negRep;

        public AdminContentService(IContentRepository<AllContent> rep, IContentRepository<NegativeWords> negRep)
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

        public List<string> GetNegativeWords()
        {
            List<string> words = _negRep.Content.Replace(" ", "|").Split('|').ToList();
            return words;
        }

        public List<string> FindNegativeWordsInContent()
        {
            string testString = _negRep.Content.Replace(" ", "|");
            Regex regx = new Regex(testString, RegexOptions.IgnoreCase);
            List<string> mactches = regx.Matches(_conRep.Content).OfType<Match>().Select(m => m.Value).ToList();
            return mactches;
        }

        public void AddNegativeWord(string word)
        {
            _negRep.Add(word);
        }

        public void RemoveNegativeWord(string word)
        {
            _negRep.Remove(word);
        }

    }
}
