using ContentAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentAPI
{
    
    public class ContentFactory
    {
        private IContentService service;
        //Can also use some dependency injection (i.e Ninject) to resolve these references with it's concrete implementation
        //---------------
        private IContentRepository<AllContent> conRepository = new ContentRepository();
        private IContentRepository<NegativeWords> negConRepository = new NegativeContentRepository();
        //----------------
        private UserType UType { get; set; }

        public ContentFactory(UserType ut)
        {
            UType = ut;
        }

        public IContentService GetServiceInstance()
        {
            if(UType == UserType.Admin)
            {
                service = new AdminContentService(conRepository, negConRepository);
            }
            else if (UType == UserType.User)
            {
                service = new UserContentService(conRepository, negConRepository);
            }
            else if (UType == UserType.Reader)
            {
                service = new ReaderContentService(conRepository, negConRepository);
            }
            else if (UType == UserType.ContentCurator)
            {
                service = new CuratorContentService(conRepository, negConRepository);
            }

            return service;
        }
    }
}
