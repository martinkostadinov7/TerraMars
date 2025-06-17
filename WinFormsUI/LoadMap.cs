using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using ServiceLayer;
namespace WinFormsUI
{
    public partial class LoadMap : Form
    {
        MapService mapService;
        UserService userService;
        BindingList<Map> maps;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Map Map { get; set; }
        User User { get; set; }
        public LoadMap(User user)
        {
            User = user;
            mapService = new MapService();
            userService = new UserService();
            InitializeComponent();
            maps = new BindingList<Map>(user.Maps.OrderByDescending(m => m.LastModified).ToList());
            mapsGridView.DataSource = maps;
            mapsGridView.Columns["Id"].Visible = false;
            mapsGridView.Columns["CreatedAt"].DefaultCellStyle.Format = "MM/dd HH:mm";
            mapsGridView.Columns["LastModified"].DefaultCellStyle.Format = "MM/dd HH:mm";
            mapsGridView.Columns["OwnerId"].Visible = false;
            mapsGridView.Columns["Owner"].Visible = false;
            mapsGridView.Columns["StoneGathered"].Visible = false;
            mapsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mapsGridView.MultiSelect = false;
            mapsGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            mapsGridView.AllowUserToAddRows = false;
            mapsGridView.AllowUserToDeleteRows = false;
            mapsGridView.AllowDrop = false;
            mapsGridView.AllowUserToAddRows = false;
            mapsGridView.AllowUserToDeleteRows = false;
            mapsGridView.AllowUserToResizeColumns = false;
            mapsGridView.AllowUserToResizeRows = false;
            mapsGridView.RowHeadersVisible = false;
            mapsGridView.ScrollBars = ScrollBars.None;
            mapsGridView.Columns[2].Width = 85;
            mapsGridView.Columns[3].Width = 100;
            mapsGridView.Columns[7].Width = 55;
            mapsGridView.Columns[8].Width = 60;
            mapCountLabel.Text = maps.Count.ToString();
            int width = 0;
            for (int i = 0; i < mapsGridView.ColumnCount; i++)
            {
                if (mapsGridView.Columns[i].Visible)
                {
                    width += mapsGridView.Columns[i].Width;
                }
            }
            int height = 0;
            if (mapsGridView.Rows.Count != 0)
            {
                for (int i = 0; i < mapsGridView.RowCount; i++)
                {
                    height += mapsGridView.Rows[i].Height;
                }

                height += mapsGridView.Rows[0].Height;

            }
            else
            {
                height = 30;
            }
            mapsGridView.Size = new Size(width, height);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (mapsGridView.CurrentRow != null && mapsGridView.CurrentRow.DataBoundItem is Map selectedItem)
            {
                Map = mapService.GetMap(selectedItem.Id);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                throw new Exception("Select a map to load!");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (mapsGridView.CurrentRow != null && mapsGridView.CurrentRow.DataBoundItem is Map selectedItem)
            {
                int mapId = selectedItem.Id;
                Map map = mapService.GetMap(mapId);
                mapService.DeleteMap(mapId);
                maps.Remove(map);
            }
            else
            {
                throw new Exception("Select a map to delete!");
            }
            int width = 0;
            for (int i = 0; i < mapsGridView.ColumnCount; i++)
            {
                if (mapsGridView.Columns[i].Visible)
                {
                    width += mapsGridView.Columns[i].Width;
                }
            }
            int height = 0;
            if (mapsGridView.Rows.Count != 0)
            {
                for (int i = 0; i < mapsGridView.RowCount; i++)
                {
                    height += mapsGridView.Rows[i].Height;
                }

                height += mapsGridView.Rows[0].Height;

            }
            else
            {
                height = 30;
            }
            mapsGridView.Size = new Size(width, height);
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            int rows = 0;
            int cols = 0;
            string name = null;
            var form = new MapGeneratingValues();
            if (form.ShowDialog() == DialogResult.OK)
            {
                rows = form.Rows;
                cols = form.Cols;
                name = form.Name;
                Map = mapService.GenerateMap(userService.GetUser(User.Username, User.Password), rows, cols, name);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            if (mapsGridView.CurrentRow != null && mapsGridView.CurrentRow.DataBoundItem is Map selectedItem)
            {
                var form = new MapRename();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Map = mapService.GetMap(selectedItem.Id);
                    Map = mapService.UpdateMap(Map, form.NewName);
                    Map.LastModified = DateTime.Now;
                    mapsGridView.Refresh();
                }
            }
            else
            {
                throw new Exception("Select a map to rename!");
            }

        }

        private void LoadMap_Load(object sender, EventArgs e)
        {

        }
    }
}
