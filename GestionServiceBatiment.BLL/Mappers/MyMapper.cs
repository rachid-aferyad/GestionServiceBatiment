using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GestionServiceBatiment.BLL.Mappers
{
    public static class MyMapper
    {
        public static void MatchAndMap<TSource, TDestination>(this TSource source, TDestination destination)
            where TDestination : class, new()
            where TSource : class, new()
        {
            if (source != null && destination != null)
            {
                List<PropertyInfo> sourceProperties = source.GetType().GetProperties().ToList<PropertyInfo>();
                List<PropertyInfo> destinationProperties = destination.GetType().GetProperties().ToList<PropertyInfo>();

                foreach (PropertyInfo sourceProperty in sourceProperties) // sourcePro = serviceBLL.companyBLL dis = sericeAPI.companyAPI
                {
                    PropertyInfo destinationProperty = destinationProperties.Find(item => item.Name.ToLower() == sourceProperty.Name.ToLower());

                    if (destinationProperty != null && destinationProperty.Name != "NavigationName")
                    {
                        try
                        {
                            if (sourceProperty.PropertyType.BaseType == typeof(Enum) && destinationProperty.PropertyType.Name == "String")
                            {
                                destinationProperty.SetValue(destination, sourceProperty.GetMethod.Invoke(source, null).ToString());
                            }
                            else if (sourceProperty.PropertyType.Name == "String" && destinationProperty.PropertyType.BaseType == typeof(Enum))
                            {
                                destinationProperty.SetValue(destination, Enum.Parse(destinationProperty.PropertyType, sourceProperty.GetValue(source).ToString()));
                            }
                            else if (sourceProperty.PropertyType.IsPrimitive ||
                                    sourceProperty.PropertyType == typeof(String) ||
                                    destinationProperty.PropertyType == typeof(Decimal) ||
                                    destinationProperty.PropertyType == typeof(DateTime) ||
                                    destinationProperty.PropertyType == typeof(Nullable<Int32>)
                                )
                            {
                                destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);
                            }

                            else if (sourceProperty.PropertyType.IsClass)
                            {
                                Type destinationPropertyType = destinationProperty.PropertyType;
                                object destinationPropertyObject = Activator.CreateInstance(destinationPropertyType);
                                destinationProperty.SetValue(destination, destinationPropertyObject);
                                MatchAndMap(sourceProperty.GetValue(source), destinationPropertyObject);
                            }
                            else if (typeof(IEnumerable<object>).IsAssignableFrom(sourceProperty.PropertyType))
                            {
                                Type destinationPropertyType = destinationProperty.PropertyType;

                                destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);

                                //sourceProperty.GetValue(source).MapTo<destinationProperty>();

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

        public static IEnumerable<TDestination> MapTo<TDestination>(this IEnumerable<object> mapSource)
            where TDestination : class, new()
        {
            foreach (var item in mapSource)
            {
                yield return item.MapTo<TDestination>();
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
