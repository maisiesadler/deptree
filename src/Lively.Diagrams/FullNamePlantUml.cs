﻿using System.Collections.Generic;

namespace Lively.Diagrams
{
    public class FullNamePlantUml
    {
        public static string Create(IList<DependencyTreeNode> nodes, string[] customNamespaceGrouping = null)
        {
            var renderer = new PlantUmlRenderer(type =>
            {
                if (customNamespaceGrouping != null)
                {
                    foreach (var ns in customNamespaceGrouping)
                    {
                        if (type.FullName.StartsWith(ns + "."))
                            return OverrideNamespaceGrouping(ns, type.FullName);
                    }
                }

                return type.FullName;
            });
            return renderer.Create(nodes);
        }

        private static string OverrideNamespaceGrouping(string @namespace, string fullName)
        {
            var end = fullName.Remove(0, @namespace.Length + 1);
            return $"{@namespace}.{end.Replace('.', '_').Replace('+', '_')}";
        }
    }
}
