using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models.dummy
{
    public class SearchModule : ISearchModule
    {

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

        public List<IArchive> Search(ArchiveSearchObject searchObject) {
        List<IArchive> ret = new ArrayList<>();
        for(IArchive archive : _Archives){
            if(searchObject.name == null || archive.ReferenceCode().contains(searchObject.name) || archive.AipUri().contains(searchObject.name))
                ret.add(archive);
        }
        return ret;
    }


        public IArchive Lookup(String key) {
        for(IArchive archive : _Archives){
            if(archive.ReferenceCode().equals(key))
                return archive;
        }
        return null;
    }
    }
}