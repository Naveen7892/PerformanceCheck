using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;

namespace PerformanceCheck {
   class ShortAndIntIterationPerformance {
      static void Main( string[] args ) {
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

      Dictionary<int, object> mDictWithIntAndObject;
      Dictionary<short, object> mDictWithShortAndObject;
      Dictionary<ushort, object> mDictWithUShortAndObject;
      const int mIntMax = 10000000;
      const int mShortMax = short.MaxValue;
      const int mUShortMax = ushort.MaxValue;
      const int mMilliSecond = 1000; // one second
      Stopwatch mTimer1, mTimer2;


      public DictionaryPerformance( ) {
         mDictWithIntAndObject = new Dictionary<int, object> ();
         mDictWithShortAndObject = new Dictionary<short, object> ();
         mDictWithUShortAndObject = new Dictionary<ushort, object> ();

         for (int i = 0; i < mIntMax; i++) {
            mDictWithIntAndObject.Add (i, (object) i);
         }
         for (short i = 0; i < mShortMax; i++) {
            mDictWithShortAndObject.Add (i, (object) i);
         }
         for (ushort i = 0; i < mUShortMax; i++) {
            mDictWithUShortAndObject.Add (i, (object) i);
         }

      }

      public void TraverseInt( ) {
         mTimer1 = Stopwatch.StartNew ();
         for (int i = 0; i < mIntMax; i++) {
            // Empty Statement
         }
         mTimer1.Stop ();
         Console.WriteLine (ConvertToSecond(mTimer1.ElapsedMilliseconds) + " seconds needed for iterating " + (mIntMax) + " times [Empty-Statement]");
         Console.WriteLine ();

         mTimer2 = Stopwatch.StartNew ();
         object mDumb;
         for (int i = 0; i < mIntMax; i++) {
            mDumb = mDictWithIntAndObject[i];
         }
         mTimer2.Stop ();
         Console.WriteLine (ConvertToSecond (mTimer2.ElapsedMilliseconds) + " seconds needed for iterating " + (mIntMax) + " records [ Dictionary<int,object> ]");
      }


      public void TraverseShort( ) {
         mTimer1 = Stopwatch.StartNew ();
         for (short i = 0; i < mShortMax; i++) {
            // Empty Statement
         }
         mTimer1.Stop ();
         Console.WriteLine (ConvertToSecond (mTimer1.ElapsedMilliseconds) + " seconds needed for accessing " + (mShortMax) + " times [Empty-Statement]");
         Console.WriteLine ();

         mTimer2 = Stopwatch.StartNew ();
         object mDumb;
         for (short i = 0; i < mShortMax; i++) {
            mDumb = mDictWithShortAndObject[i];
         }
         mTimer2.Stop ();
         Console.WriteLine (ConvertToSecond (mTimer2.ElapsedMilliseconds) + " seconds needed for accessing " + (mShortMax) + " records [ Dictionary<short,object> ]");
      }

      public void TraverseUShort( ) {
         mTimer1 = Stopwatch.StartNew ();
         for (ushort i = 0; i < mUShortMax; i++) {
            // Empty Statement
         }
         mTimer1.Stop ();
         Console.WriteLine (ConvertToSecond (mTimer1.ElapsedMilliseconds) + " seconds needed for iterating " + (mUShortMax) + " times [Empty-Statement]");
         Console.WriteLine ();

         mTimer2 = Stopwatch.StartNew ();
         object mDumb;
         for (ushort i = 0; i < mUShortMax; i++) {
            mDumb = mDictWithUShortAndObject[i];
         }
         mTimer2.Stop ();
         Console.WriteLine ("{0}",ConvertToSecond (mTimer2.ElapsedMilliseconds) + " seconds needed for accessing " + (mUShortMax) + " records [ Dictionary<ushort,object> ]");
      }

      private static double ConvertToSecond(double MilliSecond) {
         return TimeSpan.FromMilliseconds (MilliSecond).TotalSeconds;
      }

   }
}
