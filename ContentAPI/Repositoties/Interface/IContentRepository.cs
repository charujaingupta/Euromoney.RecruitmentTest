using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentAPI
{
    public interface IContentRepository<T>
    {
        string Content { get; set; }

        void Add(string input);

        void Remove(string input);
    }
}
