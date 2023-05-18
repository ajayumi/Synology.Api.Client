using System.IO;
using System.Threading.Tasks;

namespace Synology.Api.Client.Apis.FileStation.Download
{
    public interface IFileStationDownloadEndpoint
    {
        /// <summary>
        /// Download a file 
        /// </summary>
        /// 
        /// <example>
        /// This sample shows how to call the <see cref="DownloadAsync"/> method.
        /// <code>
        /// var DownloadResult = await client.FileStationApi().DownloadEndpoint().DownloadAsync("/my_share/docs");
        /// </code>
        /// </example>
        /// 
        /// <param name="path">
        /// One or more file/folder paths starting with a shared folder to be downloaded, 
        /// separated by a comma "," and around the brackets. 
        /// When more than one file is to be downloaded,
        /// files/folders will be compressed as a zip file.
        /// </param>
        /// <returns></returns>
        Task<Stream> DownloadAsync(string path);

        /// <summary>
        /// Download a file 
        /// </summary>
        /// 
        /// <example>
        /// This sample shows how to call the <see cref="DownloadAsync"/> method.
        /// <code>
        /// var DownloadResult = await client.FileStationApi().DownloadEndpoint().DownloadAsync("/my_share/docs");
        /// </code>
        /// </example>
        /// 
        /// <param name="path">
        /// One or more file/folder paths starting with a shared folder to be downloaded, 
        /// separated by a comma "," and around the brackets. 
        /// When more than one file is to be downloaded,
        /// files/folders will be compressed as a zip file.
        /// </param>
        /// <param name="outputPath"></param>
        /// <returns></returns>
        Task DownloadAsync(string path, string outputPath);

    }
}
