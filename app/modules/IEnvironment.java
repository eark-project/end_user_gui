package modules;

import models.ISession;

/**
 * Created by Beemen on 30/07/2015.
 */
public interface IEnvironment {
    ISearchModule SearchModule();
    IOrderModule OrderModule();
    IArchiveRepository ArchiveRepository();
    ISession Session();
}
