using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using end_user_gui.Models;
using end_user_gui.Models.dummy;

namespace end_user_gui.UI
{
    public class PlaySession : ISession
    {
        private static Dictionary<string, object> _Cache = new Dictionary<string, object>();

        public IOrder CurrentOrder
        {
            get
            {
                String key = OrderKey;
                if (!_Cache.ContainsKey(key))
                {
                    NewOrder();
                }
                Object ret = _Cache[key];
                return (IOrder)ret;
            }
        }

        public void NewOrder()
        {
            _Cache[OrderKey] = new DummyOrder() { User = this.User };
        }

        public String SessionId
        {
            get
            {
                var session = System.Web.HttpContext.Current.Application;

                object uuid = session["uuid"];
                if (uuid == null)
                {
                    uuid = Guid.NewGuid().ToString();
                    session["uuid"] = uuid;
                }
                return uuid as string;
            }
        }

        String OrderKey
        {
            get
            {
                return SessionId + "_CurrentOrder";
            }
        }

        public static readonly Dictionary<String, EndUser> _Users = new Dictionary<string, EndUser>();
        public EndUser User
        {
            get
            {
                if (!_Users.ContainsKey(SessionId))
                {
                    _Users[SessionId] = new EndUser() { Name = SessionId, UniqueId = SessionId };
                }

                return _Users[SessionId];
            }
        }

        private System.Web.SessionState.HttpSessionState _Session;

        public static PlaySession Current
        {
            get
            {
                PlaySession ret = new PlaySession();
                ret._Session = System.Web.HttpContext.Current.Session;
                return ret;
            }
        }
    }
}