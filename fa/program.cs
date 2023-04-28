using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }
    public class FA1
    {
        public static State q0 = new State()
        {
            Name = "q0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q1 = new State()
        {
            Name = "q1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q2 = new State()
        {
            Name = "q2",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q3 = new State()
        {
            Name = "q3",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public State q4 = new State()
        {
            Name = "q4",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        State InitialState = q0;

        public FA1()
        {
            q0.Transitions['0'] = q1;
            q0.Transitions['1'] = q2;
            q1.Transitions['0'] = q4;
            q1.Transitions['1'] = q3;
            q2.Transitions['0'] = q3;
            q2.Transitions['1'] = q2;
            q3.Transitions['0'] = q4;
            q3.Transitions['1'] = q3;
            q4.Transitions['0'] = q4;
            q4.Transitions['1'] = q4;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;         // результат true если в конце финальное состояние 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "0000010111";
            FA fa = new FA();
            bool? result = fa.Run(s);
            Console.WriteLine(result);
        }
    }
}