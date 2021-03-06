﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCHelper
{
    public enum GameType
	{
        Minecraft, Information, Other
	}

    public enum LoginType
    {
        Minecraft, PHPBB, None
    }

    public class Profile
    {
        public string GameName { get; set; }
        public string GameDir { get; set; }
        public string CurrentVersion { get; set; }
        public string UpdateURL { get; set; }
        public string DescriptionURL { get; set; }
        public GameType Type { get; set; }
        public string CommandLineArgs { get; set; }
        public LoginType Typelogin { get; set; }

        // Minecraft Settings
        int MaxMem { get; set; }
        int MinMem { get; set; }
        string UserName { get; set; }
        string JavaExe { get; set; }

        public Profile() { }

        public Profile LoadProfile(string ProfileDir)
        {
            if (System.IO.Directory.Exists(ProfileDir) == true)
            {
                if (System.IO.File.Exists(ProfileDir + "\\profile.cfg") == true)
                {
                    using (System.IO.StreamReader ReadConfig = new System.IO.StreamReader(ProfileDir + "\\profile.cfg"))
                    {
                        string TempString = string.Empty;
                        string[] TempPair = null;

                        while (ReadConfig.EndOfStream == false)
                        {
                            //TempString = ReadConfig.ReadLine();

                            if (TempString.StartsWith("#") == true)
                            {
                                continue;// Skip line this is a comment
                            }
                            else
                            {
                                TempPair = ReadConfig.ReadLine().Split('=');

                                switch (TempPair[0])
                                {
                                    case "GameName":
                                        GameName = TempPair[1];
                                        break;
                                    case "GameDir":
                                        GameDir = TempPair[1];
                                        break;
                                    case "CurrentVersion":
                                        CurrentVersion = TempPair[1];
                                        break;
                                    case "UpdateURL":
                                        UpdateURL = TempPair[1];
                                        break;
                                    case "DescriptionURL":
                                        DescriptionURL = TempPair[1];
                                        break;
                                    case "GameType":
                                        if (TempPair[1] == "Minecraft")
                                        {
                                            Type = GameType.Minecraft;
                                        }
                                        else if (TempPair[1] == "Information")
                                        {
                                            Type = GameType.Information;
                                        }
                                        else
                                        {
                                            Type = GameType.Other;
                                        }
                                        break;
                                    case "CommandLineArgs":
                                        CommandLineArgs = TempPair[1];
                                        break;
                                    case "LoginType":
                                        if (TempPair[1] == "Minecraft")
                                        {
                                            Typelogin = LoginType.Minecraft;
                                        }
                                        else if (TempPair[1] == "phpbb")
                                        {
                                            Typelogin = LoginType.PHPBB;
                                        }
                                        else
                                        {
                                            Typelogin = LoginType.None;
                                        }
                                        break;
                                    default:
                                        // Line not included
                                        break;
                                }
                            }

                            TempPair = new string[2];
                        }
                    }
                }
            }

            return this;
        }

        public override string ToString()
        {
            return GameName;
        }
    }
}
