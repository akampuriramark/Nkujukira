﻿using Emgu.CV;
using Emgu.CV.Structure;
using Luxand;
using Nkujukira.Demo.Entitities;
using Nkujukira.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Nkujukira.Demo.Managers
{
    //THIS CLASS HOLDS FUNCTIONS FOR ENROLLING AND COMPARING FACES FOR INDIVIDUALS INORDER TO FIND
    //THE LEVEL OF SIMILARITY OF THE 2 FACES
    public class FacesManager : Manager
    {
        //LICENCE KEY TO ACTIVATE THE FACE SDK LIB
        private const string LICENSE_KEY          = "KHL/2H1GmBZ1jXiF1zxfJXBZUXGZpss0v7msjyBE0Tw2pX7G0X1SUy+zjq7CxilEKs90hNL29oX7z350wIQXOAfWXkRXPmUqYjfdpxKQnHs7HO/HeVIfV0KIqR0T3LMwhcubF51Oxdm88Xyl3BL+f2wODspCL53IBUVo1cTMrEU=";
       
        public const float FaceDetectionThreshold = 3;
        public const float FARValue               = 100;
        
        //THE MINIMUM SIMILARITY BETWEEN ANY 2 FACES FOR THEM TO BE CONSIDERED THE SAME
        private static float SIMILARITY_THRESHOLD = GetSimilarityThreshold();

        private List<Face> known_faces_list { get; set; }
        private FaceRecognitionResult face_recog_results;


        public FacesManager()
        {
            known_faces_list = new List<Face>();
            face_recog_results = new FaceRecognitionResult();

            //ACTIVATE THE FACE SDK LIBRARY USING A VALID LICENCE KEY
            int result = FSDK.ActivateLibrary(LICENSE_KEY);

            //IF LIBRARY IS ACTIVATED
            if (result == FSDK.FSDKE_OK)
            {
                //INITILIAZE THE LIBARARY
                Debug.WriteLine("Library activated");
                Debug.WriteLine("SIMILARITY THESHOLD=" + SIMILARITY_THRESHOLD);
                FSDK.InitializeLibrary();
            }
            else
            {
                throw new ArgumentException("FSDK Library must be activated with valid key for this to work");
            }
        }

        private static float GetSimilarityThreshold()
        {
            Setting similarity_threshold_setting = SettingsManager.GetSetting(SettingsManager.SETTINGS.SIMILARITY_THRESHOLD);
            float similarity_threshold = (float)Convert.ToDouble(similarity_threshold_setting.value);
            return similarity_threshold;
        }

        public bool EnrollPerpetratorFaces(Perpetrator perpetrator)
        {
            try
            {
                foreach (var face in perpetrator.faces)
                {
                   
                    //CREATE NEW FACE OBJECT
                    Face a_face = new Face();
                    a_face.face_position = new FacePosition();
                    a_face.facial_features = new FSDK.TPoint[2];
                    a_face.face_template = new byte[FSDK.TemplateSize];
                    a_face.image = new FSDK.CImage(face.ToBitmap());
                    a_face.is_perpetrator = true;
                    a_face.id = perpetrator.id;

                    EnrollFace(a_face);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool EnrollFace(Face a_face)
        {
            //ASSUMING THAT FACES ARE VERTICAL (HANDLEARBITRARYROTATIONS IS FALSE) TO SPEED UP FACE DETECTION
            FSDK.SetFaceDetectionParameters(false, true, 384);
            FSDK.SetFaceDetectionThreshold((int)FaceDetectionThreshold);



            //GET POSITION OF FACE IN IMAGE
            a_face.face_position = FacePosition.FromFSDK(a_face.Clone().image.DetectFace());
            a_face.face_image = a_face.Clone().image.CopyRect((int)(a_face.face_position.xc - Math.Round(a_face.face_position.w * 0.5)), (int)(a_face.face_position.yc - Math.Round(a_face.face_position.w * 0.5)), (int)(a_face.face_position.xc + Math.Round(a_face.face_position.w * 0.5)), (int)(a_face.face_position.yc + Math.Round(a_face.face_position.w * 0.5)));

            //GET THE FACIAL FEATURES OF THE FACE
            FSDK.TFacePosition face_pos = a_face.face_position;
            a_face.facial_features = a_face.Clone().image.DetectEyesInRegion(ref face_pos);

            //GET A TEMPLATE OF THE FACE TO BE USED FOR LATER COMPARISON
            a_face.face_template = a_face.Clone().image.GetFaceTemplateInRegion(ref face_pos);
            known_faces_list.Add(a_face);

            return true;
        }

        public bool EnrollStudentFaces(Student student)
        {
            try
            {
                foreach (var image in student.photos)
                {
                    //CREATE NEW FACE OBJECT
                    Face a_face = new Face();
                    a_face.face_position = new FacePosition();
                    a_face.facial_features = new FSDK.TPoint[2];
                    a_face.face_template = new byte[FSDK.TemplateSize];
                    a_face.image = new FSDK.CImage(image.ToBitmap());
                    a_face.is_perpetrator = false;
                    a_face.id = student.id;

                    EnrollFace(a_face);
                    
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public FaceRecognitionResult MatchFace(Image<Bgr, byte> a_face)
        {
            try
            {
                if (a_face == null)
                {
                    throw new ArgumentNullException();
                }

                //CREATE A FACE OBJECT 
                Face unknown_face = new Face();
                unknown_face.face_position = new FacePosition();
                unknown_face.facial_features = new FSDK.TPoint[FSDK.FSDK_FACIAL_FEATURE_COUNT];
                unknown_face.face_template = new byte[FSDK.TemplateSize];
                unknown_face.image = new FSDK.CImage(a_face.ToBitmap());

                //GET THE POSITION OF THE FACE IN THE IAGE
                unknown_face.face_position = FacePosition.FromFSDK(unknown_face.image.DetectFace());
                unknown_face.face_image = unknown_face.Clone().image;

                FSDK.TFacePosition face_pos = unknown_face.face_position.Clone();


                //CHECK IF A FACE HAS BEEN DETECTED
                if (0 == face_pos.w)
                {
 
                    face_pos = null;
                    Debug.WriteLine("No Face Found");
                    return face_recog_results;
                }

                try
                {
                    FSDK.TFacePosition face_pos_1 = unknown_face.face_position.Clone();

                    //GET THE FACIAL FEATURES OF THE FACE LIKE EYES NOSE ETC
                    unknown_face.facial_features = unknown_face.Clone().image.DetectEyesInRegion(ref face_pos_1);

                    face_pos_1 = null;
                }
                catch (Exception) { }

                try
                {
                    FSDK.TFacePosition face_pos_2 = unknown_face.face_position.Clone();

                    //GET A TEMPLATE OF THE FACE TO BE USED FOR COMPARISON
                    unknown_face.face_template = unknown_face.Clone().image.GetFaceTemplateInRegion(ref face_pos_2);

                    face_pos_2 = null;

                }
                catch (Exception) { }

                //THRESHOLD INDICATING HOW SIMILAR THE TWO FACS MUST BE TO BE CONSIDERED SAME
                float similarity_threshold = 0.0f;

                //TO DETERMINE IF THE MATCHED TEMPLATES BELONG TO THE SAME PERSON (WITH A SPECIFIED ERROR POSSIBILITY),
                //YOU CAN COMPARE THE FACIAL SIMILARITY VALUE WITH A THRESHOLD CALCULATED BY
                FSDK.GetMatchingThresholdAtFAR(FARValue / 100, ref similarity_threshold);

                //NUMBER OF MATCHES FOUND
                int matches_count = 0;

                //COUNT OF ALL FACES ENROLLED
                int faces_count = known_faces_list.Count;

                //HOLDS A FLOAT INDICATING HOW SIMILAR GIVEN FACE IS TO THAT IN THE SAME INDEX IN THE FACE_LIST
                float[] similarities = new float[faces_count];
                int[] numbers = new int[faces_count];

                List<KeyValuePair<Face, float>> face_to_similarity_map = new List<KeyValuePair<Face, float>>();

                //LOOP THRU THE KNOWN FACES COMPARING EACH FACE WITH THE UNKNOWN FACE
                for (int i = 0; i < known_faces_list.Count; i++)
                {
                    //VALUE INDICATING HOW SIMILAR THE 2 FACES ARE
                    float similarity = 0.0f;

                    //GET THE NEXT FACE IN THE FACE_LIST
                    Face next_face = known_faces_list[i];

                    //GET TEMPLATES FOR BOTH THE UNKNOWN FACE AND NEXT FACE
                    Byte[] unknown_face_template = unknown_face.face_template;
                    Byte[] known_face_template = next_face.face_template;

                    //COMPARE THE 2 FACES FOR SIMILARITY BETWEEN THEM
                    FSDK.MatchFaces(ref unknown_face_template, ref known_face_template, ref similarity);

                    unknown_face_template = null;
                    known_face_template = null;

                    if (similarity >= similarity_threshold)
                    {
                        similarities[matches_count] = similarity;
                        numbers[matches_count] = i;
                        face_to_similarity_map.Add(new KeyValuePair<Face, float>(next_face, similarity));
                        ++matches_count;
                    }
                }

                //Dispose of Face

                //SORT THE SIMILARITIES IN DESCENDING ORDER INORDERTO FIND THE MOST SIMILAR FACE
                FloatsDescendingOrder floats_descending_order = new FloatsDescendingOrder();
                Array.Sort(similarities, numbers, 0, matches_count, (IComparer<float>)floats_descending_order);

                //GET THE PERPETRATOR ASSOCIATED WITH THE FACE
                face_recog_results = new FaceRecognitionResult();
                face_recog_results = GetOfMostSimilarFace(similarities, face_to_similarity_map);
                face_recog_results.original_detected_face = a_face;
                face_to_similarity_map = null;

                //RETURN RESULTS OF FACE RECOGNITION OPERATION
                return face_recog_results;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return face_recog_results;
        }





        private FaceRecognitionResult GetOfMostSimilarFace(float[] similarities, List<KeyValuePair<Face, float>> face_similarity_map)
        {
            if (similarities != null)
            {
                //IF THERE ARE SIMILARITIES
                if (similarities.Length > 0)
                {
                    //GET SIMILARITY OF MOST SIMILAR FACE IN PERCENTAGE FORM
                    float most_similar = similarities[0] * 100;
                    Debug.WriteLine("SIMILARITY TO FACE    =" + most_similar);
                    Debug.WriteLine("CONDITION IS          =" + (most_similar >= SIMILARITY_THRESHOLD ? true : false));

                    //IS THE SIMILARITY GREATER THAN THE THRESHOLD
                    if (most_similar >= SIMILARITY_THRESHOLD)
                    {
                        //GET THE ID OF THE FACE ASSOCIATED WITH THE SIMILARITY
                        //THIS IS ALSO THE ID OF THE PERPETRATOR OR STUDENT WHO WAZ ENROLLED

                        var key_val = face_similarity_map.Find(item => (item.Value * 100).Equals((float)most_similar));
                        Debug.WriteLine("VALUE             =" + key_val.Value);
                        Debug.WriteLine("id of most similar perpetrator is :".ToUpper() + key_val.Key.id);

                        //SET THE PROPERTIES OF THE RESULT
                        face_recog_results.similarity = most_similar;
                        face_recog_results.match_was_found = true;
                        face_recog_results.id = key_val.Key.id;

                    }
                }

            }
            return face_recog_results;
        }


        public void ClearEnrolledFaces()
        {
            known_faces_list.Clear();
        }

    }

    //THIS COMPARES 2 FLOATS
    public class FloatsDescendingOrder : IComparer<float>
    {
        public int Compare(float x, float y)
        {
            return y.CompareTo(x);
        }
    }
}
