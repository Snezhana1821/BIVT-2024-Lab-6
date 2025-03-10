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
                    int [,] copy1 = new int[_marks.GetLength(0),_marks.GetLength(1)];
                    Array.Copy(_marks,copy1,_marks.Length);
                    return copy1;
                }
            }
            public double TotalScore
            {
                get
                {
                    if (_marks == null || _coefs == null) return 0;
                    double res = 0;
                    for (int i =0;i<_marks.GetLength(0);i++)
                    {
                        int[] marks = new int[_marks.GetLength(1)];
                        for(int j = 0; j < _marks.GetLength(1); j++)
                        {
                            marks[j] = _marks[i, j];
                        }
                        int jmax = 0;
                        int jmin = 0;
                        for(int j = 0; j < marks.Length; j++)
                        {
                            if(marks[j] > marks[jmax])
                            {
                                jmax = j;
                            }
                            if(marks[j] < marks[jmin])
                            {
                                jmin = j;
                            }
                        }
                        res += (marks.Sum() - marks[jmax] - marks[jmin]) * _coefs[i];
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
                if (_coefs == null || coefs == null || coefs.Length != _coefs.Length) return;
                for (int i =0;i<coefs.Length;i++)
                {
                    _coefs[i] = coefs[i];
                }
            }
            public void Jump(int[] marks)
            {
                if (_marks == null || marks == null || marks.Length != _marks.GetLength(1) || _kolvo >=_marks.GetLength(0)) return;
                for (int i =0;i<_marks.GetLength(1);i++)
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
