using System.Runtime.InteropServices;
using StructureMap;
using timeTracker.Domain;
using timeTracker.Web.Infrastructure;

namespace timeTracker.Web {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                           x.For<ITimeTrackerDataSource>().HttpContextScoped().Use<TimeTrackerDb>();
                        });
            return ObjectFactory.Container;
        }
    }
}