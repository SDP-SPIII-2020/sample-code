using System;

namespace lost_session_Apr25
{
    class Number
    {
        private PrintHelper _printHelper;

        public Number(int val)
        {
            _value = val;

            _printHelper = new PrintHelper();
            //subscribe to beforePrintEvent event
            _printHelper.beforePrintEvent += printHelper_beforePrintEvent;
        }

        //beforePrintevent handler
        void printHelper_beforePrintEvent() =>
            Console.WriteLine("BeforPrintEventHandler: PrintHelper is going to print a value");

        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public void PrintMoney() => _printHelper.PrintMoney(_value);

        public void PrintNumber() => _printHelper.PrintNumber(_value);
    }
}