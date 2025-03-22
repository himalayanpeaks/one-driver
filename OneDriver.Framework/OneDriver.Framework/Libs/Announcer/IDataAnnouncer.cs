using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDriver.Framework.Libs.Announcer
{
    public interface IDataAnnouncer<TData>
        where TData : BaseDataForAnnouncement

    {
        public void StartProcessDataAnnouncer();
        public void StopProcessDataAnnouncer();

        public void AttachToProcessDataEvent(DataTunnel<BaseDataForAnnouncement>.DataEventHandler bla);

    }
}
