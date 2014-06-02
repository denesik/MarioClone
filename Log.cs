using System;

namespace OGLGame
{

    public class Log
    {
        /// Защищенный конструктор нужен, чтобы предотвратить создание экземпляра класса Singleton
        protected Log() { }

        private sealed class SingletonCreator
        {
            private static readonly Log instance = new Log();
            public static Log Instance { get { return instance; } }
        }

        public static Log Instance
        {
            get { return SingletonCreator.Instance; }
        }

        public void Write(string s)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"log.txt", true))
            {
                file.WriteLine(s);
            }
        }

    }


}