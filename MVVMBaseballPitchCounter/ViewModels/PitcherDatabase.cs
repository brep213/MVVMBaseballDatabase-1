using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MVVMBaseballPitchCounter.Models;
using System.ComponentModel;
using Android.App;

namespace MVVMBaseballPitchCounter.ViewModels
{
    public class PitcherDatabase
    {
        private SQLiteConnection conn;
        string _dbPath;
        private void Init()
        {
            if(conn != null)
            {
                //connection is already made, die
                return;
            }
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Pitcher>();//create if not ther, ignore if table is built
        }

        public PitcherDatabase(string dbPath) 
        { 
            _dbPath= dbPath;
        }//end constructor

        public async void InsertPitcher(Pitcher newPitcher)
        {
            int result;
            try
            {
                Init();
                if(string.IsNullOrEmpty(newPitcher.Name))
                {
                    throw new Exception("Name required");
                }
                result = conn.Insert(newPitcher);
            }
            catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error - not added", ex.ToString(), "Ok");
            }
        }

    }//end class
}//end namespace
