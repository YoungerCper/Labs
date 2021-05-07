using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Laba1
{
    class Matrix
    {

        private int _colonCount;
        private int _rowCount;

        public int Colon { get { return this._colonCount; } }
        public int Row { get { return this._rowCount; } }

        public Matrix(int sizeX, int sizeY, int startValue = 0)
        {
            this._values = new int[sizeX][];
            this._colonCount = sizeY;
            this._rowCount = sizeX;
            for (int i = 0; i < sizeX; i++)
            {
                this._values[i] = new int[sizeY];
                for (int j = 0; j < sizeY; j++)
                {
                    this._values[i][j] = startValue;
                }
            }
        }

        public int GetElement(int colon, int row) { if (this._isParametrsInNormal(colon, row)) return this._values[colon][row]; else return -1; }
        public void SetElement(int colon, int row, int value) { if (this._isParametrsInNormal(colon, row)) this._values[colon][row] = value; }

        public Matrix Transposition()
        {
            Matrix result = new Matrix(this._colonCount, this._rowCount);

            for(int i = 0; i < this._rowCount; i++)
                 for(int j = 0; j < this._colonCount; j++)                
                    result.SetElement(j, i, this.GetElement(i, j));                     

            return result;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if(Matrix._EqualSize(a, b))
            {
                Matrix result = new Matrix(a._rowCount, a._colonCount);
                for(int i = 0; i < result._rowCount; i++)
                {
                    for(int j = 0; j < result._colonCount; j++)
                    {
                        result.SetElement(i, j, a.GetElement(i, j) + b.GetElement(i, j));
                    }
                }
                return result;
            }
            else
            {
                Matrix result = new Matrix(a._rowCount, a._colonCount);
                return result;
            }
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (Matrix._CanIMulti(a, b))
            {
                Matrix result = new Matrix(a._rowCount, b._colonCount);
                for(int i = 0; i < a._rowCount; i++)
                {
                    for(int j = 0; j < b._colonCount; j++)
                    {
                        int newValue = 0;
                        for( int k = 0; k < a._colonCount; k++)
                        {
                            newValue += a.GetElement(i, k) * b.GetElement(k, j);
                        }
                        result.SetElement(i, j, newValue);
                    }
                }

                return result;
            }
            else
            {
                Matrix result = new Matrix(a._rowCount, a._colonCount);
                return result;
            }
        }

        private int[][] _values;

        private bool _isParametrsInNormal(int colon, int row) { return colon >= 0 && colon < this._colonCount && row >= 0 && row < this._rowCount; }
    
        private static bool _EqualSize(Matrix a, Matrix b) { return a._rowCount == b._rowCount && a._colonCount == b._colonCount;}
        private static bool _CanIMulti(Matrix a, Matrix b) { return a._colonCount == b._rowCount; }
    }
}
