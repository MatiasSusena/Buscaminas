using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 *  NOMBRE: Matías
 *  APELLIDOS: Susena Tizón
 *  1º D.A.M.
 *  
 * 
 */

namespace Buscaminas
{
    public partial class Form1 : Form
    {
        //declaro el array de botones
        Button[,] matrizBotones;
            int columnas = 20;
            int filas = 20;
            int anchoBoton = 20;
            int minas = 40;

        //si el tag es 1 es que no hay bomba
        //si el tag es 2 es que si hay bomba
        public Form1()
        {
            //inicializo 
            InitializeComponent();


            //calculo el ancho y el alto de la pantalla
            //partiendo del alto y ancho de cada boton y
            //multiplicandolo por el numero de botones que
            //quiero crear
            this.Height = columnas * anchoBoton + 40;
            this.Width = filas * anchoBoton + 20;

            //Declaro un array de 2 dimensiones(2D) de botones
            matrizBotones = new Button[filas, columnas];

            //creo los botones
            for (int i = 0; i < filas; i++)
                for (int j = 0; j < columnas; j++)
                {
                    //genera el nuevo boton
                    Button boton = new Button();
                    //boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

                    //les asigno un ancho y un alto
                    boton.Width = anchoBoton;
                    boton.Height = anchoBoton;
                    //le asigno/pongo una coordenada.
                    //Nos devuelve la coordenada donde va el boton
                    boton.Location = new Point(i * anchoBoton, j * anchoBoton);
                    //Esta es la forma de añadir / asociar un evento a mano
                    boton.Click += chequeaBoton;
                    boton.Tag = "0";
                    matrizBotones[i, j] = boton;
                    panel1.Controls.Add(boton);
                }

            poneMinas();
            cuentaMinas();
        }


        private void cuentaMinas()
        {
            for (int i = 0; i < filas; i++)
                for (int j = 0; j < columnas; j++)
                {
                    int numeroBombas = 0;

                    for (int k = -1; k < 2; k++)
                    {
                        for (int m = -1; m < 2; m++)
                        {
                            int f = i + k;
                            int c = j + m;
                            if ((c < columnas) && (c >= 0) &&
                                (f < filas) && (f >= 0))
                            {
                                if (matrizBotones[c, f].Tag == "B")
                                {
                                    numeroBombas++;
                                }
                            }
                        }
                    }
                    if ((matrizBotones[j, i].Tag != "B") &&
                        (numeroBombas > 0))
                    {
                        matrizBotones[j, i].Tag = numeroBombas.ToString();
                        matrizBotones[j, i].Text = numeroBombas.ToString();
                    }
                }
        } //fin del cuentaMinas

        //este metodo pone las minas en su posicion de forma aleatoria
        private void poneMinas() {
            Random aleatorio = new Random();
            int x, y = 0;
            for (int i = 0; i < minas; i++) 
            {
                x = aleatorio.Next(filas);
                y = aleatorio.Next(columnas);
                while (!matrizBotones[y, x].Tag.Equals("0"))
                {
                    x = aleatorio.Next(filas);
                    y = aleatorio.Next(columnas);
                }
                matrizBotones[y, x].Tag = "B";
                matrizBotones[y, x].Text = "B";
                matrizBotones[y, x].BackColor = Color.Orange;
            }
        }

        private void chequeaBoton(object sender, EventArgs e)
        {   
            //(sender as Button).Enabled = false;
            Button b = (sender as Button);
            //b.BackColor = Color.DarkKhaki;
            int columna = b.Location.X / anchoBoton;
            int fila = b.Location.Y / anchoBoton;


            if (matrizBotones[columna, fila].Tag == "0")
            {
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {

                        int f = fila + i;
                        int c = columna + j;
                        if ((c < columnas) && (c >= 0) && (f < filas) && (f >= 0))
                        {

                           
                            if (matrizBotones[c, f].FlatStyle != System.Windows.Forms.FlatStyle.Flat)
                            {
                                chequeaBoton(matrizBotones[columna + j, fila + i], e);
                            }
                        }
                    }
                }
            }

            //    //Pintamos de fuchsia usando la matriz y no el sender
            //    //Pintamos a la izquierda y derecha de nuestro boton pulsado
            //    matrizBotones[columna - 1, fila].BackColor = Color.Fuchsia;
            //matrizBotones[columna, fila].BackColor = Color.Fuchsia;
            //matrizBotones[columna+1, fila].BackColor = Color.Fuchsia;

            ////Pintamos los 3 botones de arriba de nuestro boton pulsado
            //matrizBotones[columna - 1, fila-1].BackColor = Color.Fuchsia;
            //matrizBotones[columna, fila-1].BackColor = Color.Fuchsia;
            //matrizBotones[columna + 1, fila-1].BackColor = Color.Fuchsia;

            ////Pintamos los 3 botones de abajo de nuestro boton pulsado
            //matrizBotones[columna - 1, fila +1].BackColor = Color.Fuchsia;
            //matrizBotones[columna, fila +1].BackColor = Color.Fuchsia;
            //matrizBotones[columna + 1, fila +1].BackColor = Color.Fuchsia;


        }
    }
}
