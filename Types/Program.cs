using System;

/*
 There are two types of Variables"
    1- value Types(stores the value) 2- refrence types (stores the refrence)
    C#'s value types are further divided into simple types, enum types, struct types, nullable value types, and tuple value types. C#'s reference types are further divided into class types, interface types, array types, and delegate types.
    
 */
class Types
{
    static void Main(string[] args)
    {
        /*
         * Value Types:                             .NET TYPE
         * 1-byte -> 0-255                          System.Byte
         * 2- sbyte(signed byte) -> -128-> 127      System.SByte    
         * 3-int (4 bytes)                          System.Int32
         * 4- uint
         * 5-short(2 bytes)                         System.Int16
         * 6 - ushort
         * 7-long(8 bytes)(64 bit)
         * 8- ulong
         * The nint and nuint types in the last two rows of the table are native-sized integers. You can use the nint and nuint keywords to define native-sized integers. These are 32-bit integers when running in a 32-bit process, or 64-bit integers when running in a 64-bit process. They can be used for interop scenarios, low-level libraries, and to optimize performance in scenarios where integer math is used extensively.
         */
        int a = 123; //C# leyword
        System.Int32 b = 1_3; //.NET Type and can use digit seperator as you like
        Console.WriteLine(b);
        Console.WriteLine(System.Int32.MaxValue);
        var decimalLiteral = 42;
        var hexLiteral = 0x2A;
        int BinaryLiteral = 0b_00101010;
        var thisislong = 123l;
        var thisisulong = 34ul;

        
        Console.WriteLine(BinaryLiteral);
        Console.WriteLine(nint.MaxValue);
        Console.WriteLine(nint.Size);
        //floating point types
        /// 1- float 4 bytes
        /// 2- double 8 bytes
        /// 3- decimal 16 bytes
        /// The literal without suffix or with the d or D suffix is of type double
        /*The literal with the f or F suffix is of type float
        The literal with the m or M suffix is of type decimal*/
        ///
        Console.WriteLine((float)0 / 0);
        //double and float has constants represtend not a number and infinity and negative infinity
        Console.WriteLine((float)5 / 0);
        Console.WriteLine((float)-5/ 0);
 
    }
}