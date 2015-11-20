package ui;

import com.google.inject.AbstractModule;
import com.google.inject.Guice;
import models.*;
import modules.IArchiveRepository;
import modules.IEnvironment;
import modules.IOrderModule;
import modules.ISearchModule;


/**
 * Created by Beemen on 30/07/2015.
 */
public class PlayEnvironment
        implements IEnvironment {

    @Override
    public ISearchModule SearchModule() {
        return GetObject(ISearchModule.class);
    }

    private IOrderModule _OrderModule;
    private IArchiveRepository _ArchiveRepository;

    @Override
    public IOrderModule OrderModule() {
        if(_OrderModule == null)
            _OrderModule = GetObject(IOrderModule.class);
        return _OrderModule;
    }

    @Override
    public IArchiveRepository ArchiveRepository() {
        if(_ArchiveRepository == null)
            _ArchiveRepository = GetObject(IArchiveRepository.class);
        return _ArchiveRepository;
    }

    @Override
    public ISession Session() {
        return GetObject(ISession.class);
    }

    private com.google.inject.Injector injector;
    public PlayEnvironment(){

        injector = Guice.createInjector(new AbstractModule() {
            @Override
            protected void configure() {
                bind(ISession.class).to(PlaySession.class);
                bind(ISearchModule.class).to(modules.FlatLilySearchModule.class);
                bind(IOrderModule.class).to(models.dummy.OrderModule.class);
                bind(IArchiveRepository.class).to(models.dummy.ArchiveRepository.class);
            }
        });
    }

    protected <T> T GetObject(Class<T> type)
    {
        return injector.<T>getInstance(type);
    }
}
