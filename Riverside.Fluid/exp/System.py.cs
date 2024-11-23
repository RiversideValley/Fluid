// System
// 
// A professional yet usable programming framework.
// 

using System.Collections.Generic;

using _sys = sys;
using Riverside.Fluid;

using _process = IronPython.Modules.PosixSubprocess;

using _time = IronPython.Modules.PythonDateTime.time;


using System;
using IronPython.Modules;
using IronPython.Runtime.Operations;
// using PListLib = IronPython.Modules.

namespace Riverside.Fluid.Experimental;

public static class System {
    
    // System.Legacy
    //     
    //     Foundation class for the purpose of providing legacy Python modules for more.. refined use.
    public class Legacy {
        
        // Constants/functions for interpreting results of os.stat() and os.lstat().
        // 
        //         Suggested usage: from stat import *
        //         
        public class _stat {
            
            public object ST_MODE = 0;
            
            public object ST_INO = 1;
            
            public object ST_DEV = 2;
            
            public object ST_NLINK = 3;
            
            public object ST_UID = 4;
            
            public object ST_GID = 5;
            
            public object ST_SIZE = 6;
            
            public object ST_ATIME = 7;
            
            public object ST_MTIME = 8;
            
            public object ST_CTIME = 9;
            
            // Extract bits from the mode
            // Return the portion of the file's mode that can be set b`y
            //             os.chmod().
            //             
            public static object S_IMODE(object mode) {
                return mode & 07777;
            }
            
            // Return the portion of the file's mode that describes the
            //             file type.
            //             
            public static object S_IFMT(object mode) {
                return mode & 0170000;
            }
            
            public object S_IFDIR = 0040000;
            
            public object S_IFCHR = 0020000;
            
            public object S_IFBLK = 0060000;
            
            public object S_IFREG = 0100000;
            
            public object S_IFIFO = 0010000;
            
            public object S_IFLNK = 0120000;
            
            public object S_IFSOCK = 0140000;
            
            public object S_IFDOOR = 0;
            
            public object S_IFPORT = 0;
            
            public object S_IFWHT = 0;
            
            // Functions to test for each file type
            // Return True if mode is from a directory.
            public static bool S_ISDIR(object mode) {
                return S_IFMT(mode) == S_IFDIR;
            }
            
            // Return True if mode is from a character special device file.
            public static bool S_ISCHR(object mode) {
                return S_IFMT(mode) == S_IFCHR;
            }
            
            // Return True if mode is from a block special device file.
            public static bool S_ISBLK(object mode) {
                return S_IFMT(mode) == S_IFBLK;
            }
            
            // Return True if mode is from a regular file.
            public static bool S_ISREG(object mode) {
                return S_IFMT(mode) == S_IFREG;
            }
            
            // Return True if mode is from a FIFO (named pipe).
            public static bool S_ISFIFO(object mode) {
                return S_IFMT(mode) == S_IFIFO;
            }
            
            // Return True if mode is from a symbolic link.
            public static bool S_ISLNK(object mode) {
                return S_IFMT(mode) == S_IFLNK;
            }
            
            // Return True if mode is from a socket.
            public static bool S_ISSOCK(object mode) {
                return S_IFMT(mode) == S_IFSOCK;
            }
            
            // Return True if mode is from a door.
            public static bool S_ISDOOR(object mode) {
                return false;
            }
            
            // Return True if mode is from an event port.
            public static bool S_ISPORT(object mode) {
                return false;
            }
            
            // Return True if mode is from a whiteout.
            public static bool S_ISWHT(object mode) {
                return false;
            }
            
            public object S_ISUID = 04000;
            
            public object S_ISGID = 02000;
            
            public object S_ENFMT = S_ISGID;
            
            public object S_ISVTX = 01000;
            
            public object S_IREAD = 00400;
            
            public object S_IWRITE = 00200;
            
            public object S_IEXEC = 00100;
            
            public object S_IRWXU = 00700;
            
            public object S_IRUSR = 00400;
            
            public object S_IWUSR = 00200;
            
            public object S_IXUSR = 00100;
            
            public object S_IRWXG = 00070;
            
            public object S_IRGRP = 00040;
            
            public object S_IWGRP = 00020;
            
            public object S_IXGRP = 00010;
            
            public object S_IRWXO = 00007;
            
            public object S_IROTH = 00004;
            
            public object S_IWOTH = 00002;
            
            public object S_IXOTH = 00001;
            
            public object UF_NODUMP = 0x00000001;
            
            public object UF_IMMUTABLE = 0x00000002;
            
            public object UF_APPEND = 0x00000004;
            
            public object UF_OPAQUE = 0x00000008;
            
            public object UF_NOUNLINK = 0x00000010;
            
            public object UF_COMPRESSED = 0x00000020;
            
            public object UF_HIDDEN = 0x00008000;
            
            public object SF_ARCHIVED = 0x00010000;
            
            public object SF_IMMUTABLE = 0x00020000;
            
            public object SF_APPEND = 0x00040000;
            
            public object SF_NOUNLINK = 0x00100000;
            
            public object SF_SNAPSHOT = 0x00200000;
            
            public object _filemode_table = (((S_IFLNK, "l"), (S_IFSOCK, "s"), (S_IFREG, "-"), (S_IFBLK, "b"), (S_IFDIR, "d"), (S_IFCHR, "c"), (S_IFIFO, "p")), ValueTuple.Create((S_IRUSR, "r")), ValueTuple.Create((S_IWUSR, "w")), ((S_IXUSR | S_ISUID, "s"), (S_ISUID, "S"), (S_IXUSR, "x")), ValueTuple.Create((S_IRGRP, "r")), ValueTuple.Create((S_IWGRP, "w")), ((S_IXGRP | S_ISGID, "s"), (S_ISGID, "S"), (S_IXGRP, "x")), ValueTuple.Create((S_IROTH, "r")), ValueTuple.Create((S_IWOTH, "w")), ((S_IXOTH | S_ISVTX, "t"), (S_ISVTX, "T"), (S_IXOTH, "x")));
            
            // Convert a file's mode to a string of the form '-rwxrwxrwx'.
            public static string filemode(object mode) {
                var perm = new List<object>();
                foreach (var table in _filemode_table) {
                    foreach (var (bit, @char) in table) {
                        if ((mode & bit) == bit) {
                            perm.append(@char);
                            break;
                        }
                    }
                }
                return "".join(perm);
            }
            
            public object FILE_ATTRIBUTE_ARCHIVE = 32;
            
            public object FILE_ATTRIBUTE_COMPRESSED = 2048;
            
            public object FILE_ATTRIBUTE_DEVICE = 64;
            
            public object FILE_ATTRIBUTE_DIRECTORY = 16;
            
            public object FILE_ATTRIBUTE_ENCRYPTED = 16384;
            
            public object FILE_ATTRIBUTE_HIDDEN = 2;
            
            public object FILE_ATTRIBUTE_INTEGRITY_STREAM = 32768;
            
            public object FILE_ATTRIBUTE_NORMAL = 128;
            
            public object FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 8192;
            
            public object FILE_ATTRIBUTE_NO_SCRUB_DATA = 131072;
            
            public object FILE_ATTRIBUTE_OFFLINE = 4096;
            
            public object FILE_ATTRIBUTE_READONLY = 1;
            
            public object FILE_ATTRIBUTE_REPARSE_POINT = 1024;
            
            public object FILE_ATTRIBUTE_SPARSE_FILE = 512;
            
            public object FILE_ATTRIBUTE_SYSTEM = 4;
            
            public object FILE_ATTRIBUTE_TEMPORARY = 256;
            
            public object FILE_ATTRIBUTE_VIRTUAL = 65536;
        }
    }
    
    public static object GenericAlias = type(list[@int]);
    
    public static object Null = type[null];
    
    public static Func<object> Object = object;
    
    // System.Branding
    //     
    //     Get computer details, interpreter details and other variables.
    public class Branding {
        
        public object Windows = "win32";
        
        public object Win = Windows;
        
        public object Microsoft = Windows;
        
        public object MSDOS = Windows;
        
        public object Cygwin = "cygwin";
        
        public object macOS = "darwin";
        
        public object MacOS = macOS;
        
        public object Apple = macOS;
        
        public object Darwin = macOS;
        
        public object OSX = macOS;
        
        public object macOSX = macOS;
        
        public object Unix = macOS || "linux";
        
        public object Linux = "linux";
        
        public object Aix = "aix";
        
        public object Emscripten = "emscripten";
        
        public object WebAssembly = "wasi";
        
        public object WebAssembleySystemInterface = WebAssembly;
        
        public object Web = WebAssembly;
        
        // System.Branding.SlashInPaths()
        //         
        //         Detect whether the computer uses backslashes or forwardslashes in paths.
        //         Returns True if there are forwardslashes, False if backslashes.
        //         
        public static bool SlashInPaths() {
            return Fluid.Location.Contains("/");
        }
        
        public object Slash = "\\";
        
        public object Slash = "/";
        
        // System.Branding.Computer
        public class Computer {
            
            public object Interpreter = Legacy._sys.platform;
            
            public class Platform {
                
                public object @__copyright__ = @"
                Inspired by Python's default Platform module.

                Copyright (c) 1999-2000, Marc-Andre Lemburg; mailto:mal@lemburg.com
                Copyright (c) 2000-2010, eGenix.com Software GmbH; mailto:info@egenix.com
                Permission to use, copy, modify, and distribute this software and its
                documentation for any purpose and without fee or royalty is hereby granted,
                provided that the above copyright notice appear in all copies and that
                both that copyright notice and this permission notice appear in
                supporting documentation or portions thereof, including modifications,
                that you make.
                EGENIX.COM SOFTWARE GMBH DISCLAIMS ALL WARRANTIES WITH REGARD TO
                THIS SOFTWARE, INCLUDING ALL IMPLIED WARRANTIES OF MERCHANTABILITY AND
                FITNESS, IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL,
                INDIRECT OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES WHATSOEVER RESULTING
                FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT,
                NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION
                WITH THE USE OR PERFORMANCE OF THIS SOFTWARE !
            ";
                
                public class Data {
                    
                    public static Tuple<object, Tuple<string, string, string>> macOSVersion() {
                        var DataSource = "/System/Library/CoreServices/SystemVersion.plist";
                        try {
                        } catch (ImportError) {
                            return Null;
                        }
                        using (var Data = open("/System/Library/CoreServices/SystemVersion.plist", "rb")) {
                            PList = PListLib.load(Data);
                        }
                        var Release = PList["ProductVersion"];
                        var Info = ("", "", "");
                        // Machine = os.uname().machine
                        // if Variables.Search(Machine, ("ppc", "Power Macintosh")):
                        //     Machine = 'PowerPC'
                        return (Release, Info);
                    }
                }
                
                public static object[] macOSVersion(object Release = "", Tuple<string, string, string> Info = ("", "", ""), string Machine = "") {
                    if (Info != Null) {
                        return Info;
                    }
                    // If that also doesn't work return the default values
                    return (Release, Info, Machine);
                }
            }
        }
        
        public object Model = Computer;
        
        // System.Branding.User
        public class User {
            
            public class Interface {
                
                public static void DarkDetect() {
                    //-----------------------------------------------------------------------------
                    //  Inspired by DarkDetect by Alberto Sottile (https://github.com/albertosottile/darkdetect)
                    //  Copyright (C) 2019 Alberto Sottile
                    //
                    //  Distributed under the terms of the 3-clause BSD License.
                    //-----------------------------------------------------------------------------
                    object IsmacOSVersionSupported() {
                        sysver = platform.mac_ver()[0];
                        major = Convert.ToInt32(sysver.split(".")[0]);
                        if (major < 10) {
                            return false;
                        } else if (major >= 11) {
                            return true;
                        } else {
                            minor = Convert.ToInt32(sysver.split(".")[1]);
                            if (minor < 14) {
                                return false;
                            } else {
                                return true;
                            }
                        }
                    }
                }
            }
        }
    }
    
    public class Variables {
        
        public static object Environment(object EnvironmentVariable) {
            return Legacy._os.environ[EnvironmentVariable];
        }
        
        public class Convert {
            
            public static string String(object ToVariable) {
                return ToVariable.ToString();
            }
            
            public static int Integer(object ToVariable) {
                return Convert.ToInt32(ToVariable);
            }
            
            public static double Float(object ToVariable) {
                return Convert.ToDouble(ToVariable);
            }
            
            public static bool Boolean(object ToVariable) {
                return @bool(ToVariable);
            }
        }
        
        public class String
            : Object {
            
            public String String;
            
            public String(string String) {
                this.String = String;
            }
            
            public override string ToString() {
                return this.String;
            }
            
            public static string Convert(object ToVariable) {
                return ToVariable.ToString();
            }
        }
        
        public static bool Search(object Index, object Key, bool MatchFullWord = true) {
            if (MatchFullWord == false) {
                return (" " + Index.ToString() + " ").Contains(" " + Key.ToString() + " ");
            } else {
                return Index.ToString().Contains(Key.ToString());
            }
        }
    }
    
    // System.Processing
    //     
    //     Foundation class for the purpose of spawning, viewing and managing processes on the user's computer.
    public class Processing {
        
        // System.Processing.Execute()
        //     
        //         Foundation method for the purpose of executing Python code from a string.
        public static void Execute(object ExecuteScript, object ScriptTimeOut = Null, string Language = "fl", List<object> IncludeFoundation = new List<object>()) {
            if (Language == "fl") {
                if (IncludeFoundation != Null) {
                    //               try:
                    return exec(ExecuteScript.ToString(), IncludeFoundation);
                    //               except NameError: # NameError is for when the person includes a Foundation module such as 'System' without using the 'IncludeFoundation' parameter.
                    //                   if Variables.Search(ExecuteScript, "System") is True:
                    //                       return exec(ExecuteScript, {"System.Console":Console})
                } else {
                    return exec(ExecuteScript.ToString());
                }
            } else if (Language == "shell") {
                if (ScriptTimeOut != Null) {
                    return Legacy._process.call(ExecuteScript, timeout: ScriptTimeOut);
                } else {
                    return Legacy._process.call(ExecuteScript);
                }
            } else {
                throw new NotImplementedException();
            }
        }
        
        // System.Processing.Halt
        public static void Halt(object HaltTime) {
            // type: ignore
            Legacy._time.sleep(HaltTime);
            //class Task(Object):
            //if Branding.Computer.Interpreter is 
            //def __init__(This, Task: str, Task):
        }
    }
    
    // System.Chronology
    //     
    //     Foundation class for obtaining the current date and time, as well as other details.
    //     
    public class Chronology {
        
        // System.Chronology.Time
        //         
        //         Return the current time in the specified time zone.
        //         
        public class Time {
            
            public PythonDateTime.datetime DataSource;
            
            public int Day;
            
            public bool DaylightSavings;
            
            public object Form;
            
            public int Hour;
            
            public int Month;
            
            public object TimeZone;
            
            public int WeekDay;
            
            public int Year;
            
            public Time(string TimeZone = "Local", string Form = "DateTime") {
                this.TimeZone = TimeZone;
                this.Form = Form;
                this.DataSource = Null;
                if (TimeZone == "UCT") {
                    this.DataSource = Legacy._time.gmtime();
                } else if (TimeZone == "Local") {
                    this.DataSource = Legacy._time.localtime();
                } else {
                    throw new NotImplementedException("The specified time zone is not supported.");
                }
                this.Year = this.DataSource.tm_year;
                this.Month = this.DataSource.tm_mon;
                this.Day = this.DataSource.tm_mday;
                this.WeekDay = this.DataSource.tm_wday;
                this.Hour = this.DataSource.tm_hour;
                if (this.DataSource.tm_isdst == 1) {
                    this.DaylightSavings = true;
                } else if (this.DataSource.tm_isdst == 0) {
                    this.DaylightSavings = false;
                } else {
                    throw new ValueError("Daylight savings time could not be determined.");
                }
            }
            
            // System.Chronology.Time.__str__
            //             
            //             Return the time in the specified time zone in ISO 8601 format.
            //             
            //             📝 Form argument should be either "Date", "DateTime", "Week" or "Ordinal". See https://wikipedia.org/wiki/ISO_8601 for more information.
            //             
            public override string ToString() {
                if (this.Form == "Date" || "DateTime" || "Week" || "WeekWeekDay" || "Ordinal") {
                    if (this.TimeZone == "UCT") {
                        if (this.Form == "Date") {
                            return $"{self.DataSource.tm_year}-{self.DataSource.tm_mon}-{self.DataSource.tm_mday}";
                        } else if (this.Form == "DateTime") {
                            return $"{self.DataSource.tm_year}-{self.DataSource.tm_mon}-{self.DataSource.tm_mday}T{self.DataSource.tm_hour}:{self.DataSource.tm_min}:{self.DataSource.tm_sec}Z";
                        } else if (this.Form == "Week") {
                            return $"{self.DataSource.tm_year}-W{self.DataSource.tm_wday}";
                        } else if (this.Form == "WeekWeekDay") {
                            return $"{self.DataSource.tm_year}-W{self.DataSource.tm_wday}-{self.DataSource.tm_wday}";
                        } else if (this.Form == "Ordinal") {
                            return $"{self.DataSource.tm_year}-{self.DataSource.tm_yday}";
                        }
                    } else if (this.TimeZone == "Local") {
                        if (this.Form == "Date") {
                            return $"{self.DataSource.tm_year}-{self.DataSource.tm_mon}-{self.DataSource.tm_mday}";
                        } else if (this.Form == "DateTime") {
                            return $"{self.DataSource.tm_year}-{self.DataSource.tm_mon}-{self.DataSource.tm_mday}T{self.DataSource.tm_hour}:{self.DataSource.tm_min}:{self.DataSource.tm_sec}";
                        } else if (this.Form == "Week") {
                            return $"{self.DataSource.tm_year}-W{self.DataSource.tm_wday}";
                        } else if (this.Form == "Ordinal") {
                            return $"{self.DataSource.tm_year}-{self.DataSource.tm_yday}";
                        }
                    } else {
                        throw new NotImplementedException("The specified time zone is not supported.");
                    }
                } else {
                    throw Fluid.Exception.ArgumentError("The specified format is not supported.");
                }
            }
            
            // System.Chronology.Time.Minute
            //             
            //             Returns the time with the minute or seconds.
            //             
            public virtual string Minute(bool WithSeconds = false) {
                if (this.TimeZone == "UCT") {
                    if (object.ReferenceEquals(WithSeconds, true)) {
                        return $"{self.DataSource.tm_hour}:{self.DataSource.tm_min}:{self.DataSource.tm_sec}";
                    } else {
                        return $"{self.DataSource.tm_hour}:{self.DataSource.tm_min}";
                    }
                } else if (this.TimeZone == "Local") {
                    if (object.ReferenceEquals(WithSeconds, true)) {
                        return $"{self.DataSource.tm_hour}:{self.DataSource.tm_min}:{self.DataSource.tm_sec}";
                    } else {
                        return $"{self.DataSource.tm_hour}:{self.DataSource.tm_min}";
                    }
                } else {
                    throw new NotImplementedException("The specified time zone is not supported.");
                }
            }
        }
    }
    
    // System.Console
    // 
    //     Foundation class for the purpose of displaying plain text on the console, particularly for debugging or logging.
    //     Also comes with an advanced logger to format logs neatly in the console.
    //     Not recommended for actual text display as part of a GUI application; use only for logging purposes.
    //     
    public class Console {
        
        public static void WriteLine(Console Text) {
            // type: ignore
            return print(Text);
        }
        
        public static void Write(Console Text) {
            // type: ignore
            return print(Text, end: "");
        }
        
        // System.Console.Log
        //         
        //         Very advanced version of System.Console.WriteLine() that formats logs neatly in the console.
        //         
        public class Log {
            
            public string Log;
            
            public string LogDate;
            
            public object LogTimeZone;
            
            public object LogType;
            
            public List<string> ValidLogTypes;
            
            public Log(string Log = "", string LogType = "INFO", string LogTimeZone = "Local") {
                this.Log = Log;
                this.LogType = LogType;
                this.LogTimeZone = LogTimeZone;
                this.LogDate = new Chronology.Time(this.LogTimeZone, "DateTime");
                this.LogType = this.LogType.upper();
                this.LogDate = $"[{self.LogDate}]";
                this.ValidLogTypes = new List<string> {
                    "INFO",
                    "WARNING",
                    "ERROR",
                    "DEBUG",
                    "FATAL"
                };
                if (!this.ValidLogTypes.Contains(this.LogType)) {
                    throw Fluid.Exception.ArgumentError("The specified log type is not supported.");
                }
                this.Log = $"{self.LogDate} |{self.LogType[0:1]}| {self.Log}";
                Console.WriteLine(this.Log);
            }
            
            public override string ToString() {
                return this.Log;
            }
        }
    }
    
    // System.Explore
    // 
    //     Foundation class for the purpose of allowing the developer to read, write and make new files on the end-user's computer.
    //     
    public class Explore {
        
        public object Auto;
        
        public object AutoValue;
        
        public object FileEncoding;
        
        public object FileName;
        
        public object GetWorkingDirectory;
        
        public Explore(string FileName, bool Auto = true, string AutoValue = "", string FileEncoding = "utf-8") {
            this.FileName = FileName;
            this.Auto = Auto;
            this.AutoValue = AutoValue;
            this.FileEncoding = FileEncoding;
            this.GetWorkingDirectory = Fluid.Location;
        }
        
        public override void ToString() {
            throw Fluid.Exception.ArgumentError("You must use a function inside the System.Explore class in order to explore your computer.");
        }
        
        // System.Explore.IsFile()
        // 
        //         Foundation method for the purpose of a allowing the developer to check if a file exists on the end-user's computer.
        //         
        public virtual bool IsFile() {
            try {
                open(this.FileName, "r", encoding: this.FileEncoding);
                return true;
            } catch (FileNotFoundError) {
                return false;
            } catch {
                throw new Exception.Maloote("An unknown error has occurred.");
            }
        }
        
        // System.Explore.Read()
        // 
        //         Foundation method for the purpose of a allowing the developer to read files on the end-user's computer.
        //         
        public virtual object Read() {
            // type: ignore
            if (this.Auto != false) {
                return open(this.FileName, "r", encoding: this.FileEncoding).read().ToString();
            } else {
                return open(this.FileName, "r", encoding: this.FileEncoding);
            }
        }
        
        // System.Explore.Write()
        // 
        //         Foundation method for the purpose of a allowing the developer to write files on the end-user's computer.
        //         
        public virtual file Write() {
            // type: ignore   
            if (this.Auto == false) {
                return open(this.FileName, "w", encoding: this.FileEncoding);
            } else {
                return open(this.FileName, "w", encoding: this.FileEncoding).write(this.AutoValue);
            }
        }
        
        // System.Explore.Append()
        // 
        //         Foundation method for the purpose of a allowing the developer to append to files on the end-user's computer.
        //         
        public virtual file Append() {
            // type: ignore
            if (this.Auto == false) {
                return open(this.FileName, "a", encoding: this.FileEncoding);
            } else {
                return open(this.FileName, "a", encoding: this.FileEncoding).write(this.AutoValue);
            }
        }
        
        // System.Explore.Create()
        // 
        //         Foundation method for the purpose of a allowing the developer to create files on the end-user's computer.
        //         
        public virtual file Create() {
            // type: ignore
            return open(this.FileName, "x", encoding: this.FileEncoding);
        }
        
        // System.Explore.Access()
        // 
        //         Foundation method for the purpose of a allowing the developer to access files completely on the end-user's computer.
        //         
        public virtual file Access() {
            // type: ignore
            return open(this.FileName, "r+", encoding: this.FileEncoding);
        }
    }
    
    // System.Packaging
    //     
    //     An advanced Foundation class enabling the developer to properly package their application.
    //     
    public class Packaging {
        
        // System.Packaging.License
        //         
        //         Foundation class object which defines a license and its metadata.
        //         
        public class License {
            
            public object Contents;
            
            public object CopyrightHolder;
            
            public object Name;
            
            public object Year;
            
            public License(string Name, string CopyrightHolder, string Contents = "", int Year = new Chronology.Time().Year) {
                this.Name = Name;
                this.CopyrightHolder = CopyrightHolder;
                this.Year = Year;
                if (Contents != Null) {
                    this.Contents = Contents;
                }
            }
            
            public override string ToString() {
                if (this.Contents != "") {
                    return $"{self.Name}\n\n{self.Contents}";
                } else if (this.Contents == "") {
                    // TODO: Add more licenses.
                    if (this.Name == "MIT") {
                        return $"{self.Name}\n\nCopyright {self.Year} {self.CopyrightHolder}\n\nPermission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the \"Software\"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:\n\nThe above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.\n\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.";
                    } else if (this.Name == "Apache 2.0") {
                        return $"{self.Name}\n\nLicensed under the Apache License, Version 2.0 (the \"License\"); you may not use this file except in compliance with the License. You may obtain a copy of the License at\n\nhttp://www.apache.org/licenses/LICENSE-2.0\n\nUnless required by applicable law or agreed to in writing, software distributed under the License is distributed on an \"AS IS\" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.";
                    } else if (this.Name == "GPL 3.0") {
                        return $"{self.Name}\n\nThis program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.\n\nThis program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.\n\nYou should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/.";
                    } else if (this.Name == "LGPL 3.0") {
                        return $"{self.Name}\n\nThis library is free software; you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation; either version 3 of the License, or (at your option) any later version.\n\nThis library is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.\n\nYou should have received a copy of the GNU Lesser General Public License along with this library. If not, see http://www.gnu.org/licenses/.";
                    } else if (this.Name == "AGPL 3.0") {
                        return $"{self.Name}\n\nThis program is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.\n\nThis program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Affero General Public License for more details.\n\nYou should have received a copy of the GNU Affero General Public License along with this program. If not, see http://www.gnu.org/licenses/.";
                    } else if (this.Name == "MPL 2.0") {
                        return $"{self.Name}\n\nThis Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0. If a copy of the MPL was not distributed with this file, You can obtain one at http://mozilla.org/MPL/2.0/.";
                    } else if (this.Name == "Unlicense") {
                        return $"{self.Name}\n\nThis is free and unencumbered software released into the public domain.\n\nAnyone is free to copy, modify, publish, use, compile, sell, or\n\nDistribute this software, either in source code form or as a compiled\n\nbinary, for any purpose, commercial or non-commercial, and by any\n\nmeans.\n\nIn jurisdictions that recognize copyright laws, the author or authors\n\nof this software dedicate any and all copyright interest in the\n\nsoftware to the public domain. We make this dedication for the benefit\n\nof the public at large and to the detriment of our heirs and\n\nsuccessors. We intend this dedication to be an overt act of\n\nrelinquishment in perpetuity of all present and future rights to this\n\nsoftware under copyright law.\n\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND,\n\nEXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF\n\nMERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.\n\nIN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR\n\nOTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,\n\nARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR\n\nOTHER DEALINGS IN THE SOFTWARE.\n\nFor more information, please refer to <http://unlicense.org/>";
                    } else if (this.Name == "CC0 1.0") {
                        return @"{self.Name}" + "\n" +@"" + "\n" +@"CREATIVE COMMONS CORPORATION IS NOT A LAW FIRM AND DOES NOT PROVIDE LEGAL SERVICES. DISTRIBUTION OF THIS DOCUMENT DOES NOT CREATE AN ATTORNEY-CLIENT RELATIONSHIP. CREATIVE COMMONS PROVIDES THIS INFORMATION ON AN ""AS-IS"" BASIS. CREATIVE COMMONS MAKES NO WARRANTIES REGARDING THE USE OF THIS DOCUMENT OR THE INFORMATION OR WORKS PROVIDED HEREUNDER, AND DISCLAIMS LIABILITY FOR DAMAGES RESULTING FROM THE USE OF THIS DOCUMENT OR THE INFORMATION OR WORKS PROVIDED HEREUNDER.
Statement of Purpose
The laws of most jurisdictions throughout the world automatically confer exclusive Copyright and Related Rights (defined below) upon the creator and subsequent owner(s) (each and all, an ""owner"") of an original work of authorship and/or a database (each, a ""Work"").

Certain owners wish to permanently relinquish those rights to a Work for the purpose of contributing to a commons of creative, cultural and scientific works (""Commons"") that the public can reliably and without fear of later claims of infringement build upon, modify, incorporate in other works, reuse and redistribute as freely as possible in any form whatsoever and for any purposes, including without limitation commercial purposes. These owners may contribute to the Commons to promote the ideal of a free culture and the further production of creative, cultural and scientific works, or to gain reputation or greater distribution for their Work in part through the use and efforts of others.

For these and/or other purposes and motivations, and without any expectation of additional consideration or compensation, the person associating CC0 with a Work (the ""Affirmer""), to the extent that he or she is an owner of Copyright and Related Rights in the Work, voluntarily elects to apply CC0 to the Work and publicly distribute the Work under its terms, with knowledge of his or her Copyright and Related Rights in the Work and the meaning and intended legal effect of CC0 on those rights.

1. Copyright and Related Rights. A Work made available under CC0 may be protected by copyright and related or neighboring rights (""Copyright and Related Rights""). Copyright and Related Rights include, but are not limited to, the following:

the right to reproduce, adapt, distribute, perform, display, communicate, and translate a Work;
moral rights retained by the original author(s) and/or performer(s);
publicity and privacy rights pertaining to a person's image or likeness depicted in a Work;
rights protecting against unfair competition in regards to a Work, subject to the limitations in paragraph 4(a), below;
rights protecting the extraction, dissemination, use and reuse of data in a Work;
database rights (such as those arising under Directive 96/9/EC of the European Parliament and of the Council of 11 March 1996 on the legal protection of databases, and under any national implementation thereof, including any amended or successor version of such directive); and
other similar, equivalent or corresponding rights throughout the world based on applicable law or treaty, and any national implementations thereof.
2. Waiver. To the greatest extent permitted by, but not in contravention of, applicable law, Affirmer hereby overtly, fully, permanently, irrevocably and unconditionally waives, abandons, and surrenders all of Affirmer's Copyright and Related Rights and associated claims and causes of action, whether now known or unknown (including existing as well as future claims and causes of action), in the Work (i) in all territories worldwide, (ii) for the maximum duration provided by applicable law or treaty (including future time extensions), (iii) in any current or future medium and for any number of copies, and (iv) for any purpose whatsoever, including without limitation commercial, advertising or promotional purposes (the ""Waiver""). Affirmer makes the Waiver for the benefit of each member of the public at large and to the detriment of Affirmer's heirs and successors, fully intending that such Waiver shall not be subject to revocation, rescission, cancellation, termination, or any other legal or equitable action to disrupt the quiet enjoyment of the Work by the public as contemplated by Affirmer's express Statement of Purpose.

3. Public License Fallback. Should any part of the Waiver for any reason be judged legally invalid or ineffective under applicable law, then the Waiver shall be preserved to the maximum extent permitted taking into account Affirmer's express Statement of Purpose. In addition, to the extent the Waiver is so judged Affirmer hereby grants to each affected person a royalty-free, non transferable, non sublicensable, non exclusive, irrevocable and unconditional license to exercise Affirmer's Copyright and Related Rights in the Work (i) in all territories worldwide, (ii) for the maximum duration provided by applicable law or treaty (including future time extensions), (iii) in any current or future medium and for any number of copies, and (iv) for any purpose whatsoever, including without limitation commercial, advertising or promotional purposes (the ""License""). The License shall be deemed effective as of the date CC0 was applied by Affirmer to the Work. Should any part of the License for any reason be judged legally invalid or ineffective under applicable law, such partial invalidity or ineffectiveness shall not invalidate the remainder of the License, and in such case Affirmer hereby affirms that he or she will not (i) exercise any of his or her remaining Copyright and Related Rights in the Work or (ii) assert any associated claims and causes of action with respect to the Work, in either case contrary to Affirmer's express Statement of Purpose.

4. Limitations and Disclaimers.

No trademark or patent rights held by Affirmer are waived, abandoned, surrendered, licensed or otherwise affected by this document.
Affirmer offers the Work as-is and makes no representations or warranties of any kind concerning the Work, express, implied, statutory or otherwise, including without limitation warranties of title, merchantability, fitness for a particular purpose, non infringement, or the absence of latent or other defects, accuracy, or the present or absence of errors, whether or not discoverable, all to the greatest extent permissible under applicable law.
Affirmer disclaims responsibility for clearing rights of other persons that may apply to the Work or any use thereof, including without limitation any person's Copyright and Related Rights in the Work. Further, Affirmer disclaims responsibility for obtaining any necessary consents, permissions or other rights required for any use of the Work.
Affirmer understands and acknowledges that Creative Commons is not a party to this document and has no duty or obligation with respect to this CC0 or use of the Work.";
                    } else {
                        return $"{self.Name}";
                    }
                }
            }
        }
        
        // System.Packaging.App
        //         
        //         Foundation class object which defines the application and its metadata.
        //         
        public class App
            : Object {
            
            public object Author;
            
            public object Description;
            
            public string GitURL;
            
            public object Icon;
            
            public License License;
            
            public object Name;
            
            public object URL;
            
            public object Version;
            
            public App(
                string Name,
                double Version,
                string Author,
                string Description,
                string License,
                string URL,
                string Icon,
                bool OnGitHub = false) {
                this.Name = Name;
                this.Version = Version;
                this.Author = Author;
                this.Description = Description;
                this.License = License;
                this.URL = URL;
                if (OnGitHub) {
                    this.GitURL = $"https://github.com/{self.Author}/{self.Name}";
                }
                this.Icon = Icon;
            }
        }
    }
}
