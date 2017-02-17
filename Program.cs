using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;

namespace PerformanceCheck {
   class Program {
      static void Main( string[] args ) {
         DictionaryPerformance dp1 = new DictionaryPerformance( );
         Console.WriteLine("Dictionary<int,Object>:\n");
         dp1.TraverseInt( );
         
         Console.WriteLine("\nDictionary<short,object>:\n");
         dp1.TraverseShort( );

         Console.WriteLine ("\nDictionary<ushort,object>:\n");
         dp1.TraverseUShort ();

         Console.WriteLine("\nPress any key to Exit!");
         Console.Read( );
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
         mDictWithIntAndObject = new Dictionary<int, object>( );
         mDictWithShortAndObject = new Dictionary<short, object>( );
         mDictWithUShortAndObject = new Dictionary<ushort, object> ();
         
         for( int i = 0; i < mIntMax; i++ ) {
            mDictWithIntAndObject.Add(i, ( object ) i);
         }
         for( short i = 0; i < mShortMax; i++ ) {
            mDictWithShortAndObject.Add(i, ( object ) i);
         }
         for (ushort i = 0; i < mUShortMax; i++) {
            mDictWithUShortAndObject.Add (i, (object) i);
         }

      }

      public void TraverseInt( ) {
         mTimer1 = Stopwatch.StartNew( );
         int mCount1 = 0;
         while( mTimer1.ElapsedMilliseconds <= mMilliSecond) {
            for( int i = 0; i < mIntMax; i++ ) {
               // Empty Statement
            }
            mCount1++;
         }
         mTimer1.Stop( );
         Console.WriteLine(mTimer1.ElapsedMilliseconds + " Milliseconds iterates for " + ( mCount1 * mIntMax ) + " times [Empty-Statement]");
         Console.WriteLine( );

          mTimer2 = Stopwatch.StartNew( );
         int mCount2 = 0;
         object mDumb;
         while( mTimer2.ElapsedMilliseconds <= mMilliSecond ) {
            foreach( int obj in mDictWithIntAndObject.Keys ) {
               // Just iterates through each key
               mDumb = mDictWithIntAndObject[ obj ];
            }
            mCount2++;
         }
         mTimer2.Stop( );
         Console.WriteLine(mTimer2.ElapsedMilliseconds + " Milliseconds traverses:" + ( mCount2 * mIntMax ) + " records [ Dictionary<int,object> ]");
      }


      public void TraverseShort( ) {
         mTimer1 = Stopwatch.StartNew( );
         short mCount1 = 0;
         while( mTimer1.ElapsedMilliseconds <= mMilliSecond ) {
            for( short i = 0; i < mShortMax; i++ ) {
               // Empty Statement
            }
            mCount1++;
         }
         mTimer1.Stop( );
         Console.WriteLine(mTimer1.ElapsedMilliseconds + " Milliseconds iterates for " + ( mCount1 * mShortMax ) + " times [Empty-Statement]");
         Console.WriteLine( );

         mTimer2 = Stopwatch.StartNew( );
         short mCount2 = 0;
         object mDumb;
         while( mTimer2.ElapsedMilliseconds <= mMilliSecond ) {
            foreach( short obj in mDictWithShortAndObject.Keys ) {
               // Just iterates through each key
               mDumb = mDictWithShortAndObject[ obj ];
            }
            mCount2++;
         }
         mTimer2.Stop( );
         Console.WriteLine(mTimer2.ElapsedMilliseconds + " Milliseconds traverses:" + ( mCount2 * mShortMax ) + " records [ Dictionary<short,object> ]");
      }

      public void TraverseUShort( ) {
         mTimer1 = Stopwatch.StartNew ();
         ushort mCount1 = 0;
         while (mTimer1.ElapsedMilliseconds <= mMilliSecond) {
            for (ushort i = 0; i < mUShortMax; i++) {
               // Empty Statement
            }
            mCount1++;
         }
         mTimer1.Stop ();
         Console.WriteLine (mTimer1.ElapsedMilliseconds + " Milliseconds iterates for " + (mCount1 * mUShortMax) + " times [Empty-Statement]");
         Console.WriteLine ();

         mTimer2 = Stopwatch.StartNew ();
         ushort mCount2 = 0;
         object mDumb;
         while (mTimer2.ElapsedMilliseconds <= mMilliSecond) {
            foreach (ushort obj in mDictWithShortAndObject.Keys) {
               // Just iterates through each key
               mDumb = mDictWithUShortAndObject[obj];
            }
            mCount2++;
         }
         mTimer2.Stop ();
         Console.WriteLine (mTimer2.ElapsedMilliseconds + " Milliseconds traverses:" + (mCount2 * mUShortMax) + " records [ Dictionary<short,object> ]");
      }

   }
}
