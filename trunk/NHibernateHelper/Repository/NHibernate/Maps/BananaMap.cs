using FluentNHibernate.Mapping;

namespace RepositoryExample.Maps
{
    public class BananaMap : ClassMap<Banana>
    {
        public BananaMap()
        {
            Id(x => x.Id);
            Map(x => x.Color);
        }
    }
}
