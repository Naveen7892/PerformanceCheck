using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;

namespace PerformanceCheck {
   class ShortAndIntDictPerformance {
      static void Main (string[] args) {
         DictionaryPerformance dp1 = new DictionaryPerformance ();
         Console.WriteLine ("Dictionary<int,Object>:\n");
         dp1.TraverseInt ();

         Console.WriteLine ("\nDictionary<short,object>:\n");
         dp1.TraverseShort ();

         Console.WriteLine ("\nDictionary<ushort,object>:\n");
         dp1.TraverseUShort ();

         Console.WriteLine ("\nPress any key to Exit!");
         Console.Read ();
      }
   }

   class DictionaryPerformance {

      const int Iteration = 1000000000;
      const int DictMax = 1000;
      Dictionary<int, object> mDict;
      Stopwatch mTimer1, mTimer2;


      public DictionaryPerformance () {
         mDict = new Dictionary<int, object> ();

         for (int i = 0; i < DictMax; i++) {
            mDict.Add (i, (object)i);
         }

         mTimer1 = Stopwatch.StartNew ();
         for (int i = 0; i < Iteration; i++) {
            // Empty Statement
         }
         mTimer1.Stop ();
         Console.WriteLine (mTimer1.ElapsedMilliseconds + " seconds needed for iterating " + (Iteration) + " times [Empty-Statement]");
         Console.WriteLine ();

      }

      public void TraverseInt () {
         mTimer2 = Stopwatch.StartNew ();
         object mDumb;
         for (int i = 0; i < Iteration; i++) {
            mDumb = mDict[(i % DictMax)];
         }
         mTimer2.Stop ();
         Console.WriteLine (mTimer2.ElapsedMilliseconds + " seconds needed for iterating " + (DictMax) + " records [ Dictionary<int,object> ]");
      }


 
      public void TraverseShort () {
         mTimer2 = Stopwatch.StartNew ();
         object mDumb;
         for (int i = 0; i < Iteration; i++) {
            mDumb = mDict[(i % DictMax)];
         }
         mTimer2.Stop ();
         Console.WriteLine (mTimer2.ElapsedMilliseconds + " seconds needed for accessing " + (DictMax) + " records [ Dictionary<short,object> ]");
      }

      public void TraverseUShort () {
         mTimer2 = Stopwatch.StartNew ();
         object mDumb;
         for (int i = 0; i < Iteration; i++) {
            mDumb = mDict[(i % DictMax)];
         }
         mTimer2.Stop ();
         Console.WriteLine ("{0}", mTimer2.ElapsedMilliseconds + " seconds needed for accessing " + (DictMax) + " records [ Dictionary<ushort,object> ]");
      }

      static double ConvertToSecond (double MilliSecond) {
         return TimeSpan.FromMilliseconds (MilliSecond).TotalSeconds;
      }

   }
}
