using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using end_user_gui.UI;

namespace end_user_gui.Modules
{
    public class Environment
    {
        private static IEnvironment _Current;

        public static IEnvironment Current()
        {
            if (_Current == null)
            {
                _Current = new PlayEnvironment();
            }
            return _Current;
        }

    }
}