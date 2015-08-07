package models.dummy;

import models.*;
import models.IDissemination;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import de.svenjacobs.loremipsum.LoremIpsum;

/**
 * Created by Beemen on 06/08/2015.
 */
public class ArchiveRepository implements IArchiveRepository {

    LoremIpsum _LoremIpsum = new LoremIpsum();
    Random _RandomGenerator = new Random();

    @Override
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
            Calendar cal = Calendar.getInstance();
            cal.add(Calendar.DATE, _RandomGenerator.nextInt(1000) * -1);
            ret.add(new Dissemination() {{
                CreatedDate(cal.getTime());
                _DummyDescription = _LoremIpsum.getWords(3, _RandomGenerator.nextInt(50));
            }});
        }
        return ret;
    }

    @Override
    public IDissemination LookupDIP(String keyString) {
        return new Dissemination(){{
            _DummyDescription = _LoremIpsum.getWords(3, _RandomGenerator.nextInt(50));
        }};
    }
}
