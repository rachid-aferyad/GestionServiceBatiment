using GestionServiceBatiment.ASP.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionServiceBatiment.ASP.Mappers
{
    public static class CommentEnumerable
    {
        public static IEnumerable<DisplayComment> BuildTree(this IEnumerable<DisplayComment> source)
        {
            if (source == null)
                return null;

            var groups = source.GroupBy(c => c.ParentId);

            var roots = groups.FirstOrDefault(g => g.Key.HasValue == false).ToList();

            if (roots.Count > 0)
            {
                var dict = groups.Where(g => g.Key.HasValue).ToDictionary(g => g.Key.Value, g => g.ToList());
                for (int i = 0; i < roots.Count; i++)
                    AddChildren(roots[i], dict);
            }

            return roots;
        }

        private static void AddChildren(DisplayComment node, IDictionary<int, List<DisplayComment>> source)
        {
            if (source.ContainsKey(node.Id))
            {
                node.Children = source[node.Id];
                foreach (var child in node.Children)
                    AddChildren(child, source);
            }
            else
            {
                node.Children = new List<DisplayComment>();
            }
        }
    }
}