using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;

namespace BookingApp
{
    // Received instruction from this link: https://www.codeproject.com/Articles/43438/Connect-C-to-MySQL;
    class DataSource
    {
        // Member Variables
        private MySqlConnection _connection;
        private string _server;
        private string _database;
        private string _uid;
        private string _password;
        private string _tableName;

        public MySqlConnection Connection { get => _connection; set => _connection = value; }
        public string Server { get => _server; set => _server = value; }
        public string Database { get => _database; set => _database = value; }
        public string Uid { get => _uid; set => _uid = value; }
        public string Password { get => _password; set => _password = value; }
        public string TableName { get => _tableName; set => _tableName = value; }

        //Constructor
        public DataSource()
        {
            Initialize();
        }

        private void Initialize()
        {
            Server = "localhost";
            Database = "projectOne";
            Uid = "root";
            Password = "UnitedTraining2022";
            string connectionString;
            connectionString = "server=" + Server + ";" + "database=" + Database + ";" + "user=" + Uid + ";" + "password=" + Password + ";";
            Connection = new MySqlConnection(connectionString);

        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                Connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.

                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("\nCannot connect to server. Figure it out Ryan\n");
                        break;
                    case 1045:
                        Console.WriteLine("\nInvalid username/password, please try again\n");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        //Insert statement
        public void Insert(Instructor ins)
        {
            string query = null;

            /*
            if (TableName.Equals("students"))
            {
                query = "INSERT INTO" + std.TableName + "(FirstName, LastName, Age) VALUES (" + std.FirstName + ", " + std.LastName + ", " + std.Age + ")";
            }
            */

            if (ins.TableName.Equals("instructors"))
            {
                query = "INSERT INTO " + ins.TableName + " (FirstName, LastName, Age, Instrument, Degree, Description) " +
                                   "VALUES (" + ins.FirstName + ", " + ins.LastName + ", " + ins.Age + ", " + ins.Instrument + ", " + ins.Degree + ", " + ins.Description + ")";
            }

            // open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update(string query)
        {
            query = "UPDATE students SET FirstName = 'Joe', Age = '22' WHERE FirstName='John' && LastName = 'Doe'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statements
        public void DeleteInstructor(Instructor ins)
        {
            string query;

            query = "DELETE FROM " + ins.TableName + "WHERE InstructorId = " + ins.InstructorId;

            // Opening connection
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, Connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public void DeleteStudent(Student stu)
        {
            string query;

            query = "DELETE FROM " + stu.TableName + "WHERE InstructorId = " + stu.StudentId;

            // Opening connection
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, Connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }


        //Select statement
        public List<string>[] Select()
        {
            string query = "SELECT * FROM " + TableName;
            int size = 0;
            if (TableName.Equals("students"))
            {
                size = 9;
            }
            else if (TableName.Equals("instructors"))
            {
                size = 8;
            }

            // We have to create a list to store the result
            List<string>[] list = new List<string>[size];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = new List<string>();
            }

            /*
                list[0] = new List<string>();
                list[1] = new List<string>();
                list[2] = new List<string>();
                list[3] = new List<string>();
                list[4] = new List<string>();
                list[5] = new List<string>();
                list[6] = new List<string>();
            */

            // Open Connection
            if (this.OpenConnection() == true)
            {
                // Create command and assign query and connection to command
                MySqlCommand cmd = new MySqlCommand(query, Connection);
                // Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                // Read the data and store them in the list
                if (TableName.Equals("students"))
                {
                    while (dataReader.Read())
                    {
                        list[0].Add(dataReader["StudentId"] + "");
                        list[1].Add(dataReader["FirstName"] + "");
                        list[2].Add(dataReader["LastName"] + "");
                        list[3].Add(dataReader["Age"] + "");
                        list[4].Add(dataReader["Instrument"] + "");
                        list[5].Add(dataReader["Instructor"] + "");
                        list[6].Add(dataReader["InstructorId"] + "");
                        list[7].Add(dataReader["created_At"] + "");
                        list[8].Add(dataReader["updated_At"] + "");
                    }
                }

                if (TableName.Equals("instructors"))
                {
                    while (dataReader.Read())
                    {
                        list[0].Add(dataReader["InstructorId"] + "");
                        list[1].Add(dataReader["FirstName"] + "");
                        list[2].Add(dataReader["LastName"] + "");
                        list[3].Add(dataReader["Age"] + "");
                        list[4].Add(dataReader["Instrument"] + "");
                        list[5].Add(dataReader["Description"] + "");
                        list[6].Add(dataReader["created_At"] + "");
                        list[7].Add(dataReader["updated_At"] + "");
                    }
                }

                // close Data Reader 
                dataReader.Close();

                // close Connection
                this.CloseConnection();

                return list;

            }
            else
            {
                return list;
            }
        }

        //Count statement
        public int Count()
        {
            string query = "SELECT COUNT(*) FROM " + TableName;
            int Count = -1;

            // Open Connection
            if (this.OpenConnection() == true)
            {
                //Create MySql Command
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //Close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Backup
        public void Backup()
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path;
                path = "C:/Users/rynmo/OneDrive/Desktop/MSSA/UnitedTraining/Project1/Proj1SqlBackup/MySqlBackup" + year + "-"
                            + month + "-"
                            + day + "-"
                            + hour + "-"
                            + minute + "-"
                            + second + "-"
                            + millisecond + ".sql";
                StreamWriter flie = new StreamWriter(path);

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump-proj1";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", Uid, Password, Server, Database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);
            }
            catch (IOException ex)
            {
                Console.WriteLine("\nError, unable to backup!\n");
                Console.WriteLine(ex.Message);
            }
        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from path
                string path;
                path = "C:/Users/rynmo/OneDrive/Desktop/MSSA/UnitedTraining/Project1/Proj1SqlBackup/MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", Uid, Password, Server, Database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine("\nError, unable to Restore!\n");
                Console.WriteLine(ex.Message);
            }
        }

    }
}
