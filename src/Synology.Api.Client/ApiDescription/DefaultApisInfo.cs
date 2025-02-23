﻿using Synology.Api.Client.Apis.Info.Models;
using Synology.Api.Client.Constants;

namespace Synology.Api.Client.ApiDescription
{
    public class DefaultApisInfo : IApisInfo
    {
        private const string FileStationSessionName = "FileStation";
        private const string DownloadStationSessionName = "DownloadStation";

        /// <summary>
        /// Updates the ApisInfo object used to determine the path for each API.
        /// Use the following example to obtain the API descriptions.
        /// <code>var infoQueryResponse = await InfoApi().QueryAsync()</code>
        /// </summary>
        /// <param name="infoQueryResponse">The response from the InfoApi().QueryAsync() method.</param>
        /// <returns>The updated ApisInfo object.</returns>
        public static DefaultApisInfo FromInfoQueryResponse(IApisInfo current, InfoQueryResponse infoQueryResponse)
        {
            return new DefaultApisInfo
            {
                AuthApi = { Path = infoQueryResponse.AuthApi?.Path ?? current.AuthApi.Path },
                DownloadStationTaskApi = { Path = infoQueryResponse.DownloadStationTaskApi?.Path ?? current.DownloadStationTaskApi.Path },
                FileStationCopyMoveApi = { Path = infoQueryResponse.FileStationCopyMoveApi?.Path ?? current.FileStationCopyMoveApi.Path },
                FileStationCreateFolderApi = { Path = infoQueryResponse.FileStationCreateFolderApi?.Path ?? current.FileStationCreateFolderApi.Path },
                FileStationExtractApi = { Path = infoQueryResponse.FileStationExtractApi?.Path ?? current.FileStationExtractApi.Path },
                FileStationListApi = { Path = infoQueryResponse.FileStationListApi?.Path ?? current.FileStationListApi.Path },
                FileStationUploadApi = { Path = infoQueryResponse.FileStationUploadApi?.Path ?? current.FileStationUploadApi.Path },
                FileStationSearchApi = { Path = infoQueryResponse.FileStationSearchApi?.Path ?? current.FileStationSearchApi.Path },
                FileStationDownloadApi = { Path = infoQueryResponse.FileStationDownloadApi?.Path ?? current.FileStationDownloadApi.Path },
            };
        }

        public IApiInfo InfoApi { get; set; } = new ApiInfo(
            ApiNames.InfoApiName,
            "query.cgi",
            1);

        public IApiInfo AuthApi { get; set; } = new ApiInfo(
            ApiNames.AuthApiName,
            "entry.cgi",
            6);

        public IApiInfo DownloadStationTaskApi { get; set; } = new ApiInfo(
            ApiNames.DownloadStationTaskApiName,
            "DownloadStation/task.cgi",
            1,
            DownloadStationSessionName);

        public IApiInfo FileStationCopyMoveApi { get; set; } = new ApiInfo(
            ApiNames.FileStationCopyMoveApiName,
            "entry.cgi",
            3,
            FileStationSessionName);

        public IApiInfo FileStationCreateFolderApi { get; set; } = new ApiInfo(
            ApiNames.FileStationCreateFolderApiName,
            "entry.cgi",
            2,
            FileStationSessionName);

        public IApiInfo FileStationExtractApi { get; set; } = new ApiInfo(
            ApiNames.FileStationExtractApiName,
            "entry.cgi",
            2,
            FileStationSessionName);

        public IApiInfo FileStationListApi { get; set; } = new ApiInfo(
            ApiNames.FileStationListApiName,
            "entry.cgi",
            2,
            FileStationSessionName);

        public IApiInfo FileStationUploadApi { get; set; } = new ApiInfo(
            ApiNames.FileStationUploadApiName,
            "entry.cgi",
            2,
            FileStationSessionName);

        public IApiInfo FileStationSearchApi { get; set; } = new ApiInfo(
            ApiNames.FileStationSearchApiName,
            "entry.cgi",
            2,
            FileStationSessionName);

        public IApiInfo FileStationDownloadApi { get; set; } = new ApiInfo(
            ApiNames.FileStationDownloadApiName,
            "entry.cgi",
            2,
            FileStationSessionName);

    }
}