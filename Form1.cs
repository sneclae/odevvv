using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;

namespace görsel_programlama_15_mayıs_ikinci_ders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //tabloo adında bir obje oluşturduk
        DataTable tabloo = new DataTable();
        private void button1_Click(object sender, EventArgs e)
        {

            tabloo.Columns.Add("ders adı", typeof(string));
            tabloo.Columns.Add("vize", typeof(int));
            tabloo.Columns.Add("final", typeof(int));
            tabloo.Columns.Add("ortalama", typeof(double)); // tabloyu oluşturma kısmı 

            tabloo.Rows.Add("görsel", 45, 85, 0.0);
            tabloo.Rows.Add("yazılım", 67, 78, 0.0);
            tabloo.Rows.Add("mikro", 54, 92, 0.0);

            dataGridView2.DataSource = tabloo; // tabloo ile datagridviewi birbirine bağlama

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //tabloya ekleme işlemi (ekle butonuna basma)
            string ad = textBox1.Text;
            string vize = textBox2.Text;
            string final = textBox3.Text;

            tabloo.Rows.Add(ad, vize, final, 0.0);

            /* üstteki işlem yerine  
              tbl.Rows.Add(textbox1.text , Convert.ToInt32(textbox3.text), Convert.ToInt32(textBox4.Text) , 0.0 )
              da yapabiliriz */

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //silme işlemi (sil butonuna basma)

            //dataGridView2.Rows.Clear();  //yazarsak  tüm satırları siler 

            if (dataGridView2.SelectedRows.Count > 0)
            {
                dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index); //seçili satırlardan 0.olanın indexi demek oluyor
                //RemoveAt bir metod

                //FİNALDE ÇOKLU SEÇİM İLE SİLMEYİ SORARIM DEDİ!!!
            }
            else
            {
                MessageBox.Show("lütfen silinecek satırı seçin");
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            //HESAPLA BUTONU 
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int index = dataGridView2.SelectedRows[0].Index;
                int vize = Convert.ToInt32(tabloo.Rows[index][1]); //1.parantez satır 2.parantez sütun demek oluyor.
                int final = Convert.ToInt32(tabloo.Rows[index][2]);

                tabloo.Rows[index][3] = (double)vize * 0.4 + (double)final * 0.6;

                dataGridView2.DataSource = tabloo;

            }



        }

        private void button5_Click(object sender, EventArgs e)
        {
            //tümünü hesapla butonuna basınca 

            int satirSay = dataGridView2.RowCount; //satır sayısına erişmek için kullanılan metod
            int vize = 0;
            int final = 0;

            for (int i = 0; i < satirSay - 1; i++) // -1 dedik çünkü en alttaki boş satırı da sayıyor. onu saymamamız gerek
            {
                vize = Convert.ToInt32(tabloo.Rows[i][1]);
                final = Convert.ToInt32(tabloo.Rows[i][2]);

                tabloo.Rows[i][3] = vize * 0.4 + final * 0.6;
                dataGridView2.DataSource = tabloo;
            }
            // ödev tümünü hesapla işini foreach ile yazma.
        }
        //21 mayıstaki ders 
        private void button6_Click(object sender, EventArgs e)
        {
            tabloo.DefaultView.Sort = "ort ASC";
            tabloo = tabloo.DefaultView.ToTable();
            dataGridView2.DataSource = tabloo;

        }
        public static DataTable sortet (DataTable dt, string sutun , string yon)
        {
           dt.DefaultView.Sort = sutun + " " + yon;
            dt = dt.DefaultView.ToTable();
            return dt;
        }

    }

}
 