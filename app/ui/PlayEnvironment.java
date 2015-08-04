package ui;

import com.google.inject.AbstractModule;
import com.google.inject.Guice;
import models.IEnvironment;
import models.IOrderModule;
import models.ISearchModule;
import models.ISession;


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

    @Override
    public IOrderModule OrderModule() {
        if(_OrderModule == null)
            _OrderModule = GetObject(IOrderModule.class);
        return _OrderModule;
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
                bind(ISearchModule.class).to(models.dummy.SearchModule.class);
                bind(IOrderModule.class).to(models.dummy.OrderModule.class);
            }
        });
    }

    protected <T> T GetObject(Class<T> type)
    {
        return injector.<T>getInstance(type);
    }
}
