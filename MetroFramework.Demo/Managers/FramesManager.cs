﻿using System;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Diagnostics;
using AForge.Imaging;
using System.Drawing;
using System.Threading.Tasks;

namespace Nkujukira
{
    class FramesManager
    {
        public static Color COLOR_OF_FACE_RECTANGLE = Color.Green;
        private const int THICKNESS                 = 1;
        private const double SCALE                  = 3.0;
        private const double SCALEFACTOR            = 1.4;
        private const int MINIMUM_NEIGBHOURS        = 3;
        private const int WINDOW_SIZE               = 50;

        //RETURNS THE NEXT FRAME FROM A WEB CAM OR VIDEO FILE
        public static Image<Bgr, byte> GetNextFrame(Capture capture)
        {
            if (capture == null)
            {
                throw new NullReferenceException();
            }

            try
            {
                Image<Bgr, byte> frame = null;
                lock (capture)
                {
                    frame = capture.QueryFrame();
                }
                return frame;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }


        //THIS RESIZES AN IMAGE ACCORDING TO GIVEN WIDTH AND HEIGHT
        public static Image<Bgr, byte> ResizeImage(Image<Bgr, byte> frame, int width, int height)
        {
            if (frame == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                return frame.Resize(width, height, INTER.CV_INTER_LINEAR);

            }
            catch (Exception)
            {
                return null;
            }
        }

        //THIS RESIZES AN IMAGE ACCORDING TO GIVEN WIDTH AND HEIGHT
        public static Image<Gray, byte> ResizeGrayImage(Image<Gray, byte> frame, Size new_size)
        {
            if (frame == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                return frame.Resize(new_size.Width, new_size.Height, INTER.CV_INTER_LINEAR);

            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool PerformSeekOperationInVideo(double starting_time_in_milliseconds, Capture capture)
        {
            try
            {
                if (capture == null)
                {
                    throw new ArgumentNullException();
                }
                capture.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_POS_MSEC, starting_time_in_milliseconds);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }

        }


        public static Rectangle[] DetectFacesInFrame(Image<Bgr, byte> current_frame, HaarCascade haarcascade)
        {
            if (current_frame== null || haarcascade == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                using (current_frame)
                {
                    using (Image<Gray, byte> grayscale_image          = current_frame.Convert<Gray, byte>())
                    {
                        grayscale_image._EqualizeHist();

                        MCvAvgComp[] detected_faces                   = grayscale_image.DetectHaarCascade(haarcascade, SCALEFACTOR, MINIMUM_NEIGBHOURS, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new System.Drawing.Size(WINDOW_SIZE, WINDOW_SIZE))[0];
                        
                        //Debug.WriteLine("NUMBER OF FACES FOUND        =" + detected_faces.Length);
                        
                        if (detected_faces.Length != 0)
                        {
                            Rectangle[] face_rectangles               = new Rectangle[detected_faces.Length];
                            Parallel.For(0, face_rectangles.Length, i =>
                            {
                                face_rectangles[i]                    = detected_faces[i].rect;
                            });
                            detected_faces                            = null;
                            return face_rectangles;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }

        public static Image<Bgr, byte> DrawShapeAroundDetectedFaces(Rectangle rectangle_of_detected_face, Image<Bgr, byte> current_frame, out bool sucess)
        {
            if (current_frame == null)
            {
                throw new ArgumentNullException();
            }

            current_frame.Draw(rectangle_of_detected_face, new Bgr(COLOR_OF_FACE_RECTANGLE), THICKNESS);
            sucess            = true;
            return current_frame;
        }


        public static Bitmap DrawShapeOnTransparentBackGround(Rectangle a_rectangle, int frame_width, int frame_height)
        {
            Bitmap bitmap     = new Bitmap(frame_width, frame_height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.Transparent);
            graphics.DrawRectangle(Pens.Green, a_rectangle);
            graphics.Flush();
            return bitmap;
        }


        public static bool OverLayBitmapToFormNewImage(Bitmap to_be_overlaid, Graphics graphics)
        {
            try
            {
                if (to_be_overlaid == null || graphics == null)
                {
                    throw new ArgumentNullException();
                }

                graphics.DrawImageUnscaled(to_be_overlaid, new Point(0, 0));
                graphics.Flush();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }


        public static Image<Gray, byte> CropSelectedFace(Rectangle detected_face, Image<Bgr, byte> frame)
        {
            try
            {
                if (frame== null)
                {
                    throw new ArgumentNullException();
                }

                Image<Gray, byte> gray_scale   = frame.Convert<Gray, byte>();
                gray_scale.ROI                 = detected_face;
                Image<Gray, byte> cropped_face = gray_scale.Copy();
                return cropped_face;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }


        }

        public static Bitmap ResizeBitmap(Bitmap image, Size new_size)
        {
            try
            {
                if (image== null || new_size == null)
                {
                    throw new ArgumentNullException();
                }

                Bitmap b                = new Bitmap(new_size.Width, new_size.Height);
                using (Graphics g       = Graphics.FromImage(b))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(image, 0, 0, new_size.Width, new_size.Height);
                    g.Flush();
                }
                return b;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}
