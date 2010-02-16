using FluentNHibernate.Mapping;

namespace NHibernateHelper.Maps
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
