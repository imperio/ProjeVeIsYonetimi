using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MenuGetir();
        MenuGetir2();
    }

    private void MenuGetir()
    {
        using (SqlConnection conn = new SqlConnection("Data Source= SUNUCU;Initial Catalog=VERİTABANI;uid=KULLANICIADI;pwd=ŞİFRE;Max Pool Size=500"))
        {
            using (SqlCommand cek = new SqlCommand("SELECT MenuID,MenuItem,Link FROM TABLO-Adı", conn))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                try
                {
                    SqlDataReader oku = cek.ExecuteReader();
                    Datalistmenu.DataSource = oku;
                    Datalistmenu.DataBind();
                    oku.Close();
                }
                catch (Exception hata) { Response.Write(hata); }
                finally { conn.Close(); }
            }
        }
    }


    //  ikinci yöntem genel alanda bağlantı stringi tanımlanır ve tüm metodlarda 
    SqlConnection connect = new SqlConnection("Data Source= SUNUCU;Initial Catalog=VERİTABANI;uid=KULLANICIADI;pwd=ŞİFRE;Max Pool Size=500");

    private void MenuGetir2()
    {
        // bağlantı durumu kontrol edilip baglantı açılabilir....
        using (connect)
        {
            using (SqlCommand cek = new SqlCommand("SELECT MenuID,MenuItem,Link FROM MAZMenu", connect))
            {
                if (connect.State == System.Data.ConnectionState.Closed) //bağlantı durumu kapalıysa
                    connect.Open();  //bağlantıyı aç
                try
                {
                    SqlDataReader oku = cek.ExecuteReader();  //datareader ile verileri çekip
                    Datalistmenu.DataSource = oku; //datalist e gönderiyoruz
                    Datalistmenu.DataBind();  // veri tekrarını engellemek için... 
                    oku.Close(); // datareader i kapatıyoruz...
                }
                catch (Exception hata) { Response.Write(hata); }
                finally { connect.Close(); }
            }
        }
    }
    protected void Datalistmenu_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
