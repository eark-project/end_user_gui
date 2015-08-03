package models.dummy;

import models.ArchiveSearchObject;
import models.IArchive;
import models.ISearchModule;

import java.util.*;

/**
 * Created by Beemen on 30/07/2015.
 */
public class SearchModule implements ISearchModule {

    @Override
    public List<IArchive> Search(ArchiveSearchObject searchObject) {
        List<IArchive> ret = new ArrayList<>();

        Archive arc0 = new Archive();
        arc0.AipUri("http:123.dk");
        arc0.ReferenceCode("uuid:asfjaf;akf;kas;kA");
        ret.add(arc0);

        Archive arc1 = new Archive();
        arc1.AipUri("http:456.dk");
        arc1.ReferenceCode("uuid:ASJDFASYQWYiuaoisudo");
        ret.add(arc1);

        Archive arc2 = new Archive();
        arc2.AipUri("http:789.dk");
        arc2.ReferenceCode("uuid:qwihggihlkshcklsahiqwiohdal");
        ret.add(arc2);

        return ret;
    }

    @Override
    public IArchive Lookup(String key) {
        for(IArchive archive : Search(null)){
            if(archive.ReferenceCode().equals(key))
                return archive;
        }
        return null;
    }
}
