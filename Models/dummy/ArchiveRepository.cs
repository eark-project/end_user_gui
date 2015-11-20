using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models.dummy
{
    public class ArchiveRepository : IArchiveRepository
    {

        LoremIpsum _LoremIpsum = new LoremIpsum();
        Random _RandomGenerator = new Random();

        Dissemination CreateDissemination(){
        Calendar cal = Calendar.getInstance();
        cal.add(Calendar.DATE, _RandomGenerator.nextInt(1000) * -1);
        return new Dissemination() {{
            CreatedDate(cal.getTime());
            _DummyDescription = _LoremIpsum.getWords(3, _RandomGenerator.nextInt(50));
        }};
    }

        public List<IDissemination> GetDIPs(IArchive archive) {
        Pattern p = Pattern.compile("[0-9]+");
        String inp = archive.ReferenceCode();
        Matcher m = p.matcher(inp);

        String s = "";
        while (m.find()){
            s += inp.substring(m.start(),m.end());
        }
        Integer c = Integer.parseInt(s)%3;

        List<IDissemination> ret = new ArrayList<>();
        for(int i=0;i<c;i++){
            ret.add(CreateDissemination());
        }
        return ret;
    }

        public IDissemination LookupDIP(String keyString)
        {
            return CreateDissemination();
        }
    }
}