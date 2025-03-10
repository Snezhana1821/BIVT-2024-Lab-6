using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_4
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private double _time;

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
            public double Time
            {
                get
                {
                    return _time;
                }
            }

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _time = 0;
            }

            public void Run(double time)
            {
                if (_time == 0) _time = time;
            }
            public void Print()
            {
                System.Console.WriteLine($" {_name} {_surname} {_time}");
            }
        }

        public struct Group
        {
            private string _name;
            private Sportsman[] _sportsmen;

            public string Name
            {
                get
                {
                    return _name;
                }
            }
            public Sportsman[] Sportsmen
            {
                get
                {
                    return _sportsmen;
                }
            }

            public Group(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[0];
            }
            public Group(Group gr)
            {
                _name = gr.Name;
                if (gr.Sportsmen != null)
                {
                    _sportsmen = gr.Sportsmen;
                }
                else
                {
                    _sportsmen = null;
                }
            }

            public void Add(Sportsman a)
            {
                if (_sportsmen == null) return;
                int n = _sportsmen.Length;
                var copy = new Sportsman[n+1];
                Array.Copy(_sportsmen,copy,n);
                copy[copy.Length-1] = a;
                _sportsmen = copy;
            }

            public void Add(Sportsman[] b)
            {
                if (b == null || _sportsmen == null) return;
                int n2 = b.Length;
                int n = _sportsmen.Length;
                Array.Resize(ref _sportsmen, n+n2);
                for (int i =0;i<n2;i++)
                {
                    _sportsmen[n+i] = b[i];
                }
            }

            public void Add(Group gr)
            {
                if (gr.Sportsmen == null || _sportsmen == null) return;
                int n = _sportsmen.Length;
                Array.Resize(ref _sportsmen, n+gr.Sportsmen.Length);
                for (int i =0;i<gr.Sportsmen.Length;i++)
                {
                    _sportsmen[n+i] = gr.Sportsmen[i];
                }
            }
            public void Sort()
            {
                if (_sportsmen == null) return;

                for(int i = 1, j = 2; i < _sportsmen.Length; )
                {
                    if(i == 0 || _sportsmen[i - 1].Time <= _sportsmen[i].Time)
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        var temp = _sportsmen[i-1];
                        _sportsmen[i-1] = _sportsmen[i];
                        _sportsmen[i] = temp;
                        i--;
                    }
                }
            }

            public static Group Merge(Group a1, Group a2)
            {
                Group res = new Group("Финалисты");
                if (a1.Sportsmen == null || a2.Sportsmen == null) return res;
                var s1 = a1._sportsmen;
                var s2 = a2._sportsmen;
                if (s1 == null) s1 = new Sportsman[0];
                if (s2 == null) s2 = new Sportsman[0];
                res._sportsmen = new Sportsman[s1.Length + s2.Length];
                int i =0, j =0, ind =0;
                while (i < s1.Length && j < s2.Length)
                {
                    if (s1[i].Time <= s2[j].Time)
                    {
                        res._sportsmen[ind] = s1[i];
                        ind++;
                        i++;
                    }
                    else
                    {
                        res._sportsmen[ind] = s2[j];
                        ind++;
                        j++;
                    }
                }
                while (i < s1.Length)
                {
                    res._sportsmen[ind] = s1[i];
                    ind++;
                    i++;
                }
                while (j < s2.Length)
                {
                    res._sportsmen[ind] = s2[j];
                    ind++;
                    j++;
                }
                return res;
            }
            public void Print()
            {

            }
        }
    }
}
