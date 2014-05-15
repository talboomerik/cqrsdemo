using System;
using System.Web;

namespace NancyFxEndpoint {
  public class CorsHttpModule : IHttpModule {
    #region IHttpModule Members

    public void Dispose() {

    }

    public void Init(HttpApplication context) {
      context.EndRequest += new EventHandler(context_EndRequest);
    }

    void context_EndRequest(object sender, EventArgs e) {
      HttpResponse response = HttpContext.Current.Response;

      response.AddHeader("Access-Control-Allow-Origin", "*");
      //response.AddHeader("Access-Control-Allow-Methods", "OPTIONS,GET,POST,PUT,DELETE");
      //response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, Referer");
    }

    #endregion
  }
}
