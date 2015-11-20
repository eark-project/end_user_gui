using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using end_user_gui.Models;
using end_user_gui.Modules;

namespace end_user_gui.UI
{
    public class PlayEnvironment : IEnvironment
    {

        public ISearchModule SearchModule()
        {
            return GetObject<ISearchModule>();
        }

        private IOrderModule _OrderModule;
        private IArchiveRepository _ArchiveRepository;

        public IOrderModule OrderModule()
        {
            if (_OrderModule == null)
                _OrderModule = GetObject<IOrderModule>();
            return _OrderModule;
        }

        public IArchiveRepository ArchiveRepository()
        {
            if (_ArchiveRepository == null)
                _ArchiveRepository = GetObject<IArchiveRepository>();
            return _ArchiveRepository;
        }

        public ISession Session()
        {
            return GetObject<ISession>();
        }

        public PlayEnvironment()
        {
            // TODO: put real injection here
            _Types[typeof(ISession)] = typeof(PlaySession);
            _Types[typeof(ISearchModule)] = typeof(Modules.FlatLilySearchModule);
            _Types[typeof(IOrderModule)] = typeof(Models.dummy.OrderModule);
            _Types[typeof(IArchiveRepository)] = typeof(Models.dummy.ArchiveRepository);
        }

        private readonly Dictionary<Type, Type> _Types = new Dictionary<Type, Type>();

        protected T GetObject<T>()
            where T : class
        {
            var targetType = _Types[typeof(T)];
            return targetType.InvokeMember(null, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.CreateInstance, null, null, null) as T;
        }
    }
}