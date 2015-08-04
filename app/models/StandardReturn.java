package models;

/**
 * Created by Beemen on 04/08/2015.
 */
public class StandardReturn {
    public boolean Succeeded;
    public int Code;
    public String Text;

    public static StandardReturn OK()
    {
        return new StandardReturn(){{
            Succeeded = true;
            Code = 200;
            Text = "";
        }};
    }

    public static StandardReturn InvalidInput (String text)
    {
        return new StandardReturn(){{
            Succeeded = false;
            Code = 400;
            Text = text;
        }};
    }

    public String toString(){
        return String.format("%b : %d %s",Succeeded,Code,Text);
    }
}
