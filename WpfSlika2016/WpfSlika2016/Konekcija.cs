using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfSlika2016
{
    class Konekcija
    {
        public static SqlConnection kreirajKonekciju()
        {
            SqlConnectionStringBuilder cnnSb = new SqlConnectionStringBuilder();
            cnnSb.DataSource = @"DESKTOP-A7INKR7\SQLEXPRESS";
            cnnSb.InitialCatalog="BazaOsoba2";
            cnnSb.IntegratedSecurity=true;
            SqlConnection konekcija=new SqlConnection(cnnSb.ToString());
            return konekcija;
        }

    }
}
