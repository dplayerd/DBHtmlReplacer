using Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AngleSharp;
using AngleSharp.Html.Parser;

namespace Executor
{
    public class Link_NoOpenerReplacer
    {
        public string Name => "Link_NoOpener";

        public string Replace(string sourceText)
        {
            if (string.IsNullOrWhiteSpace(sourceText))
                return string.Empty;

            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var parser = context.GetService<IHtmlParser>();
            var document = parser.ParseDocument(sourceText);

            var aList = document.QuerySelectorAll("a[target=_blank]");
            foreach (var obj in aList)
            {
                if (!obj.HasAttribute("rel"))
                {
                    obj.SetAttribute("rel", "noopener noreferrer");
                    continue;
                }

                var attr = obj.Attributes["rel"];

                if (!obj.Attributes["rel"].Value.Contains("noopener"))
                    attr.Value += " noopener";

                if (!obj.Attributes["rel"].Value.Contains("noreferrer"))
                    attr.Value += " noreferrer";
            }

            return document.Body.InnerHtml;
        }
    }
}
