using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Geoffrey_Muchangi.Models
{
    public partial class Form1 : Form
    {
        private AssignmentDbContext _context;
        private Table1 _currentRecord;
        private int _currentIndex;

        public Form1()
        {
            InitializeComponent();
            _context = new AssignmentDbContext();
            LoadData();
        }

        private void LoadData()
        {
            var records = _context.Table1.ToList();
            if (records.Count > 0)
            {
                _currentIndex = 0;
                _currentRecord = records[_currentIndex];
                DisplayRecord();
            }
        }

        private void DisplayRecord()
        {
            if (_currentRecord != null)
            {
                txtno.Text = _currentRecord.ID.ToString();
                txtName.Text = _currentRecord.Name;
                txtDescription.Text = _currentRecord.Description;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _currentRecord = new Table1();
            txtno.Clear();
            txtName.Clear();
            txtDescription.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_currentRecord != null)
            {
                _currentRecord.Name = txtName.Text;
                _currentRecord.Description = txtDescription.Text;

                if (_currentRecord.ID == 0) // New record
                {
                    _context.Table1.Add(_currentRecord);
                }
                else // Existing record
                {
                    _context.Entry(_currentRecord).State = EntityState.Modified;
                }

                _context.SaveChanges();
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_currentRecord != null)
            {
                _context.Table1.Remove(_currentRecord);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentIndex > 0)
            {
                _currentIndex--;
                _currentRecord = _context.Table1.ToList()[_currentIndex];
                DisplayRecord();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var records = _context.Table1.ToList();
            if (_currentIndex < records.Count - 1)
            {
                _currentIndex++;
                _currentRecord = records[_currentIndex];
                DisplayRecord();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
