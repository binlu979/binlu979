using System;
using System.Collections.Generic;
using System.Text;

namespace binlu979.Download
{
   public  interface  IDownloadProgressListener
    {
         void OnDownloadSize(long size);
    }
}
