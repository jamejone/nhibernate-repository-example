using FluentNHibernate.Mapping;

namespace RepositoryExample.Maps
{
    public class MonkeyMap : ClassMap<Monkey>
    {
        public MonkeyMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.FlingsPoo);
            HasMany<Banana>(x => x.Bananas)
                .Not.LazyLoad();
        }
    }
}
