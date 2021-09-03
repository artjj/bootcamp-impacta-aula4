using System;
using System.Collections.Generic;
using System.Text;

namespace EntendendoPOO
{
    class ValidationUtil<T>
    {
        public bool isValid(T data)
        {
            var result = false;
            if (data is String && data != null)
            {
                Console.WriteLine("String válida");
            }
            else if (data is int && data != null)
            {
                Console.WriteLine("INT válida");
            }
            else if (data is bool && data != null)
            {
                Console.WriteLine("Bool válida");
            }
            return result;
        }
    }
}
