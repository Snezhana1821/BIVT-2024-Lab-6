using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;


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
            public int Distance
            {
                get
                {
                    return _distance;
                }
            }
            public int[] Marks
            {
                get
                {
                    if (_marks == null ) return null;
                    int [] copy = new int [_marks.Length];
                    Array.Copy(_marks, copy,_marks.Length);
                    return copy;
                }
            }
            public int Result
            {
                get
                {
                    if (_distance == -1 || _marks == null) return 0;
                    int res =0;
                    int imax =0,imin =0;
                    for (int i =0;i < _marks.Length;i++)
                    {
                        if (_marks[i] > _marks[imax]) imax = i;
                        if (_marks[i] < _marks[imin]) imin = i;
                    }
                    int[] m2 = new int[_marks.Length - 2];
                    int k =0;
                    for (int i =0;i<_marks.Length;i++)
                    {
                        if (i !=imax && i!=imin)
                        {
                            m2[k] = _marks[i];
                            k++;
                        }
                    }
                    for (int m =0;m<m2.Length;m++)
                    {
                        res+=m2[m];
                    }
                    res+=60;
                    res+=(_distance -120) *2;
                    return res;
                }
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = -1;
                _marks = new int[] {0,0,0,0,0};
            }
            public void Jump(int distance, int[] marks)
            {
                if (marks == null || _marks == null || marks.Length != _marks.Length) return;

                _distance = distance;
                Array.Copy(marks, _marks, marks.Length);
            }
            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                for (int i = 1, j = 2; i < array.Length;)
                {
                    if (i == 0 || array[i - 1].Result >= array[i].Result)
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