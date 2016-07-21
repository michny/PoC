using System;

namespace ProofOfConcept.Attributes
{
    public class LogAttribute : Attribute
    {
        public LogAttribute(LogType[] logTypes)
        {
            LogTypes = logTypes;
        }
        public LogType[] LogTypes { get;set; }
    }
}
