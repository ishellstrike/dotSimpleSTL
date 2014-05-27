using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SimpleSTL
{
    static class Log {
        private static StringBuilder sb = new StringBuilder();
        public static bool updated;
        public static void Add(params IConvertible[] s) {
            sb.AppendFormat("***{0}.{1} [{2}] -- ", DateTime.Now.ToLongTimeString(), DateTime.Now.Millisecond, GetMethodDescription());
            for (int i = 0; i < s.Length; i++) {
                sb.Append(s[i]);
            }
            sb.AppendLine();
            updated = true;
        }

        private static string GetMethodDescription()
        {
            try
            {
                StackTrace st = new StackTrace(true);

                StackFrame frame;
                for (int i = 0; i < st.FrameCount; i++)
                {
                    frame = st.GetFrame(i);
                    string name = frame.GetMethod().DeclaringType.Name;
                    if (name != typeof(Log).Name)
                        return ConvertStackFrameToString(frame);
                }
                return ConvertStackFrameToString(st.GetFrame(0));
            }
            catch (Exception ex)
            {
                return "!!! Trace error !!!" + ex;
            }
        }

        private static string ConvertStackFrameToString(StackFrame frame) {
            string s = frame.GetFileName();
            s = s.Substring(s.LastIndexOf('\\') + 1);
            string res = String.Format("{0} line {1} col {2}", s, frame.GetFileLineNumber(), frame.GetFileColumnNumber());
            return res;
        }

        public static string Get() {
            return sb.ToString();
        }
    }
}
