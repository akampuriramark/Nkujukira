﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using MetroFramework.Demo.Entitities;
using System.Data;
using System.Collections;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace MetroFramework.Demo.Managers
{
    class DatabaseManager
    {
        private MySqlConnection connection = null;
        private String server;
        private String dataBase;
        private String password;
        private String username;
        public static bool firstUser = false;
        public DatabaseManager()
        {
            initialise();
            this.createTables();
            if (userTableIsNotEmpty())
            {
                Debug.WriteLine("\nTable SystemUsers is not Empty\n");
            }
            else
            {
                bool user_created = createNewUser(new SystemUser("admin", "123", "Admin"));
                if (user_created)
                {
                    firstUser = true;
                    Debug.WriteLine("New User created");
                }
                else
                {
                    Debug.WriteLine("No User created");
                }
            }


        }
        private void initialise()
        {
            try
            {
                server = "localhost";
                dataBase = "Nkujukira";
                username = "root";
                password = "";
                //String connectionString = "SERVER=" + server + ";" + "DATABASE=" + dataBase + ";" + "UID=" + username + ";" + "PASSWORD" + password + ";";
                String connectionString = @"server=" + server + ";userid=" + username + ";password=" + password + ";database=" + dataBase;
                connection = new MySqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        private bool openConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem With the Open connection");
                Debug.WriteLine(ex.Message);
            }
            return false;
        }
        private bool closeConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem With the Close connection");
                Debug.WriteLine(ex.Message);
            }
            return false;

        }

        public bool createNewUser(SystemUser user)
        {
            String user_name = user.getUserName();
            String pass_word = user.getPassWord();
            String user_type = user.getUserType();
            try
            {
                if (this.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "insert into SystemUsers(Username,Password,UserType) values(@Username,@Password,@UserType)";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Username", user_name);
                    cmd.Parameters.AddWithValue("@Password", pass_word);
                    cmd.Parameters.AddWithValue("@UserType", user_type);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        this.closeConnection();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }
        public bool userNameExists(String user_name)
        {
            bool user_name_exists = false;
            try
            {
                if (this.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "select * from SystemUsers where Username= @Username";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Username", user_name);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        user_name_exists = true;
                    }
                    dataReader.Close();
                    this.closeConnection();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return user_name_exists;
        }
        public bool getUser(String user_name, String pass_word)
        {
            bool user_exists = false;
            try
            {
                if (this.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "select * from SystemUsers where Username= @Username and Password= @Password";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Username", user_name);
                    cmd.Parameters.AddWithValue("@Password", pass_word);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        user_exists = true;
                    }
                    dataReader.Close();
                    this.closeConnection();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return user_exists;
        }
        public bool userTableIsNotEmpty()
        {
            bool default_user_exists = false;
            try
            {
                if (this.openConnection() == true)
                {
                    String query = "select * from SystemUsers";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        default_user_exists = true;
                    }
                    dataReader.Close();
                    this.closeConnection();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return default_user_exists;
        }
        public bool changeUserRole(String id, String role)
        {
            bool role_updated = false;
            try
            {

                if (this.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    String query = "Update SystemUsers SET UserType=@userRole WHERE Id=@id";
                    cmd.Connection = connection;
                    cmd.Prepare();
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@UserRole", role);
                    cmd.Parameters.AddWithValue("@id", id);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        role_updated = true;
                    }

                    this.closeConnection();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return role_updated;

        }

        public bool updateLoginCredentials(String default_user_name, String default_pass_word, String user_name, String pass_word)
        {
            bool default_user_updated = false;
            try
            {
                if (this.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    String query = "Update SystemUsers SET Username=@Username,Password=@Password WHERE Username=@Username_default and Password=@Password_default";
                    cmd.Connection = connection;
                    cmd.Prepare();
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Username", user_name);
                    cmd.Parameters.AddWithValue("@Password", pass_word);
                    cmd.Parameters.AddWithValue("@Username_default", default_user_name);
                    cmd.Parameters.AddWithValue("@Password_default", default_pass_word);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        default_user_updated = true;
                    }

                    this.closeConnection();
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return default_user_updated;
        }

        public bool deleteUser(String id)
        {
            bool deleted = false;
            try
            {
                if (this.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "delete from SystemUsers where id= @id";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@id", id);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        deleted = true;
                    }
                    this.closeConnection();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return deleted;
        }

        public DataTable generateUsersDataTable()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable.Columns.Add("ID");
                dataTable.Columns.Add("Name");
                dataTable.Columns.Add("Role");

                if (this.openConnection() == true)
                {
                    String query = "select * from SystemUsers";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        String id = dataReader.GetString("Id");
                        String user_name = dataReader.GetString("Username");
                        String password = dataReader.GetString("Password");
                        String user_type = dataReader.GetString("UserType");
                        dataTable.Rows.Add(id, user_name, user_type);
                    }
                    dataReader.Close();

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                this.closeConnection();
            }
            return dataTable;
        }
        public void createTables()
        {
            createTableSystemUsers();
        }

        public bool createTableSystemUsers()
        {
            bool created = false;
            try
            {
                if (this.openConnection() == true)
                {
                    String query = "Create table SystemUsers(Id int auto_increment,Username varchar (30) not null,Password varchar (30) not null,UserType varchar (25) not null,Primary key(Id))";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        Debug.WriteLine("System users table created");
                        created = true;
                    }

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                this.closeConnection();
            }
            return created;
        }

        public List<Student> getStudentDetails()
        {
            List<Student> list = new List<Student>();
            try
            {
                if (this.openConnection() == true)
                {
                    String query = "select * from Student";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        String firstName = dataReader.GetString("FirstName");
                        String middleName = dataReader.GetString("MiddleName");
                        String lastName = dataReader.GetString("LastName");
                        String studentNo = dataReader.GetString("StudentNo");
                        String regNo = dataReader.GetString("RegNo");
                        String course = dataReader.GetString("Course");
                        String DOB = dataReader.GetString("DOB");
                        String gender = dataReader.GetString("Gender");
                        byte[] imageData = (byte[])dataReader["Photo"];
                        list.Add(new Student(firstName, middleName, lastName, studentNo, regNo, course, DOB, gender, imageData));
                         using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                            //img.Save(@"C:\Users\Royal\Desktop\ours", System.Drawing.Imaging.ImageFormat.Jpeg);
                            Bitmap b = (Bitmap)img;
                            SavePicture(b);

                        }

                    }
                    dataReader.Close();

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message+"Image ERROR");
            }
            finally
            {
                this.closeConnection();
            }
            return list;
        }
        public void SavePicture(Bitmap myBitmap)
        {

            Bitmap bm = new Bitmap(myBitmap);
            bm.Save("Output\\out.bmp" ,System.Drawing.Imaging.ImageFormat.Bmp );
        }


    }
}
