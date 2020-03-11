using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Core
{
    public sealed class ExecResult
    {
        public ExecResult()
        {
            Exceptions = new List<Exception>();
            ReturnValues = new Dictionary<string, object>();
        }

        public ExecResult(bool Sucess, Exception Error, object Return)
        {
            ExecutionCompleted = Sucess;
            Exceptions = new List<Exception>();
            ReturnValues = new Dictionary<string, object>();

            Exceptions.Add(Error);
        }

        public ExecResult(bool Sucess, Exception Error, object Return, string Message)
        {
            this.Message = Message;
            ExecutionCompleted = Sucess;

            Exceptions = new List<Exception>();
            ReturnValues = new Dictionary<string, object>();

            Exceptions.Add(Error);

        }

        public bool ExecutionCompleted { get; set; }

        public string Message { get; set; }

        public string Query { get; set; }

        public List<Exception> Exceptions { get; private set; }

        public bool HasExceptions
        {
            get
            {
                if (Exceptions != null)
                {
                    if (Exceptions.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public object ReturnObject { get; set; }

        public Dictionary<string, object> ReturnValues { get; private set; }

        public bool HasReturnValues
        {
            get
            {
                if (ReturnValues != null)
                {
                    if (ReturnValues.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public object GetReturnValue(string ValueKey)
        {
            if (ReturnValues != null)
            {
                if (ReturnValues.ContainsKey(ValueKey))
                {
                    return ReturnValues[ValueKey];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
