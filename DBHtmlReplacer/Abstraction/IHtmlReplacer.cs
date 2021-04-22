using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    /// <summary> 取代器泛型 </summary>
    public interface IHtmlReplacer
    {
        /// <summary> 取代器名稱 </summary>
        string Name { get; }

        /// <summary> 是否存在 </summary>
        /// <param name="sourceText"></param>
        /// <returns></returns>
        bool IsExist(string sourceText);

        /// <summary> 取代文字 </summary>
        void Replace();
    }
}
