using System;
using System.Collections.Generic;

namespace Bit
{
    public class BaseConvertSample
    {
        public void Run()
        {
            BaseConvert convert = new BaseConvert();
            convert.Convert("42135", 5, 7);
        }
    }

    public class BaseConvert
    {
        public string Convert2To10(string s)
        {
            throw new NotImplementedException();
        }

        public string Convert10To2(string s)
        {
            throw new NotImplementedException();
        }

        public string Convert2To8(string s)
        {
            throw new NotImplementedException();
        }

        public string Convert8To2(string s)
        {
            throw new NotImplementedException();
        }


        public string Convert2To16(string s)
        {
            throw new NotImplementedException();
        }

        public string Convert16To2(string s)
        {
            throw new NotImplementedException();
        }


        public string Convert16To10(string s)
        {
            throw new NotImplementedException();
        }

        public string Convert10To16(string s)
        {
            throw new NotImplementedException();
        }

        public string Convert(string s, int srcBase, int destBase)
        {
            BaseNumber n = new BaseNumber(s, srcBase);
            BaseNumber destBaseNumber = new BaseNumber(destBase, srcBase);
            Stack<string> stack = new Stack<string>();
            while (n > 0)
            {
                stack.Push((n % destBaseNumber).ToString());
                 n = n / destBaseNumber;
            }
            return string.Join("", stack);
        }
    }

    public class BaseNumber
    {
        public BaseNumber(int n, int baseNumber)
        {

        }

        public BaseNumber(string s, int baseNumber)
        {

        }

        public static BaseNumber operator +(BaseNumber b, BaseNumber c)
        {
            throw new NotImplementedException();
        }

        public static BaseNumber operator -(BaseNumber b, BaseNumber c)
        {
            throw new NotImplementedException();
        }

        public static BaseNumber operator *(BaseNumber b, BaseNumber c)
        {
            throw new NotImplementedException();
        }

        public static BaseNumber operator /(BaseNumber b, BaseNumber c)
        {
            throw new NotImplementedException();
        }

        public static BaseNumber operator %(BaseNumber b, BaseNumber c)
        {
            throw new NotImplementedException();
        }

        public static bool operator >(BaseNumber b, int c)
        {
            throw new NotImplementedException();
        }

        public static bool operator <(BaseNumber b, int c)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}