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

        LoremIpsum li = new LoremIpsum();

        Random r = new Random();
        List<IDissemination> ret = new ArrayList<>();
        for(int i=0;i<c;i++){
            Calendar cal = Calendar.getInstance();
            cal.add(Calendar.DATE, r.nextInt(1000) * -1);
            ret.add(new Dissemination() {{
                CreatedDate(cal.getTime());
                _DummyDescription = li.getWords(3,r.nextInt(50));
            }});
        }
        return ret;
    }
}
