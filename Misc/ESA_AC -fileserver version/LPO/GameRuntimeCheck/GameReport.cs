using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LPO.GameRuntimeCheck
{
    class GameReport
    {
        private StringBuilder log;

        public GameReport()
        {
            this.log = new StringBuilder();
        }

        internal void WriteLine(string text)
        {
            log.AppendLine(text);
        }

        internal string toFile()
        {
            string getText;
            getText = log.ToString();

            return getText;
        }
    }
}
