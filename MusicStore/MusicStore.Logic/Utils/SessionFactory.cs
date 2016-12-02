using System;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace MusicStore.Logic.Utils
{
    public static class SessionFactory
    {
        private static ISessionFactory _factory;
        private static string _connectionString;

        public static ISession OpenSession()
        {
            return _factory.OpenSession();
        }

        public static IStatelessSession OpenStatelessSession()
        {
            return _factory.OpenStatelessSession();
        }

        public static void Init(string connectionString)
        {
            _connectionString = connectionString;
            _factory = 
                BuildConfiguration(connectionString)
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
        }

        public static void RefreshSchema()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Connection string must be populated");
            }

            _factory = _factory =
                BuildConfiguration(_connectionString)
                .ExposeConfiguration(cfg =>
                {
                    var schema = new SchemaExport(cfg);
                    schema.Drop(false, true);
                    schema.Create(false, true);
                })
                .BuildSessionFactory();
        }

        private static FluentConfiguration BuildConfiguration(string connectionString)
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings
                    .AddFromAssembly(Assembly.GetExecutingAssembly())
                    .Conventions.Add(ForeignKey.EndsWith("ID"))
                    .Conventions.Add<TableNameConvention>()
                    .Conventions.Add<GuidCombConvention>()
                    .Conventions.Add<ColumnNullabilityConvention>()
                    .Conventions.Add<ReferenceNullabilityConvention>());
        }

        public class TableNameConvention : IClassConvention
        {
            public void Apply(IClassInstance instance)
            {
                instance.Table("[dbo].[" + instance.EntityType.Name + "]");
            }
        }

        public class GuidCombConvention : IIdConvention
        {
            public void Apply(IIdentityInstance instance)
            {
                instance.Column(instance.EntityType.Name + "ID");
                instance.GeneratedBy.GuidComb();
            }
        }

        public class ColumnNullabilityConvention : IPropertyConvention, IPropertyConventionAcceptance
        {
            public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
            {
                criteria.Expect(x => x.Nullable, Is.Not.Set);
            }

            public void Apply(IPropertyInstance instance)
            {
                instance.Not.Nullable();
            }
        }

        public class ReferenceNullabilityConvention : IReferenceConvention, IPropertyConventionAcceptance
        {
            public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
            {
                criteria.Expect(x => x.Nullable, Is.Not.Set);
            }

            public void Apply(IManyToOneInstance instance)
            {
                instance.Not.Nullable();
            }
        }
    }
}
