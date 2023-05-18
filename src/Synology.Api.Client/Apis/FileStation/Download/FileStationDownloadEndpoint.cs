using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Synology.Api.Client.ApiDescription;
using Synology.Api.Client.Session;

namespace Synology.Api.Client.Apis.FileStation.Download
{
    public class FileStationDownloadEndpoint : IFileStationDownloadEndpoint
    {
        private readonly ISynologyHttpClient _synologyHttpClient;
        private readonly IApiInfo _apiInfo;
        private readonly ISynologySession _session;
        private readonly IFileSystem _fileSystem;

        public FileStationDownloadEndpoint(ISynologyHttpClient synologyHttpClient, IApiInfo apiInfo, ISynologySession session)
            : this(synologyHttpClient, apiInfo, session, new FileSystem())
        {
        }

        public FileStationDownloadEndpoint(ISynologyHttpClient synologyHttpClient, IApiInfo apiInfo, ISynologySession session, IFileSystem fileSystem)
        {
            _synologyHttpClient = synologyHttpClient;
            _apiInfo = apiInfo;
            _session = session;
            _fileSystem = fileSystem;
        }

        public Task<Stream> DownloadAsync(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            var queryParams = new Dictionary<string, string>
            {
                { "path",  path },
                { "mode", "download" },
            };

            return _synologyHttpClient.GetStreamAsync(_apiInfo, "download", queryParams, _session);
        }
        public async Task DownloadAsync(string path, string outputPath)
        {
            using var stream = await this.DownloadAsync(path);
            using var fs = new FileStream(outputPath, FileMode.OpenOrCreate);

            stream.Seek(0, SeekOrigin.Begin);
            await stream.CopyToAsync(fs);

            await stream.FlushAsync();
        }
    }
}
