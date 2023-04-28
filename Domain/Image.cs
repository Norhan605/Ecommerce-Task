using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Image
    {
        public int ID { get; set; }
        public string Name { get; private set; }  
        public float Length { get;  set; }
        public float Width { get;  set; }
        public float Height { get;  set; }

        public Product Product { get; private set; }

        public Image(string name , Product product , float lenght , float width , float height)
        {
            Name= name;
            Product= product;
            Length=lenght;
            Width= width;
            Height= height;
        }
        private Image() : this(null!, null!,0,0,0)
        {

        }
    }
}
