namespace Maor
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class SimpleClass
    {
        public string JustAString;
        public int JustAnInt;

        public SimpleClass(string justAString, int justAnInt, DateTime justATime)
        {
            this.JustAString = justAString;
            this.JustAnInt = justAnInt;
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// Default Constructor. The fields are filled with some standard values.
        /// <span class="code-SummaryComment"></summary></span>
        public SimpleClass()
        {
            JustAString = "Some useless text";
            JustAnInt = 345678912;
        }
    }
}