package controllers;

import modules.Environment;
import play.mvc.Controller;
import play.mvc.Result;
import views.html.profile;

/**
 * Created by Beemen on 03/08/2015.
 */
public class UserController extends Controller {
    public Result ProfileSummary() {
        return ok(profile.render(Environment.Current()));
    }
}
