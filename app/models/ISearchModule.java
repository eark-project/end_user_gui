package models;

import java.util.List;

/**
 * Created by Beemen on 30/07/2015.
 */
public interface ISearchModule {
    List<IArchive> Search(ArchiveSearchObject searchObject);
    IArchive Lookup(String key);
}
