using System.Collections.Generic;

namespace ProjectI.UI
{
    public class RouterArgs
    {
        private Dictionary<string, object> args = new();

        public RouterArgs(Dictionary<string, object> args)
        {
            this.args = new(args);
        }

        public T? Get<T>(string key) where T : class
        {
            if (args.TryGetValue(key, out var value))
            {
                return value as T;
            }

            return null;
        }
    }
}