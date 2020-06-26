using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FacturaControl
{
    class Factura
    {
        String[,] datos = new String[100,3];
        String[,] items = new String[1000, 6];
        int contador_datos = 0;
        int contador_items = 0;
        public int contador_numero_item = 0;
        int contador_lineas_detalle = 0;
        int posItemsY = 0;

        //Para las imagenes
        float ImagePosX = 0;
        float ImagePosY = 0;
        private Image Imagen = null;
        int imageHeight = 0;
        float topMargin = 3;
        int count = 0;
        
        Font printFont = null;
        SolidBrush myBrush = new SolidBrush(Color.Black);
        string fontName = "Lucida Console";
        int fontSize = 8;
        Graphics gfx = null;
        
        public Factura()
        {

        }

        /**
         * Metodo que verifica si existe la impresora
         * String = nombre impresora
         * Return bool
         */
        public bool PrinterExists(string impresora)
        {
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                if (impresora == strPrinter)
                    return true;
            }
            return false;
        }

        /**
         * Metodo que manda los datos a la impresora
         * String = nombre de impresora
         */
        public void PrintFactura(string impresora)
        {
            printFont = new Font(fontName, fontSize, FontStyle.Regular);
            PrintDocument pr = new PrintDocument();
            pr.PrinterSettings.PrinterName = impresora;
            pr.DocumentName = "Impresion de Factura";
            pr.PrintPage += new PrintPageEventHandler(pr_PrintPage);
            pr.Print();
        }

        /**
         * Metodo que disena la pagina que se va a imprimir
         */
        private void pr_PrintPage(Object sender , PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            gfx = e.Graphics;
            DrawImage();
            DrawDatos();
            DrawItems();
        }

        private float YPosition()
        {
            return topMargin + (count * printFont.GetHeight(gfx) + imageHeight);
        }

        private void DrawImage()
        {
            if (Imagen != null)
            {
                try
                {
                    gfx.DrawImage(Imagen, ImagePosX, ImagePosY);
                }
                catch (Exception)
                {
                }
            }
        }

        private void DrawDatos()
        {
            for (int i = 0; i < contador_datos; i++)
            {
                int PosX = int.Parse(datos[i, 1].ToString());
                int PosY = int.Parse(datos[i, 2].ToString());
                gfx.DrawString(datos[i, 0], printFont, myBrush, PosX, PosY, new StringFormat());
            }
        }

        private void DrawItems()
        {
            for (int i = 0; i < contador_items; i++)
            {
                int PosX = int.Parse(items[i, 1]);
                int PosY = int.Parse(items[i, 2]);
                int NumI = int.Parse(items[i, 3]);
                posItemsY = NumI * 4; //incremento en 4 milimitros por el numero de items para la proxima linea
                gfx.DrawString(items[i, 0], printFont, myBrush, PosX, PosY+posItemsY, new StringFormat());
            }
        }

        /**
         * Metodo que agrega una imagen a la impresion
         * Se pueden agregan tantas como se quieran
         */
        public void AddImages(string imagen, int PosX, int PosY)
        {
            Imagen = System.Drawing.Image.FromFile(Environment.CurrentDirectory + @"\imagenes\facturas\" + imagen);
            ImagePosX = PosX;
            ImagePosY = PosY;
        }

        /**
         * Metodo que agrega un string a la impresion
         * Se pueden agregan tantos como se quieran y en la posicion que se desee
         */
        public void AddDatos(string datoTexto, string PosX, string PosY)
        {
            datos[contador_datos, 0] = datoTexto;
            datos[contador_datos, 1] = PosX;
            datos[contador_datos, 2] = PosY;
            contador_datos++;
        }

        /**
         * Metodo que agrega un string a la impresion
         * Se pueden agregan tantas como se quieran y en la posicion que se desee
         * a diferencia del metodo AddDatos este divide el string dado un maximo de caracteres
         */
        public void AddItem(string X, string Y, string MaxChars, string texto)
        {          
            // Al detalle lo mando a comprobar y dividir en dos o mas lineas si es necesario
            //AlignRightText(texto.Length, int.Parse(MaxChars)) + texto;
            DivideItem(texto.Length, int.Parse(MaxChars), texto, X, Y);
        }

        /**
         * Metodo que sirve para alinear un texto a la derecha
         */
        private string AlignRightText(int lenght, int maxChar)
        {
            string espacios = "";
            int spaces = maxChar - lenght;
            for (int x = 0; x < spaces; x++)
                espacios += " ";
            return espacios;
        }

        /**
        * Metodo que sirve dividir en varios renglones los string mas largos que el maximo permitido
        */
        private void DivideItem(int lenghtDet, int maxCharDet, string detalleText, string X, string Y)
        {
            if (lenghtDet > maxCharDet)
            {
                string[] splitDetalle = detalleText.Split(' ');
                string linea = "";
                int i = 0;

                while (i < splitDetalle.Length)
                {
                    // Le sumo palabras a la linea mientras sea menor que el maximo permitido
                    while ((linea.Length < maxCharDet) && (i < splitDetalle.Length))
                    {
                        linea += splitDetalle[i] + " ";
                        i++;
                    } 
                    
                    //crea lineas
                    items[contador_items, 0] = linea;
                    items[contador_items, 1] = X;
                    items[contador_items, 2] = Y;
                    items[contador_items, 3] = (contador_numero_item + contador_lineas_detalle).ToString();
                    linea = "";
                    contador_items++;
                    contador_lineas_detalle++;
                }
            }
            else 
            {
                items[contador_items, 0] = detalleText;
                items[contador_items, 1] = X;
                items[contador_items, 2] = Y;
                items[contador_items, 3] = (contador_numero_item + contador_lineas_detalle).ToString();
                contador_items++;
            }
        }
    }
}
