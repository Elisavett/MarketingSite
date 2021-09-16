using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingSite.Models
{
    public class Page
    {
        //Пагинация. Проверка начальной и конечной страницы
        public static void CheckPage(ref int page, int count)
        {
            if (page == 0) page = 1;
            if (page > Math.Ceiling(count / 10.0)) page--;
        }
    }
}
