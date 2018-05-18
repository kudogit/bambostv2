using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.DependencyInjection.Attributes;

namespace Bamboo.Service.Facade
{
    [ScopeDependency(ServiceType = typeof(IAdvisoryService))]
    public class AdvisoryService : IAdvisoryService
    {
    }
}
