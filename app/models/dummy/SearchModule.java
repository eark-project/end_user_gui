package models.dummy;

import models.ArchiveSearchObject;
import models.IArchive;
import models.ISearchModule;

import java.util.*;

/**
 * Created by Beemen on 30/07/2015.
 */
public class SearchModule implements ISearchModule {

    List<IArchive> _Archives;

    public SearchModule(){
        if(_Archives == null){
            _Archives = new ArrayList<>();

            for (int i=0; i<100;i++){
                String s = new Integer(i).toString();
                Archive arc = new Archive(){{
                    AipUri("http:" + s + ".dk");
                    ReferenceCode("uuid:" + s + ";dkqwjh");
                }};
                _Archives.add(arc);
            }
        }
    }
    @Override
    public List<IArchive> Search(ArchiveSearchObject searchObject) {
        List<IArchive> ret = new ArrayList<>();
        for(IArchive archive : _Archives){
            if(searchObject.name == null || archive.ReferenceCode().contains(searchObject.name))
                ret.add(archive);
        }
        return ret;
    }

    @Override
    public IArchive Lookup(String key) {
        for(IArchive archive : _Archives){
            if(archive.ReferenceCode().equals(key))
                return archive;
        }
        return null;
    }
}
