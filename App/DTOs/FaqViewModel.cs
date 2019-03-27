using System.Collections.Generic;
using App.Domain.Entities.Faq;
using App.Domain.Entities.Setting;

namespace App.DTOs
{
    public class FaqViewModel
    {
        public IEnumerable<Faq> Faqs { get; set; }
        public Faq Faq { get; set; }
        public Setting Setting { get; set; }
    }
}
