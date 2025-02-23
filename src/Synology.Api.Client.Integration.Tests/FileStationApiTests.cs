﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FluentAssertions;
using Synology.Api.Client.Apis.FileStation.List.Models;
using Synology.Api.Client.Apis.FileStation.Search.Models;
using Synology.Api.Client.Integration.Tests.Fixtures;
using Xunit;

namespace Synology.Api.Client.Integration.Tests
{
    public class FileStationApiTests : IClassFixture<SynologyFixture>
    {
        private readonly SynologyFixture _fixture;

        public FileStationApiTests(SynologyFixture fixture)
        {
            _fixture = fixture;

            _fixture.LoginAsync().Wait();
        }

        [Fact]
        public async void FileStationApi_ListShare_Success()
        {
            // arrange && act
            var listShareResponse = await _fixture
                .Client
                .FileStationApi()
                .ListEndpoint()
                .ListSharesAsync();

            // assert
            listShareResponse.Should().NotBeNull();
        }

        [Fact]
        public async void FileStationApi_List_Success()
        {
            // arrange
            var folderPath = "/shared_folder/dir";
            var request = new FileStationListRequest(folderPath);

            // act
            var listResponse = await _fixture
                .Client
                .FileStationApi()
                .ListEndpoint()
                .ListAsync(request);

            // assert
            listResponse.Should().NotBeNull();
        }

        [Fact]
        public async void FileStationApi_List_SingleFile_Success()
        {
            // arrange
            var folderPath = "/shared_folder/dir";
            var request = new FileStationListRequest(folderPath, patterns: new List<string>
            {
                "existingFile.txt"
            });

            // act
            var listResponse = await _fixture
                .Client
                .FileStationApi()
                .ListEndpoint()
                .ListAsync(request);

            // assert
            listResponse.Should().NotBeNull();
        }

        [Fact]
        public async void FileStationApi_List_MultipleFiles_Success()
        {
            // arrange
            var folderPath = "/shared_folder/dir";
            var request = new FileStationListRequest(folderPath, patterns: new List<string>
            {
                "existingFile.txt",
                "another_existing_file.md"
            });

            // act
            var listResponse = await _fixture
                .Client
                .FileStationApi()
                .ListEndpoint()
                .ListAsync(request);

            // assert
            listResponse.Should().NotBeNull();
        }

        [Fact]
        public async void FileStationApi_UploadFileFromPath_Success()
        {
            // arrange
            var filePath = @"g:\wkk.png"; // TODO: set file path value
            var destination = "/home/Photos/20230518"; // TODO: set destination value

            // act
            var uploadResponse = await _fixture
                .Client
                .FileStationApi()
                .UploadEndpoint()
                .UploadAsync(filePath, destination, true);

            // assert
            uploadResponse.Should().NotBeNull();
        }


        [Fact]
        public async void FileStation_UploadFromByteArray_Success()
        {
            // arrange
            var destination = ""; // TODO: set destination value
            var helloWorld = Encoding.UTF8.GetBytes("Hello World");

            // act
            var uploadResponse = await _fixture
                .Client
                .FileStationApi()
                .UploadEndpoint()
                .UploadAsync(helloWorld, "hello.txt", destination, true);

            // assert
            uploadResponse.Should().NotBeNull();
        }

        [Fact]
        public async void FileStation_UploadFromByteArrayUsingFileReadAllBytes_Success()
        {
            // arrange
            var source = File.ReadAllBytes(""); // TODO: set file path
            var destination = ""; // TODO: set destination value

            // act
            var uploadResponse = await _fixture
                .Client
                .FileStationApi()
                .UploadEndpoint()
                .UploadAsync(source, "hello.txt", destination, true);

            // assert
            uploadResponse.Should().NotBeNull();
        }

        [Fact]
        public async void FileStation_StartExtraction_Success()
        {
            // arrange
            var filePath = ""; // TODO: set file path value
            var destination = ""; // TODO: set destination value

            // act
            var listResponse = await _fixture
                .Client
                .FileStationApi()
                .ExtractEndpoint()
                .StartAsync(filePath, destination, true);

            // assert
            listResponse.Should().NotBeNull();
        }

        [Fact]
        public async void FileStation_ExtractListFiles_Success()
        {
            // arrange
            var filePath = ""; // TODO: set file path value

            // act
            var listResponse = await _fixture
                .Client
                .FileStationApi()
                .ExtractEndpoint()
                .ListFilesAsync(filePath);

            // assert
            listResponse.Should().NotBeNull();
        }

        [Fact]
        public async void FileStation_StartCopy_Success()
        {
            // arrange
            var filePath = ""; // TODO: set file path value
            var destination = ""; // TODO: set destination value

            // act
            var startCopyResponse = await _fixture
                .Client
                .FileStationApi()
                .CopyMoveEndpoint()
                .StartCopyAsync(new[] { filePath }, destination, true);

            // assert
            startCopyResponse.Should().NotBeNull();
        }

        [Fact]
        public async void FileStation_StartMove_Success()
        {
            // arrange
            var filePath = ""; // TODO: set file path value
            var destination = ""; // TODO: set destination value

            // act
            var startCopyResponse = await _fixture
                .Client
                .FileStationApi()
                .CopyMoveEndpoint()
                .StartMoveAsync(new[] { filePath }, destination, true);

            // assert
            startCopyResponse.Should().NotBeNull();
        }

        [Fact]
        public async void FileStation_CopyMoveStatus_Success()
        {
            // arrange
            var taskId = ""; // TODO: set task id

            // act
            var copyStatusResponse = await _fixture
                .Client
                .FileStationApi()
                .CopyMoveEndpoint()
                .GetStatusAsync(taskId);

            // assert
            copyStatusResponse.Should().NotBeNull();
        }

        [Fact]
        public async void FileStation_StopCopyMove_Success()
        {
            // arrange
            var taskId = ""; // TODO: set task id

            // act
            var stopCopyResponse = await _fixture
                .Client
                .FileStationApi()
                .CopyMoveEndpoint()
                .StopAsync(taskId);

            // assert
            stopCopyResponse.Success.Should().BeTrue();
        }

        [Fact]
        public async void FileStation_CreateFolder_Success()
        {
            // arrange
            var paths = new[]
            {
                "/shared_folder/dir/new-dir",
                "/shared_folder/dir2/new-dir"
            };

            // act
            var createFolderResponse = await _fixture
                .Client
                .FileStationApi()
                .CreateFolderEndpoint()
                .CreateAsync(paths, createParentFolders: true);

            // assert
            createFolderResponse.Folders.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async void FileStation_SearchStart_Success()
        {
            // arrange
            var request = new FileStationSearchStartRequest(
                "/shared_folder/dir",
                extension: "rar");

            // act
            var startSearchResponse = await _fixture
                .Client
                .FileStationApi()
                .SearchEndpoint()
                .StartAsync(request);

            // assert
            startSearchResponse.TaskId.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public async void FileStation_SearchList_Success()
        {
            // arrange
            var taskId = ""; // TODO: set task id

            // act
            var listSearchResponse = await _fixture
                .Client
                .FileStationApi()
                .SearchEndpoint()
                .ListAsync(taskId);

            // assert
            listSearchResponse.Should().NotBeNull();
        }


        [Fact]
        public async void FileStationApi_DownloadFileFromPath_Success()
        {
            // arrange
            var path = "/home/Photos/20230518/wkk.png"; // TODO: set path value

            // act
            await _fixture
               .Client
               .FileStationApi()
               .DownloadEndpoint()
               .DownloadAsync(path, $"{DateTime.Now.ToString("yyyyMMddHHmmss")}.png");
        }
    }
}
