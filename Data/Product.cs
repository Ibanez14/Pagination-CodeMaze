using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagin_Codemaze.Data
{
    // NOTE
    // Только свойства класса сериализируются и отображаются в Ok(productList)
    // Если только поля то productList будет пустой

    public class Product
    {
        public int Id { get; set; }
        public string Token { get; set; } = Guid.NewGuid().ToString();
    }
}
