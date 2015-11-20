using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace end_user_gui.Modules
{
public class FlatLilySearchModule : ISearchModule {
    public List<IArchive> Search(ArchiveSearchObject searchObject) {

        String query = "q=";
        if(searchObject.name == null || searchObject.name.trim() == "")
            query += "*:*";
        else
            query = searchObject.name;

        String url = LilyUrl + query + "&wt=json";
        String response = getStringResult(url);

        JSONParser parser = new JSONParser();
        try {
            JSONObject obj = (JSONObject)parser.parse(response);
            JSONObject responseObject = (JSONObject)obj.get("response");
            JSONArray docs = (JSONArray)responseObject.get("docs");

            List<IArchive>ret = new ArrayList<>();
            for ( Object docObj : docs){
                JSONObject doc = (JSONObject)docObj;
                String path = (String) doc.get("path");
                Archive arc = new Archive();
                arc.AipUri(path);
                arc.ReferenceCode(path);

                ret.add(arc);
            }
            return ret;
        }
        catch (Exception ex){
            return null;
        }
    }

    public IArchive Lookup(String key) {
        return null;
    }


    public String getStringResult(String url){
        StringBuilder builder = new StringBuilder();
        try {

            CloseableHttpClient httpClient = HttpClientBuilder.create().build();
            HttpGet getRequest = new HttpGet(url);
            getRequest.addHeader("accept", "application/json");

            HttpResponse response = httpClient.execute(getRequest);

            if (response.getStatusLine().getStatusCode() != 200) {
                throw new RuntimeException("Failed : HTTP error code : "
                        + response.getStatusLine().getStatusCode());
            }

            BufferedReader br = new BufferedReader(new InputStreamReader((response.getEntity().getContent())));

            String output;
            while ((output = br.readLine()) != null) {
                builder.append(output);
                builder.append("\n");
            }

            httpClient.close();

        } catch (ClientProtocolException e) {

            e.printStackTrace();

        } catch (IOException e) {

            e.printStackTrace();
        }
        return builder.toString();
    }

    public const String LilyUrl = "http://earkdev.ait.ac.at:8983/solr/eark1/select?";
}
