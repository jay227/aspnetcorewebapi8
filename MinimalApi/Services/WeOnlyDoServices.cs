
using Advance.Base;

namespace MinimalApi.Services
{
    public interface IWeOnlyDo
    {
        void SendFile();
    }
    public class WeOnlyDoServices : IWeOnlyDo
    {
        private WeOnlyDo.Client.FtpDLX? wodFtpDLX;
        private const string CRYPT_KEY = "WlGlEi+kZ9mspnIdNlJi6eb57cu0MKivZrDhs5bzSFM=";
        public void SendFile()
        {
            wodFtpDLX = new WeOnlyDo.Client.FtpDLX();
            wodFtpDLX.LicenseKey = Crypto.Decrypt(CRYPT_KEY);

            wodFtpDLX.Protocol = WeOnlyDo.Client.Protocols.SFTP;
            wodFtpDLX.Port = 22;
            wodFtpDLX.Hostname = "wms.quentelle.com";
            wodFtpDLX.Login = "partner_apAllAboutPeople";
            wodFtpDLX.Password = "91gpBXXFt16f";
            wodFtpDLX.Blocking = true;

            // It's time to connect to server. All we now need to do is call Connect method.
            wodFtpDLX.Connect();

            // If no exception was thrown, we are connected to server, and it's safe to begin upload.
            //wodFtpDLX.PutFile("C:\\local_filename", "/home/");

            // We're done. Disconnect from server.
            wodFtpDLX.Disconnect();

        }
    }
}
