using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ColorARGB
    {
        private int rojo;
        private int verde;
        private int azul;
        private int alfa;

        public ColorARGB(int rojo, int verde, int azul, int alfa)
        {
            this.Rojo = rojo;
            this.Verde = verde;
            this.Azul = azul;
            this.Alfa = alfa;
        }

        public int Rojo { get => this.rojo; set => this.rojo = value; }
        public int Verde { get => this.verde; set => this.verde = value; }
        public int Azul { get => this.azul; set => this.azul = value; }
        public int Alfa { get => this.alfa; set => this.alfa = value; }
    }
}
