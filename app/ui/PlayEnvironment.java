package ui;

import com.google.inject.AbstractModule;
import com.google.inject.Guice;
import models.IEnvironment;
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

    @Override
    public ISession Session() {
        return GetObject(ISession.class);
    }

    private static IEnvironment _Current;
    public static IEnvironment Current() {
        if(_Current == null) {
            _Current = new PlayEnvironment();
        }
        return _Current;
    }

    private com.google.inject.Injector injector;
    public PlayEnvironment(){

        injector = Guice.createInjector(new AbstractModule() {
            @Override
            protected void configure() {
                bind(ISession.class).to(PlaySession.class);
                bind(ISearchModule.class).to(models.dummy.SearchModule.class);
            }
        });
    }



    protected <T> T GetObject(Class<T> type)
    {
        return injector.<T>getInstance(type);
    }
}
