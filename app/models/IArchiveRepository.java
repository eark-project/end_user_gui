package models;

import java.util.List;

/**
 * Created by Beemen on 06/08/2015.
 */
public interface IArchiveRepository {
    List<IDissemination> GetDIPs(IArchive archive);
}
