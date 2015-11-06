package modules;

import ui.PlayEnvironment;

/**
 * Created by Beemen on 30/07/2015.
 */
public class Environment {
    private static IEnvironment _Current;

    public static IEnvironment Current() {
        if(_Current == null) {
            _Current = new PlayEnvironment();
        }
        return _Current;
    }

}
