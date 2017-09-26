using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBoostrapIntro.Models
{
    public class GridDto<T>
    {
        public int current;
        public int rowCount;
        public List<T> rows;
        public int total;
    }
}
