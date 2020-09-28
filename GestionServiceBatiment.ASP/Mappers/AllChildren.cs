using GestionServiceBatiment.ASP.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionServiceBatiment.ASP.Mappers
{
    public static class AllChildren
    {
        public static List<DisplayComment> GetAllDescendants(this DisplayComment node)
        {
            List<DisplayComment> returnList = new List<DisplayComment>();
            List<DisplayComment> result = new List<DisplayComment>();
            
            result.AddRange(GetAllDescendants(node, returnList));
            
            return result;
        }

        public static List<DisplayComment> GetAllDescendants(DisplayComment node, ICollection<DisplayComment> list)
        {
            list.Add(node);

            foreach (DisplayComment child in node.Children)
            {
                if (child.Id != node.Id)
                    GetAllDescendants(child, list);
            }

            return list.ToList();
        }
    }
}