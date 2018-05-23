using ContentAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentAPI
{
    public class ContentRepository : IContentRepository<AllContent>
    {
        private string _initialContent = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

        public string Content
        {
            get
            {
                return _initialContent;
            }
            set
            {
                _initialContent = value;
            }
        }

        public void Add(string input)
        {
            throw new NotImplementedException();
        }

        public void Remove(string input)
        {
            throw new NotImplementedException();
        }


       
    }
}
