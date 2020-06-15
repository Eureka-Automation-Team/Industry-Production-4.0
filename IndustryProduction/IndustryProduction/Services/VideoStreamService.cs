using RtspClientSharp;
using RtspClientSharp.RawFrames.Audio;
using RtspClientSharp.RawFrames.Video;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IndustryProduction.Services
{
    public class VideoStreamService : IVideoStreamService
    {
        private HttpClient _client;

        public VideoStreamService()
        {
            _client = new HttpClient();
        }

        public async Task<Stream> GetVideoByName(string name)
        {
            var urlBlob = string.Empty;
            switch (name)
            {
                case "earth":
                    urlBlob = "https://anthonygiretti.blob.core.windows.net/videos/earth.mp4";
                    break;
                case "nature1":
                    urlBlob = "https://anthonygiretti.blob.core.windows.net/videos/nature1.mp4";
                    break;
                case "nature2":
                    urlBlob = "https://anthonygiretti.blob.core.windows.net/videos/nature1.mp4";
                    break;
                default:
                    urlBlob = "https://anthonygiretti.blob.core.windows.net/videos/nature2.mp4";
                    break;
            }
            return await _client.GetStreamAsync(urlBlob);
        }

        public async void GetVideoByUrlAsync(string url)
        {
            var cancellationTokenSource = new CancellationTokenSource();

            var serverUri = new Uri("rtsp://192.168.4.98:88/live/video");
            //var serverUri = new Uri(url);
            var credentials = new NetworkCredential("admin", "admin");
            var connectionParameters = new ConnectionParameters(serverUri, credentials);
            connectionParameters.RtpTransport = RtpTransportProtocol.TCP;

            using (var rtspClient = new RtspClient(connectionParameters))
            {
                rtspClient.FrameReceived += (sender, frame) =>
                {
                    //process (e.g. decode/save to file) encoded frame here or 
                    //make deep copy to use it later because frame buffer (see FrameSegment property) will be reused by client
                    switch (frame)
                    {
                        case RawH264IFrame h264IFrame:
                        case RawH264PFrame h264PFrame:
                        case RawJpegFrame jpegFrame:
                        case RawAACFrame aacFrame:
                        case RawG711AFrame g711AFrame:
                        case RawG711UFrame g711UFrame:
                        case RawPCMFrame pcmFrame:
                        case RawG726Frame g726Frame:
                            break;
                    }
                };
            
                await rtspClient.ConnectAsync(cancellationTokenSource.Token);
                await rtspClient.ReceiveAsync(cancellationTokenSource.Token);
            }
        }

        ~VideoStreamService()
        {
            if (_client != null)
                _client.Dispose();
        }
    }
}
