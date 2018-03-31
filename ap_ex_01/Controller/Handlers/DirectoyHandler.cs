﻿using ImageService.Model;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using ImageService.Enums;
using ImageService.Logger;
using ImageService.Logger.Model;

namespace ImageService.Controller.Handlers
{
    public class DirectoyHandler : IDirectoryHandler
    {
        #region Members
        private IImageController mImageController;
        private ILoggingService mLoggingService;
        private FileSystemWatcher mDirWatcher;
        private string mPath;
        private Dictionary<CommandEnum, Action<string[]>> mCommands;
        private readonly string[] mExtenstions = { ".jpg", ".png", ".bmp", ".gif" };
        #endregion

        public event EventHandler<DirectoryCloseEventArgs> DirectoryClosedEvent;

        public DirectoyHandler(IImageController imageController, ILoggingService loggingService, string path)
        {
            mImageController = imageController;
            mLoggingService = loggingService;
            mDirWatcher = new FileSystemWatcher(path)
            {
                EnableRaisingEvents = true
            };
            mPath = path;
            mCommands = new Dictionary<CommandEnum, Action<string[]>>()
            {
                {CommandEnum.CloseCommand, new Action<string[]>(StopHandleDirectory)}
            };
        }

        private void OnNewFileCreated(object sender, FileSystemEventArgs e)
        {
            mLoggingService.Log("OnNewFileCreated: " + e.FullPath, MessageTypeEnum.INFO);
            string filePath = new FileInfo(e.FullPath).FullName;

            if (mExtenstions.Contains(Path.GetExtension(filePath)))
            {
                string[] args = { filePath };
                
                // Tells the controller about the new file
                string msg = mImageController.ExecuteCommand(CommandEnum.NewFileCommand, args, out MessageTypeEnum result);

                mLoggingService.Log(msg, result);
            }
        }

        public void StopHandleDirectory(string[] args)
        {
            mDirWatcher.Created -= OnNewFileCreated;
            mLoggingService.Log("Stopped handling directory " + mPath, MessageTypeEnum.INFO);
        }

        // Invokes the corresponding method
        public void OnCommandRecieved(object sender, CommandRecievedEventArgs e)
        {
            if (!mCommands.TryGetValue(e.CommandID, out Action<string[]> currentCommand))
            {
                return;
            }
            currentCommand.BeginInvoke(e.Args, null, null);
        }

        public void StartHandleDirectory(string dirPath)
        {
            mDirWatcher.Created += new FileSystemEventHandler(OnNewFileCreated);
            mLoggingService.Log("Started handling directory " + mPath, MessageTypeEnum.INFO);
        }
    }
}
