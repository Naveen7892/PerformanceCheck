using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;

namespace PerformanceCheck {
   class DictionaryIntAndObject {
      static void Main (string[] args) {
         DictionaryPerformance dp1 = new DictionaryPerformance ();
         dp1.TraverseDict ();

         Console.WriteLine ("\nPress any key to Exit!");
         Console.ReadKey ();
      }
   }

   class DictionaryPerformance {

      const int Iteration = 1000000000;
      const int DictMax = 1000;
      Dictionary<int, object> mDict;
      Stopwatch mTimer1;


      public DictionaryPerformance () {
         mDict = new Dictionary<int, object> ();

         for (int i = 0; i < DictMax; i++) {
            mDict.Add (i, (object)i);
         }
         Console.WriteLine ("Dictionary key type: int");
         Console.WriteLine ("\nDictionary value type: object");
         Console.WriteLine ("\nDictionary Count: " + mDict.Count);
         Console.WriteLine ("\nIterations: " + Iteration);
      }

      public void TraverseDict () {
         mTimer1 = Stopwatch.StartNew ();
         object mDumb;
         for (int i = 0; i < Iteration; i++) {
            mDumb = mDict[(i % DictMax)];
         }
         mTimer1.Stop ();
         Console.WriteLine ("\nTime Taken: " + mTimer1.ElapsedMilliseconds + " millisecond");
         Console.WriteLine ("\n" + CalculateIterationsPerMicroSecond (mTimer1.ElapsedMilliseconds) + " iterations can be done in 1 microsecond.");
      }

      static string CalculateIterationsPerMicroSecond (double MilliSecond) {
         if (MilliSecond == 0) MilliSecond = 0.001;
         return "~" + (int)Math.Round((Iteration / (MilliSecond * 1000)),3);
      } 

   }
}
