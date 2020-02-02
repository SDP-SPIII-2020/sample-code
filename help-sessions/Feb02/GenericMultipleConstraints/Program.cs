using System;

namespace GenericMultipleConstraints
{
    class Base { }
    class Test<T, U>
        where U : struct
        where T : Base, new()
    { }

    class MyClass : Base
    {
        public MyClass()
        {
            
        }
    }

    struct MyStruct
    {
        
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Test<MyClass,MyStruct>();
        }
    }
}