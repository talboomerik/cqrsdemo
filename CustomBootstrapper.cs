using System;
using Nancy;
using System.Linq;
using Nancy.TinyIoc;
using Nancy.Bootstrapper;
using Nancy.Diagnostics;

namespace NancyFxEndpoint {

  public class CustomBootstrapper : DefaultNancyBootstrapper {
    protected override DiagnosticsConfiguration DiagnosticsConfiguration {
      get { return new DiagnosticsConfiguration { Password = "admin" }; }
    }
  }
}
