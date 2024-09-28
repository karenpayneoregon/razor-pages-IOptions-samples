using System.ComponentModel;
using ExcelConnectionApplication.Classes;
using ExcelConnectionApplication.Classes.Configuration;
using ExcelConnectionApplication.Models;
using Ganss.Excel;


namespace ExcelConnectionApplication;

public partial class MainForm : Form
{
    public BindingSource BindingSource = new();
    public BindingList<Wines> BindingList = [];


    public MainForm()
    {
        InitializeComponent();

        Shown += MainForm_Shown;
    }

    private void MainForm_Shown(object? sender, EventArgs e)
    {
        var excel = new ExcelMapper(ExcelConnections.Instance.MainConnection);
        BindingList = new BindingList<Wines>(excel.Fetch<Wines>().ToList());
        BindingSource.DataSource = BindingList;
        dataGridView1.DataSource = BindingSource;
        dataGridView1.ExpandColumns();
    }
}
