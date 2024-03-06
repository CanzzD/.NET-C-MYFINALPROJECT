using System;
using Entities.Abstract;

namespace Entities.Concrete
{
    //ASLA ÇIPLAK CLASS KALMAYACAK HEPSİ BİR İNTERFACEYE BİR ÜST SINIFA BAĞLANACAK
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
