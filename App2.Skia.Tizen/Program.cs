using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace App2.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new App2.App(), args);
            host.Run();
        }
    }
}
