using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;

namespace PerformanceCheck {
   class ShortAndIntRandomPerformance {
      static void Main (string[] args) {
         DictionaryPerformance dp1 = new DictionaryPerformance ();

         Console.WriteLine ("Dictionary<int,Object>:\n");
         dp1.TraverseInt ();
         Console.WriteLine ("Dictionary<ushort,object>:\n");
         dp1.TraverseUShort ();
         Console.WriteLine ("\nDictionary<short,object>:\n");
         dp1.TraverseShort ();


         Console.WriteLine ("\nPress any key to Exit!");
         Console.Read ();
      }
   }

   class DictionaryPerformance {

      Dictionary<int, object> mDictWithIntAndObject;
      Dictionary<short, object> mDictWithShortAndObject;
      Dictionary<ushort, object> mDictWithUShortAndObject;
      Stopwatch mTimer1;
      int mCount = 0;
      object mDumb = 0;
      const int IntMax = 10000000;
      const short ShortMax = short.MaxValue;
      const ushort UShortMax = ushort.MaxValue;
      const int Second = 1000;



      public DictionaryPerformance () {
         mDictWithIntAndObject = new Dictionary<int, object> ();
         mDictWithShortAndObject = new Dictionary<short, object> ();
         mDictWithUShortAndObject = new Dictionary<ushort, object> ();

         for (int i = 0; i < IntMax; i++) {
            mDictWithIntAndObject.Add (i, (object)i);
         }
         for (short i = 0; i < ShortMax; i++) {
            mDictWithShortAndObject.Add (i, (object)i);
         }
         for (ushort i = 0; i < UShortMax; i++) {
            mDictWithUShortAndObject.Add (i, (object)i);
         }

      }

      public void TraverseInt () {

         mTimer1 = Stopwatch.StartNew ();
         mCount = 0;
         while (mTimer1.ElapsedMilliseconds <= Second) {
            for (int i = 0; i < IntMax; i++) {
               mDumb = mDictWithIntAndObject[i];
            }
            mCount++;
         }
         mTimer1.Stop ();
         Console.WriteLine ("Retrieves ~" + (mCount * IntMax) / 1000000 + " million (repeated) records in " + convertMilliSecondToSecond (mTimer1.ElapsedMilliseconds) + " seconds from " + IntMax + " records.");
      }


      public void TraverseShort () {

         mTimer1 = Stopwatch.StartNew ();
         mCount = 0;
         while (mTimer1.ElapsedMilliseconds <= Second) {
            for (short i = 0; i < ShortMax; i++) {
               mDumb = mDictWithShortAndObject[i];
            }
            mCount++;
         }
         mTimer1.Stop ();
         Console.WriteLine ("Retrieves ~" + (mCount * ShortMax) / 1000000 + " million (repeated) records in " + convertMilliSecondToSecond (mTimer1.ElapsedMilliseconds) + " seconds from " + ShortMax + " records.");
      }

      public void TraverseUShort () {

         mTimer1 = Stopwatch.StartNew ();
         mCount = 0;
         while (mTimer1.ElapsedMilliseconds <= Second) {
            for (ushort i = ushort.MinValue; i < UShortMax; i++) {
               mDumb = mDictWithUShortAndObject[i];
            }
            mCount++;
         }
         mTimer1.Stop ();
         Console.WriteLine ("Retrieves ~" + (mCount * UShortMax) / 1000000 + " million (repeated) records in " + convertMilliSecondToSecond (mTimer1.ElapsedMilliseconds) + " seconds from " + UShortMax + " records.");
      }

      private static double convertMilliSecondToSecond (double millisecond) {
         return TimeSpan.FromMilliseconds (millisecond).TotalSeconds;
      }
   }
}
