// Decompiled with JetBrains decompiler
// Type: CocoStudio.Lib.Prism.Logging.TextLogger
// Assembly: CocoStudio.Lib.Prism, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 65DD164F-466A-4C92-9EBC-2D8FF1AF8D80
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Lib.Prism.dll

using CocoStudio.Lib.Prism.Properties;
using System;
using System.Globalization;
using System.IO;

namespace CocoStudio.Lib.Prism.Logging
{
  public class TextLogger : ILoggerFacade, IDisposable
  {
    private readonly TextWriter writer;

    public TextLogger()
      : this(Console.Out)
    {
    }

    public TextLogger(TextWriter writer)
    {
      if (writer == null)
        throw new ArgumentNullException("writer");
      this.writer = writer;
    }

    public void Log(string message, Category category, Priority priority)
    {
      this.writer.WriteLine(string.Format((IFormatProvider) CultureInfo.InvariantCulture, Resources.DefaultTextLoggerPattern, (object) DateTime.Now, (object) category.ToString().ToUpper(CultureInfo.InvariantCulture), (object) message, (object) priority.ToString()));
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing || this.writer == null)
        return;
      this.writer.Dispose();
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }
  }
}
