using System;

namespace ZatackaLegacy
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            using (Engine Engine = new Engine())
            {
                Engine.Run();
            }
        }
    }
#endif
}