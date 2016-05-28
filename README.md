Windows Communication Foundation in Raw form
==

WCFRaw is a framework for using Microsoft's [WCF](https://msdn.microsoft.com/en-us/library/ms731082%28v=vs.110%29.aspx) at a lower level then the standard way of setting a [Service Reference](https://msdn.microsoft.com/en-us/library/bb628652.aspx) in Visual Studio and having the client stub code generated for you.

The motivation for writing the original came from a complex industry standard XML Schema used in a service WSDL we were trying to consume that the standard Service Reference was unable to parse. It is rewritten here for the public.

WCFRaw can use XML in [Linq to XML](https://msdn.microsoft.com/en-us/library/bb387098.aspx) [XElement](https://msdn.microsoft.com/en-us/library/system.xml.linq.xelement%28v=vs.110%29.aspx) form, or XML bound to .NET objects using [Xsd.exe](https://msdn.microsoft.com/en-us/library/sh1e66zd%28v=vs.85%29.aspx) or similar.

For the asynchronous parts of the code, WCFRaw uses the [Reactive Extensions](https://msdn.microsoft.com/en-us/data/gg577609.aspx) for .NET.

It targets Silverlight as many years ago this was one of the client app we were using. It also works in a standard .NET app, however to open the solutions properly you need the Silverlight SDK installed.  

*NOTE: I was studying [Scala](http://www.scala-lang.org/) and [Category Theory](https://en.wikipedia.org/wiki/Category_theory) when I originally wrote this hence the A -> B stuff.*
