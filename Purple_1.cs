using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_1
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double [] _coefs;
            private int[,] _marks;
            private int _kolvo;
            public string Name
            {
                get
                {
                    return _name;
                }
            }
            public string Surname
            {
                get
                {
                    return _surname;
                }
            }
            public double [] Coefs
            {
                get
                {
                    if (_coefs == null) return null;
                    int n = _coefs.Length;
                    double [] copy = new double [n];
                    Array.Copy(_coefs,copy,n);
                    return copy;
                }
            }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int [,] copy = new int[_marks.GetLength(0),_marks.GetLength(1)];
                    Array.Copy(_marks,copy,_marks.Length);
                    return copy;
                }
            }
            public double TotalScore
            {
                get
                {
                    if (_marks == null || _coefs == null) return 0;
                    double res = 0;
                    for (int i =0;i<4;i++)
                    {
                        int [] value = new int [5];
                        int jmin = 0;
                        int jmax =0;
                        int k = 0;
                        for (int j =0;j<7;j++)
                        {
                            if (_marks[i,j] > _marks[i,jmax]) jmax = j;
                            if (_marks[i,j] < _marks[i,jmin]) jmin = j;
                        }
                        for (int j = 0;j<7;j++)
                        {
                            if (j !=jmax && j!= jmin)
                            {
                                value[k] = _marks[i,j];
                                k++;
                            }
                        }
                        for (int m =0;m<5;m++)
                        {
                            res += value[m] * _coefs[i];
                        }
                    }
                    return res;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname= surname;
                _coefs = new double[] {2.5,2.5,2.5,2.5};
                _marks = new int[,]
                    {{0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0}};
                _kolvo = 0;
            }
            public void SetCriterias(double [] coefs)
            {
                if (_coefs == null || coefs == null || coefs.Length != 4) return;
                for (int i =0;i<4;i++)
                {
                    _coefs[i] = coefs[i];
                }
            }
            public void Jump(int[] marks)
            {
                if (_marks == null || marks == null || marks.Length != 7 || _kolvo >=4) return;
                for (int i =0;i<7;i++)
                {
                    _marks[_kolvo,i] = marks[i];
                }
                _kolvo++;
            }
            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                for (int i = 1, j = 2; i < array.Length;)
                {
                    if (i == 0 || array[i - 1].TotalScore > array[i].TotalScore)
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        Participant temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                        i--;
                    }
                }
            }
            public void Print()
            {
            }
        }
    }
}