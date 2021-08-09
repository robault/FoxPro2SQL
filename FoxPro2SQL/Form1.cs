using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Threading;


namespace FoxPro2SQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Utility Functions / Properties

        string threadStatus = "";
        Thread workThread = null;
        Thread monitorThread = null;

        private const string vfpConnString = "Provider=VFPOLEDB.1;Data Source=¿\\;Collating Sequence=general;";

        private const string sqlString = "SELECT * FROM [¿]";

        private static string SQLSelectString(string selectString, string tablename)
        {
            return selectString.Replace("¿", tablename);
        }

        /*This is unused but kept as an example to generate a data table from a FoxPro table
          DataTables use more than 4 times the memory than the size of the DBF file. Ouch. */
        public DataTable loadDBF(string filePath, string dbDirectory)
        {
            string filename = Path.GetFileName(filePath);
            DataTable table = new DataTable();

            try
            {
                System.Data.OleDb.OleDbConnection oledbConn = new System.Data.OleDb.OleDbConnection();
                oledbConn.ConnectionString = SQLSelectString(vfpConnString, dbDirectory);
                oledbConn.Open();

                System.Data.OleDb.OleDbCommand oledbCMD = oledbConn.CreateCommand();
                oledbCMD.CommandText = SQLSelectString(sqlString, filePath);
                table.Load(oledbCMD.ExecuteReader());
                oledbConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return table;
        }

        private void CreateDataInExampleFile(string filePath)
        {
            try
            {
                System.Data.OleDb.OleDbConnection oConn = new System.Data.OleDb.OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + filePath + "FoxProExample.DBF;");
                oConn.Open();

                System.Data.OleDb.OleDbCommand oCom = new System.Data.OleDb.OleDbCommand("Insert into FoxProExample(RecordID, RecordData) values('1', 'Red')");
                oCom.Connection = oConn;
                oCom.ExecuteNonQuery();

                oCom.CommandText = "Insert into FoxProExample(RecordID, RecordData) values('2', 'Orange')";
                oCom.ExecuteNonQuery();

                oCom.CommandText = "Insert into FoxProExample(RecordID, RecordData) values('3', 'Yellow')";
                oCom.ExecuteNonQuery();

                oCom.CommandText = "Insert into FoxProExample(RecordID, RecordData) values('4', 'Green')";
                oCom.ExecuteNonQuery();

                oCom.CommandText = "Insert into FoxProExample(RecordID, RecordData) values('5', 'Blue')";
                oCom.ExecuteNonQuery();

                oCom.CommandText = "Insert into FoxProExample(RecordID, RecordData) values('6', 'Indigo')";
                oCom.ExecuteNonQuery();

                oCom.CommandText = "Insert into FoxProExample(RecordID, RecordData) values('7', 'Violet')";
                oCom.ExecuteNonQuery();

                oCom.Dispose();
                oConn.Close();
                oConn.Dispose();
            }
            catch (Exception ex)
            {
                sqlCommandTextBox.Text = ex.Message.ToString();
            }
        }

        private bool CreateSQLTableFromFoxProTable(string filePath, string fileName, string cnxString)
        { 
            bool succeeded = false;

            string databaseName = databaseNameTextBox.Text;
            string tableName = fileName.Replace(".DBF", ""); //name of DBF file
            string dbfPath = filePath;
            string command = @"";

            try
            {
                System.Data.SqlClient.SqlConnection cnx = new System.Data.SqlClient.SqlConnection(cnxString);
                cnx.Open();

                //enable ad hoc queries in SQL in seperate batch
                command = @"
                exec sp_configure 'show advanced options', 1;
                reconfigure;
                exec sp_configure 'Ad Hoc Distributed Queries', 1;
                reconfigure;";
                System.Data.SqlClient.SqlCommand cmd1 = new System.Data.SqlClient.SqlCommand(command, cnx);
                cmd1.CommandTimeout = 0;
                cmd1.ExecuteNonQuery();
                cmd1.Dispose();

                //create the table
                command = @"
                IF OBJECT_ID('" + databaseName + @".dbo.[" + fileName + @"]') IS NOT NULL
	                DROP TABLE [" + fileName + @"];

                SELECT * INTO [" + fileName + @"] 
                FROM OPENROWSET('VFPOLEDB.1','" + filePath + @"';;, 'SELECT * FROM [" + fileName + @"]');";
                System.Data.SqlClient.SqlCommand cmd2 = new System.Data.SqlClient.SqlCommand(command, cnx);
                cmd2.CommandTimeout = 0;
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();

                //disable ad hoc queries in SQL in seperate batch
                command = @"
                exec sp_configure 'Ad Hoc Distributed Queries', 0;
                reconfigure;
                exec sp_configure 'show advanced options', 0;
                reconfigure;";
                System.Data.SqlClient.SqlCommand cmd3 = new System.Data.SqlClient.SqlCommand(command, cnx);
                cmd3.CommandTimeout = 0;
                cmd3.ExecuteNonQuery();
                cmd3.Dispose();

                succeeded = true;

                cnx.Close();
                cnx.Dispose();
            }
            catch (Exception ex)
            {
                threadStatus = ex.Message.ToString();
                UpdateProgress();
            }

            return succeeded;
        }

        private string ConnectionString()
        {
            string cnxString = "";

            cnxString += "Data Source=" + serverNameTextBox.Text + ";";
            cnxString += "Initial Catalog=" + databaseNameTextBox.Text + ";";

            if (integratedSecurityCheckBox.Checked == true)
            {
                cnxString += "Integrated Security=SSPI;";
                cnxString += "Trusted_Connection=True;";
            }
            else
            {
                cnxString += "User Id=" + userNameTextBox.Text + ";";
                cnxString += "Password=" + passwordTextBox.Text + "";
            }
            
            return cnxString;
        }

        private void ThreadWorkLoop()
        {
            string filePath = DBFdirectoryTextBox.Text + "\\";
            string cnxString = ConnectionString();

            if (Directory.Exists(DBFdirectoryTextBox.Text))
            {
                foreach (string fileName in Directory.GetFiles(DBFdirectoryTextBox.Text, "*.DBF"))
                {
                    bool succeeded = CreateSQLTableFromFoxProTable(fileName, Path.GetFileName(fileName), cnxString);
                    
                    if (succeeded == false)
                    {
                        threadStatus = "Failed to convert " + Path.GetFileName(fileName);
                    }
                    else
                    {
                        threadStatus = "Imported: " + Path.GetFileName(fileName);
                    }
                    
                    UpdateProgress();
                }
            }
            else
            {
                threadStatus = "Select a valid DBF directory from the View tab, then Convert the files.";
            }
        }

        private void ThreadMonitorLoop()
        {
            while (true)
            {
                if (workThread.IsAlive == false)
                {
                    threadStatus =  Environment.NewLine + "Conversion finished.";
                    UpdateProgress();
                    break;
                } 
            }
        }

        private delegate void UpdateProgressBarDelegate();

        private void UpdateProgress()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new UpdateProgressBarDelegate(UpdateProgress));
            }
            else
            {
                sqlCommandTextBox.Text += threadStatus + Environment.NewLine;
            }
        }

        #endregion

        #region Event Handlers

        private void openDBFdirectoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    DBFdirectoryTextBox.Text = folderBrowserDialog1.SelectedPath;

                    if (Directory.Exists(DBFdirectoryTextBox.Text))
                    {
                        string[] dbfFiles = Directory.GetFiles(DBFdirectoryTextBox.Text, "*.DBF");

                        if (dbfFiles.Length == 0)
                        {
                            throw new Exception("Please choose a directory that contains at least one FoxPro DBF file.");
                        }
                    }
                    else
                    {
                        //probably never get here since the directory was choosen in the FolderBrowserDialog...
                        throw new DirectoryNotFoundException("Directory does not exist.");
                    }
                }
            }
            catch (Exception ex)
            {
                sqlCommandTextBox.Text = ex.Message.ToString();
            }
        }

        private void testConnectionButton_Click(object sender, EventArgs e)
        {
            string sqlCommand = "SELECT 'Connection succeeded.'";

            try
            {
                System.Data.SqlClient.SqlConnection cnx = new System.Data.SqlClient.SqlConnection(ConnectionString());
                cnx.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlCommand, cnx);
                cmd.CommandTimeout = 0;

                System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //Should say: Connection succeeded.
                    sqlCommandTextBox.Text = dr[0].ToString();
                }
                dr.Close();
                dr.Dispose();
                cmd.Dispose();
                cnx.Close();
                cnx.Dispose();

                if (sqlCommandTextBox.Text == "")
                    sqlCommandTextBox.Text = "Connection failed!";
            }
            catch (Exception ex)
            {
                sqlCommandTextBox.Text = ex.Message.ToString();
            }
        }

        private void createFoxProTableButton_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog myDialog = new FolderBrowserDialog();
                myDialog.ShowDialog();
                string saveToPath = myDialog.SelectedPath;

                System.Data.OleDb.OleDbConnection oledbConn = new System.Data.OleDb.OleDbConnection();
                oledbConn.ConnectionString = SQLSelectString(vfpConnString, saveToPath);
                oledbConn.Open();

                System.Data.OleDb.OleDbCommand oledbCMD = oledbConn.CreateCommand();

                oledbCMD.CommandText = "CREATE TABLE FoxProExample (RecordID C(10), RecordData C(20))";
                oledbCMD.ExecuteReader();
                oledbConn.Close();

                CreateDataInExampleFile(saveToPath);

                sqlCommandTextBox.Text = "File created: " + saveToPath + "FoxProExample.DBF " + 
                        Environment.NewLine + Environment.NewLine + 
                        "Set the permissions on the file to allow access from SQL server.";
            }
            catch (Exception ex)
            {
                sqlCommandTextBox.Text = ex.Message.ToString();
            }
        }

        private void convertFoxProToSQLButton_Click(object sender, EventArgs e)
        {
            //blank out the text box
            sqlCommandTextBox.Text = ""; 
            threadStatus = "Conversion started..." + Environment.NewLine;
            UpdateProgress();

            //start the conversion process
            if (workThread == null || workThread.ThreadState == ThreadState.Stopped)
            {
                workThread = new Thread(new ThreadStart(ThreadWorkLoop));
                workThread.Start();
            }

            //check to see when it finishes
            if (monitorThread == null || monitorThread.ThreadState == ThreadState.Stopped)
            {
                monitorThread = new Thread(new ThreadStart(ThreadMonitorLoop));
                monitorThread.Start();
            }
        }

        private void integratedSecurityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (integratedSecurityCheckBox.Checked == true)
            {
                userNameTextBox.Enabled = false;
                passwordTextBox.Enabled = false;
            }
            else
            {
                userNameTextBox.Enabled = true;
                passwordTextBox.Enabled = true;
            }
        }

        #endregion
    }
}
