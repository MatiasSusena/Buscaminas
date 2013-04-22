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

        public Form1()
        {
            //inicializo 
            InitializeComponent();
            int columnas = 15;
            int filas = 20;
            int anchoBoton = 20;

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
                    matrizBotones[i, j] = boton;
                    panel1.Controls.Add(boton);
                }
        }

        private void chequeaBoton(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;

        }
    }
}
