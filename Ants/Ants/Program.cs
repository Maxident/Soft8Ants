using System;

namespace Ants
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Logic game = new Logic())
            {
                game.Run();
            }
        }
    }
#endif
}

