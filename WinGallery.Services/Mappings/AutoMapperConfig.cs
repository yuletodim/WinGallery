namespace WinGallery.Services.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;

    public class AutoMapperConfig
    {
        public static MapperConfiguration Configuration {get; private set;}

        public void Execute(params Assembly[] assemblies)
        {
            var types = new List<Type>();
            foreach (var assembly in assemblies)
            {
                types.AddRange(assembly.GetExportedTypes());
            }

            Configuration = new MapperConfiguration(
                cfg =>
                {
                    //var types = assembly.GetExportedTypes();
                    LoadStandartMappings(types, cfg);
                    LoadReversedMappings(types, cfg);
                    LoadCustomMappings(types, cfg);
                });

        }

        private void LoadStandartMappings(IEnumerable<Type> types, IMapperConfigurationExpression configuration)
        {
            foreach (var type in types)
            {
                if(!type.IsAbstract && !type.IsInterface)
                {
                    var maps = type
                        .GetInterfaces()
                        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>))
                        .Select(i => i.GetGenericArguments()[0])
                        .ToList();

                    foreach (var map in maps)
                    {
                        configuration.CreateMap(map, type);
                    }
                }
            }           
        }

        private void LoadReversedMappings(IEnumerable<Type> types, IMapperConfigurationExpression configuration)
        {
            foreach (var type in types)
            {
                if (!type.IsAbstract && !type.IsInterface)
                {
                    var maps = type
                        .GetInterfaces()
                        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>))
                        .Select(i => i.GetGenericArguments()[0])
                        .ToList();

                    foreach (var map in maps)
                    {
                        configuration.CreateMap(type, map);
                    }
                }
            }
        }

        private void LoadCustomMappings(IEnumerable<Type> types, IMapperConfigurationExpression configuration)
        {
            foreach (var type in types)
            {
                if (!type.IsAbstract && !type.IsInterface)
                {
                    var maps = type.GetInterfaces()
                        .Where(i => i.GetType() == typeof(IHaveCustomMappings))
                        .Select(i => (IHaveCustomMappings)Activator.CreateInstance(type));

                    foreach (var map in maps)
                    {
                        map.CreateMappings(configuration);
                    }
                }
            }
        }
    }
}
