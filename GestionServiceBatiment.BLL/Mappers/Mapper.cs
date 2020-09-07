using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Mappers
{
    public static class Mapper
    {
        public static void MatchAndMap<TSource, TDestination>(this TSource source, TDestination destination)
            where TDestination : class, new()
            where TSource : class, new()
        {
            if (source != null && destination != null)
            {
                List<PropertyInfo> sourceProperties = source.GetType().GetProperties().ToList<PropertyInfo>();
                List<PropertyInfo> destinationProperties = destination.GetType().GetProperties().ToList<PropertyInfo>();

                foreach (PropertyInfo sourceProperty in sourceProperties)
                {
                    PropertyInfo destinationProperty = destinationProperties.Find(item => item.Name.ToLower() == sourceProperty.Name.ToLower());

                    if (destinationProperty != null)
                    {
                        try
                        {
                            if (sourceProperty.PropertyType.BaseType == typeof(Enum) && destinationProperty.PropertyType.Name == "String")
                                destinationProperty.SetValue(destination, sourceProperty.GetMethod.Invoke(source, null).ToString());

                            else if (sourceProperty.PropertyType.Name == "String" && destinationProperty.PropertyType.BaseType == typeof(Enum))
                                destinationProperty.SetValue(destination, Enum.Parse(destinationProperty.PropertyType, sourceProperty.GetValue(source).ToString()));

                            else
                                destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }

        }

        public static TDestination MapTo<TDestination>(this object mapSource)
            where TDestination : class, new()
        {
            var destination = Activator.CreateInstance<TDestination>();
            MatchAndMap(mapSource, destination);

            return destination;
        }

    }
}
