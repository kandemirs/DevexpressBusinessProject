using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EnmosProje
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-THGEUAH\DEV19;Initial Catalog=Dbo;Persist Security Info=True;User ID=sa;Password=Enmos2005");
            baglan.Open();
            return baglan;

        }
    }
}


