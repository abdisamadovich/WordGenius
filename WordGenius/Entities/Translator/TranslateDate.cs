using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGenius.Entities.Translator
{
    public class TranslationResponse
    {
        public DataObject data { get; set; }
    }

    public class DataObject
    {
        public List<TranslationObject> translations { get; set; }
    }

    public class TranslationObject
    {
        public string translatedText { get; set; }
    }

}
