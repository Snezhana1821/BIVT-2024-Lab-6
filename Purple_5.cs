using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_5
    {
        public struct Response
        {
            private string _animal;
            private string _characterTrait;
            private string _concept;

            public string Animal => _animal;
            public string CharacterTrait => _characterTrait;
            public string Concept => _concept;
            private string [] a
            {
                get{
                    return new string[] {_animal,_characterTrait,_concept};
                }
            }

            public Response(string animal, string characterTrait, string concept)
            {
                _animal = animal;
                _characterTrait = characterTrait;
                _concept = concept;
            }

            public int CountVotes(Response[] responses, int questionNumber)
            {
                if (responses == null ) return 0;
                int res = 0;
                questionNumber--;
                foreach (var b in responses)
                {
                    if (b.a[questionNumber] != " ") res++;
                }
                return res;
            }
            public void Print()
            {
                Console.WriteLine(_animal + " " + _characterTrait + " " + _concept);
            }
        }

        public struct Research
        {
            private string _name;
            private Response[] _responses;
            
            public string Name => _name;
            public Response[] Responses
            {
                get
                {
                    if (_responses == null) return null;

                    var copy = new Response[_responses.Length];
                    Array.Copy(_responses, copy, _responses.Length);
                    return copy;
                }
            }

            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];
            }

            public void Add(string[] answers)
            {
                if (answers == null || _responses == null) return;
                Response res = new Response(answers[0], answers[1],answers[2]);
                Array.Resize(ref _responses, _responses.Length +1);
                _responses[_responses.Length -1] = res;
            }

            public string[] GetTopResponses( int question)
            {
                if(_responses == null) return null;

                string[] array = new string[0];
                string[] answers = new string[1];
                int[] kAnswers = new int[1];

                switch(question)
                {
                    case 1:
                        {
                            for(int i = 0; i < _responses.Length; i++)
                            {
                                if(_responses[i].Animal != null)
                                {
                                    Array.Resize(ref array, array.Length + 1);
                                    array[array.Length - 1] = _responses[i].Animal;
                                }

                            }
                            break;
                        }
                    case 2:
                        {
                            for (int i = 0; i < _responses.Length; i++)
                            {
                                if (_responses[i].CharacterTrait != null)
                                {
                                    Array.Resize(ref array, array.Length + 1);
                                    array[array.Length - 1] = _responses[i].CharacterTrait;
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            for (int i = 0; i < _responses.Length; i++)
                            {
                                if (_responses[i].Concept != null)
                                {
                                    Array.Resize(ref array, array.Length + 1);
                                    array[array.Length - 1] = _responses[i].Concept;
                                }
                            }
                            break;
                        }
                    default: return null;
                }

                answers[0] = array[0];
                kAnswers[0] = 1;

                for (int i = 1; i < array.Length; i++)
                {
                    bool f = false;
                    int k = -1;

                    for (int j = 0; j < answers.Length; j++)
                    {
                        if (array[i] == answers[j])
                        {
                            f = true;
                            k = j;
                            break;
                        }
                    }

                    if (f)
                    {
                        kAnswers[k]++;
                    }
                    else
                    {
                        Array.Resize(ref answers, answers.Length + 1);
                        Array.Resize(ref kAnswers, kAnswers.Length + 1);
                        answers[answers.Length - 1] = array[i];
                        kAnswers[kAnswers.Length - 1] = 1;
                    }
                }

                for(int i = 1, j = 2; i < answers.Length; )
                {
                    if(i == 0 || kAnswers[i - 1] >= kAnswers[i])
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        (kAnswers[i - 1], kAnswers[i]) = (kAnswers[i], kAnswers[i - 1]);
                        (answers[i - 1], answers[i]) = (answers[i], answers[i - 1]);
                        i--;
                    }
                }

                Array.Resize(ref answers, 5);

                return answers;
            }

            public void Print()
            {
                foreach(var a in _responses)
                {
                    a.Print();
                }
            }
        }

    }
}