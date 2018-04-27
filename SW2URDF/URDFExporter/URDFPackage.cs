﻿/*
Copyright (c) 2015 Stephen Brawner



Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:



The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.



THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.  IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SW2URDF
{
    public class URDFPackage
    {
        private string packageName;
        public string PackageName
        {
            get
            {
                return packageName;
            }
        }

        private string packageDirectory;
        public string PackageDirectory
        {
            get
            {
                return packageDirectory;
            }
        }

        private string windowsPackageDirectory;
        public string WindowsPackageDirectory
        {
            get
            {
                return windowsPackageDirectory;
            }
        }

        private string meshesDirectory;
        public string MeshesDirectory
        {
            get
            {
                return meshesDirectory;
            }
        }

        private string configDirectory;
        public string ConfigDirectory
        {
            get
            {
                return configDirectory;
            }

        }


        private string windowsMeshesDirectory;
        public string WindowsMeshesDirectory
        {
            get
            {
                return windowsMeshesDirectory;
            }
        }

        private string robotsDirectory;
        public string RobotsDirectory
        {
            get
            {
                return robotsDirectory;
            }
        }

        private string windowsRobotsDirectory;
        public string WindowsRobotsDirectory
        {
            get
            {
                return windowsRobotsDirectory;
            }
        }

        private string texturesDirectory;
        public string TexturesDirectory
        {
            get
            {
                return texturesDirectory;
            }
        }

        private string windowsTexturesDirectory;
        public string WindowsTexturesDirectory
        {
            get
            {
                return windowsTexturesDirectory;
            }
        }

        private string launchDirectory;
        public string LaunchDirectory
        {
            get
            {
                return launchDirectory;
            }
        }

        private string windowsLaunchDirectory;
        public string WindowsLaunchDirectory
        {
            get
            {
                return windowsLaunchDirectory;
            }
        }

        private string windowsConfigDirectory;
        public string WindowsConfigDirectory
        {
            get
            {
                return windowsConfigDirectory;
            }
        }

        private string windowsCMakeLists;
        public string WindowsCMakeLists
        {
            get
            {
                return windowsCMakeLists;
            }
        }

        private string windowsConfigYAML;
        public string WindowsConfigYAML
        {
            get
            {
                return windowsConfigYAML;
            }
        }


        public URDFPackage(string name, string dir)
        {
            packageName = name;
            packageDirectory = @"package://" + name + @"/";
            meshesDirectory = packageDirectory + @"meshes/";
            robotsDirectory = packageDirectory + @"urdf/";
            texturesDirectory = packageDirectory + @"textures/";
            launchDirectory = packageDirectory + @"launch/";
            configDirectory = packageDirectory + @"config/";
           

            char last = dir[dir.Length - 1];
            dir = (last == '\\') ? dir : dir + @"\";
            windowsPackageDirectory = dir + name + @"\";
            windowsMeshesDirectory = windowsPackageDirectory + @"meshes\";
            windowsRobotsDirectory = windowsPackageDirectory + @"urdf\";
            windowsTexturesDirectory = windowsPackageDirectory + @"textures\";
            windowsLaunchDirectory = windowsPackageDirectory + @"launch\";
            windowsConfigDirectory = windowsPackageDirectory + @"config\";
            windowsCMakeLists = windowsPackageDirectory + @"CMakeLists.txt";
            windowsConfigYAML = windowsConfigDirectory + @"joint_names_" + name + ".yaml";
        }

        public void createDirectories()
        {
            System.Windows.Forms.MessageBox.Show("Creating URDF Package \"" + packageName + "\" at:\n" + windowsPackageDirectory);
            if (!Directory.Exists(windowsPackageDirectory))
            {
                Directory.CreateDirectory(windowsPackageDirectory);
            }
            if (!Directory.Exists(windowsMeshesDirectory))
            {
                Directory.CreateDirectory(windowsMeshesDirectory);
            }
            if (!Directory.Exists(windowsRobotsDirectory))
            {
                Directory.CreateDirectory(windowsRobotsDirectory);
            }
            if (!Directory.Exists(windowsTexturesDirectory))
            {
                Directory.CreateDirectory(windowsTexturesDirectory);
            }
            if (!Directory.Exists(windowsLaunchDirectory))
            {
                Directory.CreateDirectory(windowsLaunchDirectory);
            }
            if (!Directory.Exists(windowsConfigDirectory))
            {
                Directory.CreateDirectory(windowsConfigDirectory);
            }

        }

        public void createCMakeLists()
        {
            using (StreamWriter file = new StreamWriter(windowsCMakeLists))
            {
                file.WriteLine("cmake_minimum_required(VERSION 2.8.3)\r\n");
                file.WriteLine("project(" + packageName + ")\r\n");
                file.WriteLine("find_package(catkin REQUIRED)\r\n");
                file.WriteLine("catkin_package()\r\n");
                file.WriteLine("find_package(roslaunch)\r\n");
                file.WriteLine("foreach(dir config launch meshes urdf)");
                file.WriteLine("\tinstall(DIRECTORY ${dir}/");
                file.WriteLine("\t\tDESTINATION ${CATKIN_PACKAGE_SHARE_DESTINATION}/${dir})");
                file.WriteLine("endforeach(dir)");
            }
        }

        public void createConfigYAML(String[] jointNames)
        {
            using (StreamWriter file = new StreamWriter(windowsConfigYAML))
            {
                file.Write("controller_joint_names: " + "[");

                foreach (String name in jointNames)
                {
                    file.Write("'" + name + "', ");
                }

                file.WriteLine("]");
            }

        }




    }
}
