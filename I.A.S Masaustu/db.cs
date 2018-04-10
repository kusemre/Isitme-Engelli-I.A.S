using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace eczane_barkod_sistemi
{
    class db
    {
        //START
        public db(string dbAddress)
        {
            conn = new SQLiteConnection("Data Source=" + dbAddress + "; Version=3;");
        }
        //END


        //START
        private SQLiteConnection conn;
        private SQLiteCommand command;
        public Exception Error;
        //END


        //START
        public bool NonQuery(string command)
        {
            this.Error = null;
            try
            {
                this.conn.Open();
                this.command = new SQLiteCommand(command, this.conn);
                this.command.ExecuteNonQuery();
                this.conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                this.Error = ex;
                return false;
            }
        }
        public List<List<string>> Query(string command)
        {
            this.Error = null;
            List<List<string>> listDB = new List<List<string>>();
            try
            {
                this.conn.Open();
                this.command = new SQLiteCommand(command, this.conn);
                SQLiteDataReader readed = this.command.ExecuteReader();
                while (readed.Read())
                {
                    List<string> temp = new List<string>();
                    for (int i = 0; i < readed.FieldCount; i++)
                    {
                        temp.Add(readed[i].ToString());
                        //listDB.Add(new string[] { readed[0].ToString(), readed[1].ToString(), readed[2].ToString(), readed[3].ToString() });
                    }
                    listDB.Add(temp);
                }
                this.conn.Close();
                return listDB;
            }
            catch (Exception ex)
            {
                this.Error = ex;
                return null;
            }
        }
        //END


        //START
        public bool connControl()
        {
            try
            {
                this.Error = null;
                this.conn.Open();
                this.conn.Clone();
                return true;
            }
            catch (Exception ex)
            {
                this.Error = ex;
                return false;
            }
        }
        //END
    }
}
