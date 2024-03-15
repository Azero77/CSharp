//Top level statement have some implicit casting ...
//if we go to .csproj file we will find <ImplicitCasting>enable</ImplicitCasting>
// if we go to obj/debug we will find global.cs

Console.WriteLine(System.Math.PI);
//refrening
string r = "Issam";
//heap -> r (pointing to ) ---> "Issam" {stack} array of characters
//derefrencing
var s  = r.Length;
