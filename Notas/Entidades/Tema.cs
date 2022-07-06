using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tema
    {
        public enum Temas { Rosa, Verde, Azul };

        private Temas tema;
        private Color colorDeLetra;
        private Color colorDeFondoAplicacion;
        private Color colorDeFondoAplicacionAlternativo;
        private Color colorDeBordeDeBoton;
        private Color colorMouseOver;
        private Color colorMouseDown;

        public Color ColorDeLetra { get => this.colorDeLetra; }
        public Color ColorDeFondoAplicacion { get => this.colorDeFondoAplicacion; }
        public Color ColorDeFondoAplicacionAlternativo { get => this.colorDeFondoAplicacionAlternativo; }
        public Color ColorDeBordeDeBoton { get => this.colorDeBordeDeBoton; }
        public Color ColorMouseOver { get => this.colorMouseOver; }
        public Color ColorMouseDown { get => this.colorMouseDown; }
        public Temas TemaAplicado { get => this.tema; }

        public Tema(Temas tema)
        {
            this.tema = tema;
            this.CargarTema();
        }

        private void CargarTema()
        {
            switch (this.tema)
            {
                case Temas.Azul:
                    this.colorDeBordeDeBoton = Color.LightSteelBlue;
                    this.colorDeFondoAplicacion = Color.LightSteelBlue;
                    this.colorDeFondoAplicacionAlternativo = Color.CornflowerBlue;
                    this.colorDeLetra = Color.DarkBlue;
                    this.colorMouseDown = Color.Aqua;
                    this.colorMouseOver = Color.Aquamarine;
                    break;
                case Temas.Rosa:
                    this.colorDeBordeDeBoton = Color.LightPink;
                    this.colorDeFondoAplicacion = Color.LightPink;
                    this.colorDeFondoAplicacionAlternativo = Color.HotPink;
                    this.colorDeLetra = Color.MediumVioletRed;
                    this.colorMouseDown = Color.HotPink;
                    this.colorMouseOver = Color.LavenderBlush;
                    break;
                case Temas.Verde:
                    this.colorDeBordeDeBoton = Color.YellowGreen;
                    this.colorDeFondoAplicacion = Color.YellowGreen;
                    this.colorDeFondoAplicacionAlternativo = Color.OliveDrab;
                    this.colorDeLetra = Color.DarkGreen;
                    this.colorMouseDown = Color.LawnGreen;
                    this.colorMouseOver = Color.GreenYellow;
                    break;
            }
        }
    }
}
