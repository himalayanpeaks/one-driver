using OneDriver.Framework.Libs.Announcer;
using OneDriver.Framework.Libs.Validator;

namespace OneDriver.Framework.Module
{
    public interface IDeviceHAL<TInternalDataHAL> where TInternalDataHAL : BaseDataForAnnouncement, new()
    {
        public delegate void ProcessDataAnnouncer(TInternalDataHAL dataHAL);
        ConnectionError Open(string initString, IValidator validator);
        ConnectionError Close();
        void StartProcessDataAnnouncer();
        void StopProcessDataAnnouncer();
        void AttachToProcessDataEvent(DataTunnel<TInternalDataHAL>.DataEventHandler processDataEventHandler);
        int NumberOfChannels { get; }
    }
}

