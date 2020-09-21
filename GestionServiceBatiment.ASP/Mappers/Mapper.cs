using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.ASP.Mappers
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

                foreach (PropertyInfo destinationProperty in destinationProperties)
                {
                    PropertyInfo sourceProperty = sourceProperties.Find(item => item.Name.ToLower() == destinationProperty.Name.ToLower());

                    if (sourceProperty != null)
                    {
                        try
                        {
                            if (sourceProperty.PropertyType.BaseType == typeof(Enum) && destinationProperty.PropertyType.Name == "String")
                                destinationProperty.SetValue(destination, sourceProperty.GetMethod.Invoke(source, null).ToString());

                            else if (sourceProperty.PropertyType.Name == "String" && destinationProperty.PropertyType.BaseType == typeof(Enum))
                                destinationProperty.SetValue(destination, Enum.Parse(destinationProperty.PropertyType, sourceProperty.GetValue(source).ToString()));

                            else if (sourceProperty.PropertyType.IsPrimitive ||
                                    sourceProperty.PropertyType == typeof(String) ||
                                    destinationProperty.PropertyType == typeof(Decimal) ||
                                    destinationProperty.PropertyType == typeof(DateTime) ||
                                    destinationProperty.PropertyType == typeof(Nullable<Int32>)
                                ) 
                                destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);

                            else if (sourceProperty.PropertyType.IsClass)
                            {
                                Type destinationPropertyType = destinationProperty.PropertyType;
                                object destinationPropertyObject = Activator.CreateInstance(destinationPropertyType);
                                destinationProperty.SetValue(destination, destinationPropertyObject);
                                MatchAndMap(sourceProperty.GetValue(source), destinationPropertyObject);
                            }
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
