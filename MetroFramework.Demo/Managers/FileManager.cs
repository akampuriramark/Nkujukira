﻿using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace Nkujukira.Demo.Managers
{
    public class FileManager
    {
        public static bool SaveBitmap(String file_path, Bitmap bitmap)
        {
            try
            {
                bitmap.Save("MINE.PNG");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return false;
        }

        public static bool SaveImage(String file_path, Image<Bgr, byte> image)
        {

            try
            {
                image.Save(file_path);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return false;
        }

        public static bool DeleteBitmap(String file_name)
        {
            return false;
        }


        public static bool SaveFrameInAVIFormat(VideoWriter output_writer, Image<Bgr, byte> frame)
        {
            try
            {
                using (frame)
                {
                    output_writer.WriteFrame(frame);
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }

        }

        public static bool CreateFolderIfMissing(String path)
        {
            try
            {
                bool folder_exists = Directory.Exists(path);
                if (!folder_exists)
                {
                    Directory.CreateDirectory(path);
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        internal static Image<Bgr, byte>[] GetAllImagesInDirectory(string path)
        {
            String[] file_paths = Directory.GetFiles(path, "*.png");

            List<Image<Bgr, byte>> faces = new List<Image<Bgr, byte>>();

            foreach (var file_path in file_paths)
            {
                Image<Bgr, byte> face = new Image<Bgr, byte>(file_path);
                faces.Add(face);
            }
            return faces.ToArray();
        }
    }

}
