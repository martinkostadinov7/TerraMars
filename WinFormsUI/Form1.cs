using ServiceLayer;
using BusinessLayer;
namespace WinFormsUI
{
    public partial class Form1 : Form
    {
        private int tileSize = 25;
        public Form1()
        {
            InitializeComponent();
        }
        private void UpdateGridVisual(Map Map, int x, int y)
        {
            dataGridView1.RowCount = x;
            dataGridView1.ColumnCount = y;
            for (int i = 0; i < y; i++)
            {
                dataGridView1.Columns[i].Width = tileSize;
            }
            for (int i = 0; i < x; i++)
            {
                dataGridView1.Rows[i].Height = tileSize;
            }
            dataGridView1.Size = new System.Drawing.Size(y * tileSize + 25, x * tileSize + 25);

            //for (int row = 0; row < Map.Tiles.GetLength(0); row++)
            //{
            //    for (int col = 0; col < Map.Tiles.GetLength(1); col++)
            //    {
            //        var tile = Map.Tiles[row, col];
            //        var cell = dataGridView1.Rows[row].Cells[col];
            //        cell.Style.BackColor = tile.Color;
            //    }
            //}
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.ClearSelection(); // премахва началната селекция
            dataGridView1.ReadOnly = true; // по желание
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;

        }
        MapService mapService = new MapService();
       
        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            Map Map = mapService.GenerateMap(x, y);
            UpdateGridVisual(Map, x, y);
        }
    }
}
