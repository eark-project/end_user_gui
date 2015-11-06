package models.dummy;

import models.ArchiveSearchObject;
import models.IArchive;
import modules.ISearchModule;

import java.util.*;

/**
 * Created by Beemen on 30/07/2015.
 */
public class SearchModule implements ISearchModule {

    static List<IArchive> _Archives;

    public SearchModule(){
        if(_Archives == null){
            _Archives = new ArrayList<>();

            for (int i=0; i<1000;i++){
                String s = new Integer(i).toString();
                Archive arc = new Archive(){{
                    AipUri(String.format("http://%s-%s.dk", s, UUID.randomUUID()));
                    ReferenceCode("uuid:" + s + "");
                }};
                _Archives.add(arc);
            }
        }
    }
    @Override
    public List<IArchive> Search(ArchiveSearchObject searchObject) {
        List<IArchive> ret = new ArrayList<>();
        for(IArchive archive : _Archives){
            if(searchObject.name == null || archive.ReferenceCode().contains(searchObject.name) || archive.AipUri().contains(searchObject.name))
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
