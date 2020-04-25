using System;

namespace lost_session_Apr25
{
    public class PrintHelper
    {
        // declare delegate 
        public delegate void BeforePrint();

        //declare event of type delegate
        public event BeforePrint beforePrintEvent;

        public PrintHelper()
        {
        }

        public void PrintNumber(int num)
        {
            //call delegate method before going to print
            beforePrintEvent?.Invoke();

            Console.WriteLine("Number: {0,-12:N0}", num);
        }

        public void PrintDecimal(int dec)
        {
            beforePrintEvent?.Invoke();

            Console.WriteLine("Decimal: {0:G}", dec);
        }

        public void PrintMoney(int money)
        {
            beforePrintEvent?.Invoke();

            Console.WriteLine("Money: {0:C}", money);
        }

        public void PrintTemperature(int num)
        {
            beforePrintEvent?.Invoke();

            Console.WriteLine("Temperature: {0,4:N1} F", num);
        }

        public void PrintHexadecimal(int dec)
        {
            beforePrintEvent?.Invoke();

            Console.WriteLine("Hexadecimal: {0:X}", dec);
        }
    }
}