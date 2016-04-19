using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

namespace Market.Resources
{
    public class ResxStringLocalizerFactory : IStringLocalizerFactory
    {
        public ResxStringLocalizerFactory()
        {
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            return new ResxStringLocalizer();
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new ResxStringLocalizer();
        }
    }
}
