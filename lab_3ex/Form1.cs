using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_3ex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AddCC();
            
            
        }
        private void AddCC()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo d in drives)
            {
                cbbODia.Items.Add(d.Name);
            }
        }
        private void cbbODia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo Directory = new DirectoryInfo("D:\\");
            DirectoryInfo[] Directories = Directory.GetDirectories("*.*");
            FileInfo[] files = Directory.GetFiles();
            foreach(DirectoryInfo d in Directories)
            {
                cbbThuMuc.Items.Add(d.Name);
            }
        }
        private void cbbThuMuc_SelectedIndexChanged(object sender, EventArgs e)
        {

            lbDanhSach.Items.Clear();
            txtLoiBaiHat.Text = string.Empty;
            string[] files = Directory.GetFiles(cbbODia.Text + cbbThuMuc.Text);
            foreach (string d in files)
            {
                lbDanhSach.Items.Add(d);
            }
        }
        private void lbDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbDanhSach.SelectedIndex != -1)
            {
                string selectedSongPath= lbDanhSach.SelectedIndex.ToString();

                string lyricsFilePath=    Path.ChangeExtension(selectedSongPath, ".txt");
                if(File.Exists(lyricsFilePath))
                {
                    string lyrics= File.ReadAllText(lyricsFilePath);
                    txtLoiBaiHat.Text= lyrics;
                }
                else
                {
                    txtLoiBaiHat.Text = "Khong co loi bai hat nay";
                }
            }
        }

    }
}
