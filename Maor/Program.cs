using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

public class Program
{
    record Test(string Name);

    public static void Main()
    {
        var test = JsonSerializer.Serialize(new Test("test"));
        Console.WriteLine(test);
    }
}
// The example displays the following output:
//    The SHA256 hash of Hello World! is: 7f83b1657ff1fc53b92dc18148a1d65dfc2d4b1fa3d677284addd200126d9069.
//    Verifying the hash...
//    The hashes are the same.