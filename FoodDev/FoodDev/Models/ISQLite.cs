using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FoodDev.Models
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
