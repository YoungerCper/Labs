using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace Laba1
{
    class InterfaceForMatrix
    {

        public Matrix[] list;
        public int count = -1;
        public InterfaceForMatrix()
        {
            Console.Out.Write("Print count matrix : ");
            count = this._ReaderInt();
            list = new Matrix[count];
            this.Main();
        }

        public void Main()
        {
            Console.Out.WriteLine("Choise command : ");
            this._Info();

            string command;

            while (this._onWork)
            {
                Console.Out.Write(">>> ");
                int numberCommand = this._ReaderInt();

                switch (numberCommand)
                {
                    case 0: this._onWork = false;
                        break;
                    case 1: this._CreateMatrix();
                        break;
                    case 2:
                        this._PrintMatrix();
                        break;
                    case 3:
                        this._Info();
                        break;
                    case 4:
                        this._Sum();
                        break;
                    case 5:
                        this._Multy();
                        break;
                    case 6:
                        this._Trans();
                        break;
                    case 7:
                        this._PresentList();
                        break;
                }
            }
        }

        private bool _onWork = true;

        private void _Info()
        {
            Console.Out.WriteLine("1)Create new Matrix");
            Console.Out.WriteLine("2)Print Matrix");
            Console.Out.WriteLine("3)Present command list");
            Console.Out.WriteLine("4)Sum pair of Matrix");
            Console.Out.WriteLine("5)Multy pair of Matrix");
            Console.Out.WriteLine("6)Transposition Matrix");
            Console.Out.WriteLine("7)Presnt list of Matrix");
            
            Console.Out.WriteLine("0)Exit");
        }

        private void _CreateMatrix()
        {
            Console.Out.WriteLine("Print position in list: ");
            int pos = this._ReaderInt();
            Console.Out.WriteLine("Print size of new Matrix: ");
            Console.Out.Write("Height: ");
            int h = this._ReaderInt();
            Console.Out.Write("Leight: ");
            int l = this._ReaderInt();

            list[pos] = this._ReadMatrix(h, l);
        }

        private void _PresentList()
        {

            for(int i = 0; i < this.count; i++)
            {
                if (list[i] != null)Console.Out.WriteLine(i + " - h = " + list[i].Row + " l = " + list[i].Colon);
                else Console.Out.WriteLine(i + " - Empty");
            }
        }

        private void _Sum()
        {
            Console.Out.WriteLine("Print position in list: ");
            int pos = this._ReaderInt();
            Console.Out.WriteLine("First Matrix: ");
            int a1 = this._ReaderInt();
            Console.Out.WriteLine("Second Matrix: ");
            int a2 = this._ReaderInt();
            if (this._MatrixIsCreate(a1) && this._MatrixIsCreate(a2))
                list[pos] = list[a1] + list[a2];
            else
            {
                Console.Out.WriteLine("Matrix isn't create!!!");
            }
        }

        private void _Multy()
        {
            Console.Out.WriteLine("Print position in list: ");
            int pos = this._ReaderInt();
            Console.Out.WriteLine("First Matrix: ");
            int a1 = this._ReaderInt();
            Console.Out.WriteLine("Second Matrix: ");
            int a2 = this._ReaderInt();
            if(this._MatrixIsCreate(a1) && this._MatrixIsCreate(a2))
                list[pos] = list[a1] * list[a2];
            else
            {
                Console.Out.WriteLine("Matrix isn't create!!!");
            }
        }

        private void _Trans()
        {
            Console.Out.WriteLine("Print number Matrix in list: ");
            int a = this._ReaderInt();
            Console.Out.WriteLine("Print position in list: ");
            int pos = this._ReaderInt();
            if(this._MatrixIsCreate(a))
                list[pos] = list[a].Transposition();
            else
            {
                Console.Out.WriteLine("Matrix isn't create!!!");
            }
        }

        private void _PrintMatrix()
        {
            Console.Out.WriteLine("Print number Matrix in list: ");
            int a = this._ReaderInt();
            if (this._MatrixIsCreate(a))
            {
                for (int i = 0; i < list[a].Row; i++)
                {
                    string s = "";
                    for (int j = 0; j < list[a].Colon; j++)
                    {
                        s += list[a].GetElement(i, j).ToString();
                        s += " ";
                    }
                    Console.Out.WriteLine(s);
                }
            }
            else
            {
                Console.Out.WriteLine("Matrix isn't create!!!");
            }
        }

        private int _ReaderInt()
        {
            int result = -1;
            while (result == -1)
            {
                try
                {
                    string c = Console.In.ReadLine();
                    result = int.Parse(c);
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("Pardon, Try again!!!");
                    result = -1;
                }
                
            }
            return result;
        }

        private Matrix _ReadMatrix(int h, int l)
        {
            Matrix m = new Matrix(h, l);
            for(int i = 0; i < h; i++)
            {
                for(int j = 0; j < l; j++)
                {
                    int value = this._ReaderInt();
                    m.SetElement(i, j, value);
                }
            }
            return m;
        }

        private bool _MatrixIsCreate(int pos){return list[pos] != null;}
    }
}
