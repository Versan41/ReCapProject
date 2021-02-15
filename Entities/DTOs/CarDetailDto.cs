using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    // IEntity olmuyor çünkü CarDetailDto bir tablo nesnesi değil
    public class CarDetailDto : IDto
    {
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int DailyPrice { get; set; }
    }
}
