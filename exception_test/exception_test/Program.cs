using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace exception_test
{
    class Program
    {
        static void Main(string[] args)
        {
            only_exc();
            //exc_throw();
        }

        public static void only_exc()
        {
            try
            {
                exc_throw();
            }
            catch (Exception te)
            {
                Console.WriteLine("Exception caught!");
                Console.WriteLine(te.Source);
                int milliseconds = 100000;
                Thread.Sleep(milliseconds);
                
            }
                
                
        }

        public static void exc_throw() //maybe could work like exc_throw(int errnum)
        {
           
            throw new TrialException("Itsa me, Mario!");
        }
    }

    [Serializable]
    public class TrialException : Exception
    {
        public TrialException()
        {

        }

        public TrialException(string msg) : base(msg)
        {
           
        }

        public TrialException(string msg, Exception inner) : base(msg,inner)//dunno wat inner is yet
        {

        }

        public TrialException(SerializationInfo infs, StreamingContext scont)
            : base(infs, scont)
        {

        }
    }
}
