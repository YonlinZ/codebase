using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace ObserverMode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Heater h = new Heater(60);
            Cooler c = new Cooler(90);
            Thermostat ther = new Thermostat();

            ther.OnTemChangeHandler += h.OnTemChanged;
            ther.OnTemChangeHandler += c.OnTemChanged;

            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) || input.ToUpper() == "OK")
                {
                    break;
                }
                ther.CurrentTem = float.Parse(input);
            }

            Console.ReadKey();
        }
    }

    internal class Heater
    {
        private float _tem;

        public Heater(float tem)
        {
            _tem = tem;
        }

        public void OnTemChanged(object sender, Thermostat.TemArgs currentTem)
        {
            if (currentTem.NewTem < _tem)
            {
                Console.WriteLine("Heater: on");
            }
            else
            {
                Console.WriteLine("Heater: off");
            }

            Console.WriteLine(sender.GetType().FullName);
        }
    }

    internal class Cooler
    {
        private float _tem;

        public Cooler(float tem)
        {
            _tem = tem;
        }

        public void OnTemChanged(object sender, Thermostat.TemArgs currentTem)
        {
            if (currentTem.NewTem > _tem)
            {
                Console.WriteLine("Cooler: on");
            }
            else
            {
                Console.WriteLine("Cooler: off");
            }

            Console.WriteLine(sender.GetType().FullName);
        }
    }

    internal class Thermostat
    {
        public class TemArgs: EventArgs
        {
            public TemArgs(float tem)
            {
                NewTem = tem;
            }

            public float NewTem { get; set; }
        }

        /// <summary>
        /// 标准事件定义规范
        /// </summary>
        public event EventHandler<TemArgs> OnTemChangeHandler = delegate { };
            
        /// <summary>
        /// 存储当前温度
        /// </summary>
        private float _tem;
        public float CurrentTem
        {
            get => _tem;
            set
            {
                if (value != _tem)
                {
                    _tem = value;
                    OnTemChangeHandler?.Invoke(this, new TemArgs(value));
                }
            }
        }
    }
}
