﻿using System.Collections.Generic;
using System.Text;

namespace Lively.Diagrams
{
    public class yUMLmd
    {
        public static string Create(IList<DependencyTreeNode> nodes)
        {
            var builder = new List<string>();

            var flattenedNodes = FlattenedNodes.Create(nodes);

            foreach (var (nodeType, implementationType, children) in flattenedNodes.Relationships())
            {
                foreach (var (childType, childImplementationType, count) in children)
                {
                    var childPlusImpl = childType.Name;
                    if (childImplementationType != null)
                        childPlusImpl += $"|{childImplementationType.Name}";

                    if (count == 1)
                    {
                        builder.Add($"[{nodeType.Name}]-&gt;[{childPlusImpl}]");
                    }
                    else
                    {
                        builder.Add($"[{nodeType.Name}]-{count}&gt;[{childPlusImpl}]");
                    }
                }
            }

            var img = string.Join(", ", builder);
            return $"<img src=\"http://yuml.me/diagram/scruffy/class/{img}\" />";
        }
    }
}
