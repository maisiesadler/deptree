﻿using System.Collections.Generic;

namespace Lively.Diagrams
{
    public class MermaidMd
    {
        public static string Create(IList<DependencyTreeNode> nodes)
        {
            var mermaid = Mermaid.Create(nodes);
            return $@"```mermaid
{mermaid}
```";
        }
    }
}
